namespace Delegate
{



    class Program
    {
       
        
        static void Main(string[] args)
        {
            // instance of the delegate types
            DelegateClass.DisplayDelegate displayDelegate; 
            DelegateClass.MathDelegate mathDelegate;
            
            // instance of the class
            DelegateClass delegateClassObject = new DelegateClass();
            
            // Void Delegate
            // call static string method
            displayDelegate = DelegateClass.displayString; 
            
            // Anonymous Function
            displayDelegate += delegate(string name)
            {
                Console.WriteLine("My name is: {0}", name);
            };
            // Statement Lambda
            displayDelegate += (String name) =>
            {
                Console.WriteLine("My name is: {0}", name);
            };
            // Expression Lambda
            displayDelegate -= (String name) => Console.WriteLine("My name is: {0}", name);
            
            // call it!
            displayDelegate("Paul");
            
            // int Delegate 
            // call static method
            mathDelegate = DelegateClass.addAndDisplay; 
            
            // call non static method 
            mathDelegate += delegateClassObject.multAndDisplay;
            
            // Anonymous Function 
            mathDelegate += delegate(int a, int b)
            {
                Console.WriteLine("The subtraction of {0} and {1} is {2}", a, b, a + b);
                return a - b;
            };
            
            // Statment Lambda
            mathDelegate -= (int a, int b) =>
            {
                Console.WriteLine("The sum of {0} and {1} is {2}", a, b, a + b);
                return a + b;
            };
            
            // Expression Lambda 
            mathDelegate += (int a, int b) =>  a+b;
            
            // Call it
            mathDelegate(1, 2);
            
            // Call my delegates
            delegateClassObject.CallDelegates(mathDelegate);
            
            
        }
    }
}