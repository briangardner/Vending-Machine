using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo
{
    class Program
    {
        //private static Queue<string> _vendingMachine;
        private static Stack<string> _vendingMachine;
        static void Main(string[] args)
        {
            //_vendingMachine = new Queue<string>();
            _vendingMachine = new Stack<string>();
            do
            {
                Console.WriteLine("Do you want to (stock), (view), or (buy):");
                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "stock":
                        StockVendingMachine();
                        break;
                    case "view":
                        ViewNextProduct();
                        break;
                    case "buy":
                        try
                        {
                            var candy = GetCandy();
                            Console.WriteLine($"You got a piece of {candy}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    default:
                        Console.WriteLine("Please select valid option.");
                        break;
                }

                if (!ShouldContinue())
                {
                    break;
                }
            } while (true);
        }

        private static bool ShouldContinue()
        {
            do
            {
                Console.WriteLine("Continue y/n:");
                var input = char.ToLower(Console.ReadKey().KeyChar);
                if(input != 'y' && input != 'n')
                    continue;
                return input == 'y';
            } while (true);

        }

        private static string GetCandy()
        {
            if (_vendingMachine.Count > 0)
            {
                return _vendingMachine.Pop();
                //return _vendingMachine.Dequeue();
            }
            throw new Exception("Out of candy!!! OH NO!");
        }

        private static void ViewNextProduct()
        {
            if (_vendingMachine.Count > 0)
            {
                Console.WriteLine(_vendingMachine.Peek());
            }
            else
            {
                Console.WriteLine("Out Of Stock");
            }
        }

        private static void StockVendingMachine()
        {
            Console.WriteLine("What do you want to add to the vending machine");
            var itemToAdd = Console.ReadLine();
            //_vendingMachine.Enqueue(itemToAdd);
            _vendingMachine.Push(itemToAdd);
        }
    }
}
