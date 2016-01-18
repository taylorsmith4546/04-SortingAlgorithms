using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _04_SortingAlgorithms
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading file..");
            int[] list = readFromFile();
            Console.WriteLine("File loaded.");
            Console.WriteLine("Choose a sorting algorithm");
            Console.WriteLine();
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Insertion Sort");
            Console.WriteLine();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    bubbleSort(list);
                    break;
                case "2":
                    insertionSort(list);
                    break;
                default:
                    Console.WriteLine("Not a valid choice");
                    break;
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        static int[] readFromFile()
        {
            string fileContents = File.ReadAllText(@"C:\Dev\Data\unsorted-numbers.txt");
            string[] stringArr = fileContents.Split(',');

            int[] List = new int[stringArr.Length];

            for (int i = 0; i < stringArr.Length; i++)
            {
                List[i] = int.Parse(stringArr[i]);
            }
            return List;
        }


        static void bubbleSort(int[] list)
        {
            printList("Unsorted List", list);

            for (int i = 1; i <= list.Length - 1; i++)
            {
                for (int j = 0; j < (list.Length - 1); j++)
                {
                    if (list[j + 1] < list[j])
                    {
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }

            printList("Sorted list", list);
        }

        static void insertionSort(int[] list)
        {
            printList("Unsorted List", list);

            int temp;
            int j;

            for (int i = 1; i < list.Length; i++)
            {
                temp = list[i];

                j = i - 1;

                while (j >= 0 && list[j] > temp)
                {
                    list[j + 1] = list[j];

                    j--;
                }

                list[j + 1] = temp;
            }

            printList("Sorted list", list);
        }

        static void printList(string listName, int[] list)
        {
            Console.WriteLine("-- " + listName + " --");
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + ", ");
            }
            Console.WriteLine();
        }
    }
}
