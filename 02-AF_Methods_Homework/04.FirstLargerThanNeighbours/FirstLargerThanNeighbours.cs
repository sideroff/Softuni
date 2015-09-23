using System;
using System.Linq;

namespace _04.FirstLargerThanNeighbours
{
    class FirstLargerThanNeighbourshw
    {
        static bool FirstLargerThanNeighbours(int[] nums, int i)
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
            Console.WriteLine("Input number of sequence:");
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Input numbers seperated by space: ");
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                bool NumHasBiggerThanNeighbours = false;
                for (int k = 0; k < numbers.Length; k++)
                {
                    if(FirstLargerThanNeighbours(numbers, k)==true)
                        {
                            Console.WriteLine(numbers[k]);
                            NumHasBiggerThanNeighbours = true;                            
                            break;

                        }
                }
                if (NumHasBiggerThanNeighbours == false) Console.WriteLine("-1");

            }

        }
    }
}
