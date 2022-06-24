namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car vw = new Car("VW", "Black");
            Car mercedes = new Car("Merced", "White");


            CarCollection carCollection = new CarCollection();
            carCollection.CarInserted += Cars_CarInserted;

            carCollection.Add(vw);
            carCollection.Add(mercedes);

            if (vw.isColorBlack())
            {
                Console.WriteLine("vw is Black");
            }



            // own Collection
            PrimeNumbers prim = new PrimeNumbers();

            foreach (var item in prim)
            {
                if (item is int i)
                    Console.WriteLine(i);
            }
            Console.ReadKey();

        
        }

        private static void Cars_CarInserted(Car c)
        {
            Console.WriteLine(c.Name + " is here!");
        }

    }


}

