using System;
namespace Tomas
{
    class Program
    {
        static void Main(string[] args)
        {
            initOperation();
        }

        static void initOperation()
        { 
            var numCases = NumCases();
            
            var tomas = new string[numCases];
            
            for (int i = 0; i < numCases; i++)
            {
                tomas[i] = Console.ReadLine();
                
            }

            Slots(tomas);
              
        }

     static int NumCases()
        {
            var isValid = false;
            var numCases = 0;
            while(!isValid || numCases <= 0)
            {
                System.Console.WriteLine("Please, enter a number greater than cero");
                isValid = ValidateNumber(Console.ReadLine() ?? string.Empty, out numCases);
                if(!isValid) System.Console.WriteLine("Not valid number!");
            } 
            return numCases;
        }    
        static bool ValidateNumber(string numberToValidate , out int number)
        {
            return   int.TryParse(numberToValidate, out number) && number > 0; 
             
        }

        static void Slots(string[] tomas)
        {
            foreach (var toma in tomas)
            {
                var items = toma.Split(" ");
                var count = 0;
                var validated = ValidateNumber(items[0], out count);
                if(!validated || items.Length - 1 != count) ShowGenericError();

                var total = items.Aggregate(2, (acc, n) => acc + (int.Parse(n) - 1 ));
                var result = total - int.Parse(items[0]) ; 
                System.Console.WriteLine(result  );

            }
        }

        static void ShowGenericError(){

             System.Console.WriteLine("Something went wrong. Please try again");
             Environment.Exit(0);
         
        }
    }
}