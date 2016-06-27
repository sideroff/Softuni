using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.LargerThanNeighbours
{
    class LargerThanNeighbourshw
    {
        static bool LargerThanNeighbours(int[] nums,int i)
        {
            if (i == 0) //if the element is a first in the sequence check with the next one
                {
                if ((nums[i] > nums[i + 1])) return true;
                return false;
                }

            if (i == nums.Length)  // if the element is the last in the sequence check with the previous one
                {
                if ((nums[i] > nums[i - 1])) return true;
                return false;
                }
            if ((nums[i - 1] < nums[i]) && (nums[i] > nums[i + 1])) return true; //any other elemenet is checked
                                                                                 //with both its neighbours
            else return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input numbers seperated by space: ");
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(LargerThanNeighbours(numbers,i));
            }

        }
    }
}
