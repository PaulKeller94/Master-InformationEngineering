const psw_gen = require('s-salt-pepper');
psw_gen.iterations(75000); 
psw_gen.pepper('your random string goes here');

var db_psw = {
    hash: null,
    salt: null
  }

async function generatepsw (){
  db_psw = await psw_gen.hash('foo');

}

async function testpsw (){
    await generatepsw();

    console.log(await db_psw);
 
    console.log(await psw_gen.compare("foo", db_psw));
}



  