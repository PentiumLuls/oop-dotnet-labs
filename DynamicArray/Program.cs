using System;

namespace DynamicArray
{
    class Program
    {
        public static void Main(string[] args)
        {
            var array = new DynamicArray<int>(1, 2, 3, 4);
            Console.Clear();
            Console.WriteLine("initialized array: " + string.Join(", ", array));
 
            array += 5;
            array = 0 + array + 6;
            Console.WriteLine("after adding a few elements: " + string.Join(", ", array));
 
            array--;
            array -= 2;
            Console.WriteLine("After removing a few elements: " + string.Join(", ", array));

            int index = 2;
            Console.WriteLine("Element at index " + index + " is: " + array[2]);
            try
            {
                Console.WriteLine(array[100]);
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}