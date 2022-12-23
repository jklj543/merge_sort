using System;

namespace merge_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Merge Sort\n");
            Console.Write("*-----------------------------------------*\n");

            Console.Write("Enter the size of array: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            int i;

            Console.Write("\nEnter elements in array :\n");
            for (i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("\nBefore sorting: ");
            for (i = 0; i < n; i++)
            {
                Console.Write("{0}  ", arr[i]);
            }

            merge_sort(arr, 0, n - 1);

            Console.Write("\nAfter sorting: ");
            for (i = 0; i < n; i++)
            {
                Console.Write("{0}  ", arr[i]);
            }
            Console.Write("\n");
        }


        //----------------------------------------------------------------------------------

        static int[] merge_sort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                merge_sort(arr, low, mid);        //sort left arr[l---mid]
                merge_sort(arr, mid + 1, high);   //sort right arr[mid+1---r]
                merge(arr, low, mid, high);       //combine/merge 2 sorted arr
            }

            return arr;
        }

        static void merge(int[] arr, int low, int mid, int high)
        {
            int l = low;      //index of lift arr[l---mid]
            int r = mid + 1;  //index of right arr[mid+1---r]
            int[] sorted_arr = new int[high - low + 1];    //arr of solution of merging left and right arr
            int k = 0;        //index of sorted_arr

            //comparesion between elements of left and right arr
            while ((l <= mid) && (r <= high))
            {
                if (arr[l] < arr[r])
                {
                    sorted_arr[k] = arr[l];
                    l++;
                }
                else
                {
                    sorted_arr[k] = arr[r];
                    r++;
                }

                k++;
            }

            //add remaining items into sorted arr
            for (int i = l; i <= mid; i++)
            {
                sorted_arr[k] = arr[i];
                k++;
            }

            for (int i = r; i <= high; i++)
            {
                sorted_arr[k] = arr[i];
                k++;
            }

            //overwrite arr (change unsorted arr with sorted arr)
            for (int i = 0; i < sorted_arr.Length; i++)
            {
                arr[low + i] = sorted_arr[i];
            }
        }
    }
}
