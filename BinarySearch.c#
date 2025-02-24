using System;

class Binary
{
    static int BinarySearch(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
                return mid; // Found the target

            if (arr[mid] < target)
                left = mid + 1; // Searching the right half
            else
                right = mid - 1; // Searching the left half
        }

        return -1; // if target not found
    }

    static void Main()
    {
        int[] arr = { 2, 5, 8, 12, 16, 23, 38, 45, 56, 72 };
        Console.Write("Enter the number to search: ");
        int target = int.Parse(Console.ReadLine());

        int result = BinarySearch(arr, target);

        if (result != -1)
            Console.WriteLine($"Element found at index {result}");
        else
            Console.WriteLine("Element not found in the array");
    }
}
