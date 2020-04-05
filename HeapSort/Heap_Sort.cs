﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    class Heap_Sort
    {
        static void Main(string[] args)
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            // Pirmas etapas
            Test_Array_List(seed);
        }

        public static void Heapify(DataArray arr, int n, int i) 
        { 
            int largest = i; // Initialize largest as root 
            int l = 2*i + 1; // left = 2*i + 1 
            int r = 2*i + 2; // right = 2*i + 2 
  
            // If left child is larger than root 
            if (l < n && arr[l] > arr[largest]) 
                largest = l; 
  
            // If right child is larger than largest so far 
            if (r < n && arr[r] > arr[largest]) 
                largest = r; 
  
            // If largest is not root 
            if (largest != i) 
            {
                arr.Swap(i, largest, arr[i],arr[largest]);
  
                // Recursively heapify the affected sub-tree 
                Heapify(arr, n, largest); 
            } 
        }

        public static void Heapify(DataList arr, int n, int i) 
        { 
            int largest = i; // Initialize largest as root 
            int l = 2*i + 1; // left = 2*i + 1 
            int r = 2*i + 2; // right = 2*i + 2 
  
            // If left child is larger than root 
            if (l < n && arr.IndexAt(l).data > arr.IndexAt(largest).data) 
                largest = l; 
  
            // If right child is larger than largest so far 
            if (r < n && arr.IndexAt(r).data > arr.IndexAt(largest).data) 
                largest = r; 
  
            // If largest is not root 
            if (largest != i) 
            {
                arr.Swap(i, largest);
  
                // Recursively heapify the affected sub-tree 
                Heapify(arr, n, largest); 
            } 
        }
        
        public static void HeapSort(DataArray items)
        {
            int n = items.Length; 
  
            // Build heap (rearrange array) 
            for (int i = n / 2 - 1; i >= 0; i--) 
                Heapify(items, n, i); 
  
            // One by one extract an element from heap 
            for (int i=n-1; i>=0; i--) 
            { 
                // Move current root to end 

                items.Swap(0, i, items[0], items[i]);
  
                // call max heapify on the reduced heap 
                Heapify(items, i, 0); 
            } 
        }

        public static void HeapSort(DataList items)
        {
            int n = items.Length;
            
            for (int i = n / 2 - 1; i >= 0; i--) 
                Heapify(items, n, i); 

            for (int i=n-1; i>=0; i--) 
            { 
                // Move current root to end 
                items.Swap(0, i);
  
                // call max heapify on the reduced heap 
                Heapify(items, i, 0); 
            }
        }
        

        public static void Test_Array_List(int seed)
        {
            int n = 12;
            MyDataArray myarray = new MyDataArray(n, seed);
            Console.WriteLine("\n ARRAY \n");
            myarray.Print(n);
            HeapSort(myarray);
            myarray.Print(n);

            MyDataList mylist = new MyDataList(n, seed);
            Console.WriteLine("\n LIST \n");
            mylist.Print(n);
            HeapSort(mylist);
            mylist.Print(n);
        }
    }
    abstract class DataArray
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract double this[int index] { get; }
        public abstract void Swap(int i, int j, double a, double b);
        public void Print(int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(" {0:F5} ", this[i]);
            Console.WriteLine();
        }
    }
    
    public abstract class DataList
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract double Head();
        public abstract double Next();
        public abstract void Swap(int index1, int index2);
        public abstract MyDataList.Node Find(double d);
        public abstract MyDataList.Node IndexAt(int index);
        public void Print(int n)
        {
            Console.Write(" {0:F5} ", Head());
            for (int i = 1; i < n; i++)
                Console.Write(" {0:F5} ", Next());
            Console.WriteLine();
        }
    }
}
