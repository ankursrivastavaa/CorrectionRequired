
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CorrectionRequired
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Function : Calculate the Closest Numbers");
            int[] arr3 = new int[] { -20, -3916237, -357920, -3620601, 7374819, -7330761, 30, 6246457, -6461594, 266854, -520, -470 };
            int[] answer1 = closestNumbers(arr3);
            for (int z2 = 0; z2 < answer1.Length; z2++)
            {
                Console.Write(answer1[z2]);
                if (z2 < answer1.Length - 1)
                {
                    Console.Write(" ,");
                }
            }
            Console.WriteLine();
            Console.ReadKey(true);
            Console.WriteLine("----------------------------------------------------------------------------------"); ;
        }

        public static int[] closestNumbers(int[] Arr)

        {
            int j = 0;
            int[] store = new int[Arr.Length + 10];

            Arr = Sort(Arr);                                                    // Sorting the array in acending order
            double oldmin = 1 / .000000001;                                      // Initialing oldmin with a value which tends to positive infinity

            for (int i = 0; i < Arr.Length - 1; i++)
            {

                double newmin = Arr[i] - Arr[i + 1];                        // taking the differnce between first element and second element

                newmin = check(newmin);                                     // checking for the absolute difference

                if (oldmin > newmin)
                {

                    oldmin = newmin;
                    store[j] = Arr[i];                                     // Storing the value of the first element in the array if the newmin is smaller than oldmin
                    j++;
                    store[j] = Arr[i + 1];                                  //Storing the value of the second element
                    j++;                                                    // Incrementing the value of j by 1 to store the elements in the "store" array


                }// end of IF

                else if (oldmin == newmin)
                {

                    store[j] = Arr[i];                                      // Same logic as above described
                    j++;
                    store[j] = Arr[i + 1];
                    j++;

                }//  end of else if

                else
                {
                    //Do Nothing
                }

            }// end of FOR 

            int[] final = new int[j];                               // This array will contain the final value that method return
            int[] recheck = new int[j];                             // This array is to recheck if all the pair of elements have same value of difference or not

            for (int i = 0; i < j; i++)
            {
                final[i] = store[i];                                // Populating the values of store in array "final" and "check" from the "store" array
                recheck[i] = store[i];

            }


            for (int i = 0; i < recheck.Length - 3; i = i + 2)                  // Hopping the value of i by 2, to pick the 1st, 3rd and so on numbers
            {

                int diff1 = recheck[i] - recheck[i + 1];
                int diff2 = recheck[i + 2] - recheck[i + 3];
                Console.WriteLine("diff1 = " + diff1);
                Console.WriteLine("diff2 = " + diff2);

                if (diff1 != diff2)                                                 // Checking if the difference bwteen first pair of elements is equal to second pair
                {
                    //closestNumbers(recheck);                                      // Tried to call the closest number function

                    Console.WriteLine("Needs to call once more the closestNumber function, but when it's called it's creating an infinite loop");
                }

                else
                    break;
            }
            return final;

        }// End of Method Closest Number


        static double check(double n)
        {
            if (n < 0)
            {
                n = n * -1;
                //Console.WriteLine("this is test");
            }
            return n;
        }// End of check method


        public static int[] Sort(int[] A)
        {
            int n = A.Length;
            for (int i = 0; i < n - 1; i++)                         //Using Bubble sort to sort the array
                for (int j = 0; j < n - i - 1; j++)
                    if (A[j] > A[j + 1])
                    {
                        // Using a temp variable to swap the values 
                        int temp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = temp;
                    }
            return A;

        }// End of Sort Method
    }
}