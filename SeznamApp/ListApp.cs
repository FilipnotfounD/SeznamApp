using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeznamApp
{
    public class ListApp
    {
        public void Run()
        {
            var list = new List();
            list.Init();

            bool proceed = true;

            while (proceed)
            {
                Console.WriteLine("Zvolte operaci: init, isEmpty, getItem, toLeft, toRight, insertLeft, insertRight, removeActual, removeTail, writeAll, exit");
                PrintDeLimiter();
                var input = Console.ReadLine();
                PrintDeLimiter();

                if (input == "init")
                {
                    list.Init();
                    Console.WriteLine("Seznam byl inicializován.");
                }
                else if (input == "isEmpty")
                {
                    Console.WriteLine(list.IsEmpty() ? "Seznam je prázdný." : "Seznam není prázdný.");
                }
                else if (input == "getItem")
                {
                    Console.WriteLine($"Aktuální prvek: {list.GetItem()}");
                }
                else if (input == "toLeft")
                {
                    list.ToLeft();
                }
                else if (input == "toRight")
                {
                    list.ToRight();
                }
                else if (input == "insertLeft")
                {
                    Console.WriteLine("Zadejte hodnotu:");
                    var valueLeft = SafelyConvertToInt(Console.ReadLine()!);
                    list.InsertToLeft(valueLeft);
                }
                else if (input == "insertRight")
                {
                    Console.WriteLine("Zadejte hodnotu:");
                    var valueRight = SafelyConvertToInt(Console.ReadLine()!);
                    list.InsertToRight(valueRight);
                }
                else if (input == "removeActual")
                {
                    list.RemoveActual();
                    Console.WriteLine("Aktuální prvek byl odstraněn.");
                }
                else if (input == "removeTail")
                {
                    list.RemoveTail();
                    Console.WriteLine("Poslední prvek byl odstraněn.");
                }
                else if (input == "writeAll")
                {
                    list.WriteAll();
                }
                else if (input == "exit")
                {
                    proceed = false;
                }
                else
                {
                    Console.WriteLine("Neznámá operace.");
                }
            }
        }
        public int SafelyConvertToInt(string input)
        {
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }
        public void PrintDeLimiter()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
        }
    }
}
