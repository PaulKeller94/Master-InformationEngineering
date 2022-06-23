namespace Funfair
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<MyRides> myRides = new List<MyRides>();
            myRides.Add(new MyRides("Rollercoaster", 40000, 500, 800, 7));
            myRides.Add(new MyRides("Ghosttrain", 10000, 300, 1200, 5));
            myRides.Add(new MyRides("Water-ride", 30000, 800, 300, 6.40));
            myRides.Add(new MyRides("Freefall-Tower", 20000, 100, 200, 10));
            myRides.Add(new MyRides("Children Carousel", 5000, 100, 300, 2.50));

            // a.)
            double fixedYearlyCosts = myRides.Select(s => s.Costs_per_year).Sum();

            // b.)
            double[] dailyRevenue = myRides.Select(x => x.Costs_per_day * x.Visitors_per_day).ToArray();

            // c.)
            double[] benefit200 = myRides.Select(r => (r.Price_per_ticket * r.Visitors_per_day - r.Costs_per_day) * 200 - r.Costs_per_year).ToArray();

            // d.)
            List<string> NamesOfBenificalRide = myRides.OrderBy(x => (x.Price_per_ticket * x.Visitors_per_day - x.Costs_per_day) * 200 - x.Costs_per_year).Select(r => r.Designation).ToList();

            // unsinn
            String[] unsinn = myRides.Select(h => "huhu").ToArray(); // gibt ein string arrray zurück mit 5 mal HUHU, da 5 Objekte 

            // sinn
            string[] sinn = myRides.Select(h => h.Designation).ToArray();


            // Where

            // if (newData != null) { newData(voltages.Where((i, x) => (i < 960)).ToArray());  };

            String[] getGhostTrain = myRides.Where(h => h.Designation == "Ghosttrain").Select(r => r.Designation).ToArray();

            int[] getNumberHigher2 = new int[3] { 2, 3, 5 };

            int[] result = getNumberHigher2.Where(x => x > 2).ToArray();

            double avgPricePerDay = myRides.Select(x => x.Price_per_ticket).Average();

            double[] highestPricePerTicket = myRides.Where(x => x.Price_per_ticket > avgPricePerDay).Select(y => y.Price_per_ticket).ToArray();


        }


    }
}
