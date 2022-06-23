using System;
namespace Inheritance_Polymorphism_Static_Fields_Function_Class
{
    public class Car
    {
        
        protected string name;
        protected string color;
        private string privatefield;
        public static uint carGenerated = 0;



        public Car(string name, string color, string privatefield)
        {
            this.name = name;
            this.color = color;
            this.privatefield = privatefield;
            carGenerated++;

        }

        // I need this constructor for inharintence bcs in the above ctor is a private field
        public Car(string name, string color)
        {
            this.name = name;
            this.color = color;
            
        }

        public Car()
        {
            carGenerated--;
        }
        public virtual string carConfig()
        {

            return name + " " + color + " " + privatefield;

        }

        public override bool Equals(object? obj)
        {
            var car = obj as Car;
            return car != null && name == car.name && color == car.color;
        }



    }
}

