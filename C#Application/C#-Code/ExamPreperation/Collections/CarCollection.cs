using System;
using System.Collections.ObjectModel;
namespace Collections
{
    public delegate void carInserted(Car c);
    public class CarCollection : Collection<Car>
    {
        public CarCollection()
        {
        }
        public event carInserted CarInserted;

        protected override void InsertItem(int index, Car item)
        {
            if (CarInserted != null) CarInserted(item);
            base.InsertItem(index, item);
        }
    }
}

