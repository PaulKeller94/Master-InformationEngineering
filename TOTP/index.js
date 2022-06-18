const express = require("express");
const session = require("express-session");
const bodyparser = require("body-parser");
var path = require("path");
const app = express();
var flash = require("express-flash");
var expressValidator = require("express-validator");
var mysql = require("mysql");
var bcrypt = require("bcrypt");
var dbconfig = require("./database");
var connection = mysql.createConnection(dbconfig.connection);
const crypto = require("crypto");
var bcrypt = require('bcrypt-nodejs');
const { authenticator } = require("otplib");
const QRCode = require("qrcode");
connection.query("USE " + dbconfig.database);
const BcryptSalt = require('bcrypt-salt');
const saltHash = require('password-salt-and-hash');
const { x64 } = require("crypto-js");
app.use(session({ secret: "sessionsecret777" }));
app.use(bodyparser.urlencoded({ apptended: true }));
app.engine("html", require("ejs").renderFile);
app.set("view engine", "html");
app.use("/public", express.static(path.join(__dirname, "public")));
app.set("views", path.join(__dirname, "/views"));
app.use(flash());
app.use(expressValidator());

//console.log(dbconfig)


app.use(
  session({
    secret: "123456cat",
    resave: false,
    saveUninitialized: true,
    cookie: { maxAge: 60000 },
  })
);

// Sign Up
app.get("/", (req, res) => {
  res.render("signup.html");
});

app.post("/sign-up", (req, res) => {
  //var salt = bcrypt.genSaltSync(randomNumber);

  
  const username = req.body.username,
    password = req.body.password,
    secret = authenticator.generateSecret();
  
  // hash psw
  let hashPassword = saltHash.generateSaltHash(password);
  //console.log(hashPassword);

  var newUserMysql = {
    username: username,
    secret: secret,
   // password: bcrypt.hashSync(password, salt)  // use the generateHash function in our user model
   password : hashPassword.password, 
   salt: hashPassword.salt
  };

// check user_credentials
 console.log(newUserMysql);

  var insertQuery =
    "INSERT INTO users ( secret, username, password, salt ) values (?,?,?,?)";
  connection.query(
    insertQuery,
    [newUserMysql.secret, newUserMysql.username, newUserMysql.password, newUserMysql.salt],
    
    
    function (err, rows) {
      newUserMysql.id = rows.insertId;
      //generate qr and put it in session
      QRCode.toDataURL(
        authenticator.keyuri(username, 'MI102 Net&Sec', secret),
        (err, url) => {
          if (err) {
            throw err;
          }
          req.session.qr = url;
          res.redirect("/signup-2fa");
        }
      );
    }
  );

});

// Sign-Up QR-Code
app.get("/signup-2fa", (req, res) => {
  if (!req.session.qr) {
    return res.redirect("/");
  }
  return res.render("signup-2fa.html", { qr: req.session.qr });
});

// Login
app.get("/login", (req, res) => {
  return res.render("login.html");
});

app.post("/login", (req, res) => {
  //verify login
  const username = req.body.username,
    password = req.body.password,
    code = req.body.code;

  return verifyLogin(username, password, code, req, res, "/login");
});

//veryfy Login
function verifyLogin(username, password, code, req, res, failUrl) {
  connection.query(
    "SELECT * FROM users WHERE username = ?",
    [username],
    function (err, rows) {
      if (!rows.length) {
        return res.redirect("/");
      }
      if (username != rows[0].username) {
        return res.redirect("/");
      }
      //if (!bcrypt.compareSync(password, rows[0].password)){
        if(!saltHash.verifySaltHash(rows[0].salt, rows[0].password, password)){
        return res.redirect("/");
      }
      if (!authenticator.check(code, rows[0].secret)) {
      
        console.log("2FA success: " ,authenticator.check(code, rows[0].secret))
       return res.redirect("/");
      }
      console.log("2FA success: " ,authenticator.check(code, rows[0].secret))
      console.log("password:", rows[0].password);
      console.log("salt:", rows[0].salt);
      res.render("success");
    }
  );
}
app.listen(8080, () => {});
module.exports = app;

/* 
Evaluation : 

  Hash: attacker can do : 
    - Recognize (wiederkennen) break common password because known hashes could be precomputed
    - try guesses many offline
    - if an attacker is able to crack a password that multiple user have used, they crack the psw for everyone that used that password all at once
    - see if two people have the same password 
  
  Salt: is a little bit randomness that we sprinkle in with a users psw , salt should be unique
    attacker can not do: 
    - regcognize known hashes because all are unique, precomputed hashes become effectively worthless 

    attacker can do:
    - guess passwords offline since the salt is known, attacker can break weak password but just for one password

  Pepper: store not in database, salt is stored with psw in database, so the attacker does not see the pepper if the db is leak 
    attacker can not do: offline guesses, he needs to break the database and applicationcode
    
  - TOTP: 
    - Zweiter Faktor muss unabhängig vom ersten sein, dass bedeutet, ich darf mein username + psw nicht im handy speichern 
    - Device muss vertrauenswürdig sein 
    - Wenn die Datenbank gelaked wird kann man das secret lesen, das ist in Klartext und nicht im hash da, secret wird mit Uhrzeit gehashed 

*/