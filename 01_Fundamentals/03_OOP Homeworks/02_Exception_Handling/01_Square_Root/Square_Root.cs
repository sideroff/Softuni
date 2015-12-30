using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Square_Root
{
    class Square_Root
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
            
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Number must be positive");
            }
            catch (FormatException)
            {
                Console.WriteLine("Number must consist of atleast 1 digit.");
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("Number must be > int.MinSize and < int.MaxSize");
            }
            finally
            {
                Console.WriteLine("Good bye.");
            }
        }
        
    }
}
