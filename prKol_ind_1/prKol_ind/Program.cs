using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace prKol_ind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string task1 = "task1.txt";
            if (File.Exists(task1))
            {
                string text = File.ReadAllText(task1);
                Stack<char> functions = new Stack<char>();
                Stack<int> numbers = new Stack<int>();

                foreach (char symbol in text)
                {
                    if (Char.IsLetter(symbol))
                        functions.Push(symbol);
                    if (Char.IsDigit(symbol))
                        numbers.Push(Int32.Parse(symbol.ToString()));
                    if (symbol == ')')
                        if (functions.Peek() == 'm')
                        {
                            functions.Pop();
                            int a = numbers.Pop();
                            int b = numbers.Pop();
                            numbers.Push(Math.Min(a, b));
                        }
                        else
                        {
                            functions.Pop();
                            int a = numbers.Pop();
                            int b = numbers.Pop();
                            numbers.Push(Math.Max(a, b));
                        }
                }

                Console.WriteLine(numbers.Peek());
            }

            Console.ReadLine();
        }
    }
}
