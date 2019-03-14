/*
 * Дана коллекция List<T>. Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
 * для целых чисел;
 * *для обобщенной коллекции;
 * ** используя Linq.
 * 
 * Сергей Ткачев
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует программа для подсчёта элементов в коллекции!");

            myList<int>.list.Add(1);
            myList<int>.list.Add(2);
            myList<int>.list.Add(1);
            myList<int>.list.Add(7);
            myList<int>.list.Add(1);
            myList<int>.list.Add(9);
            myList<int>.list.Add(7);
            myList<int>.list.Add(2);
            myList<int>.list.Add(9);

            Console.WriteLine("\nСоздан следующий список элементов:");
            myList<int>.Print();

            Console.WriteLine("\nПодсчитаем количество элементов в нём!");

            foreach(KeyValuePair<int,int> item in myList<int>.GetStatistic())
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }

            Console.WriteLine("\nПодсчитаем количество элементов при помощи linq:");

            var orderedItems = myList<int>.list.GroupBy(l => l);

            foreach (var item in orderedItems)
                Console.WriteLine($"{item.Key} : {item.Count()}");

            Console.ReadLine();
        }
    }
}
