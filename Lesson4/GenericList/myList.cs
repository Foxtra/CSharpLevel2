using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class myList<T>
    {

        public static List<T> list = new List<T>();

        /// <summary>Возвращает частотный словарь</summary>
        /// <returns></returns>
        public static Dictionary<T, int> GetStatistic()
        {
            Dictionary<T, int> result = new Dictionary<T, int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (result.ContainsKey(list[i]))
                    result[list[i]]++;
                else
                    result.Add(list[i], 1);
            }

            return result;
        }

        /// <summary>Выводит элементы списка на экран</summary>
        public static void Print()
        {
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }

    }
}
