/*
 * 1. Построить три класса (базовый и 2 потомка), описывающих двух работников: с почасовой оплатой (один из потомков)
 * и фиксированной оплатой (второй потомок).
 * а) Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы. 
 * Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка».
 * Для работников с фиксированной оплатой: «среднемесячная заработная плата = фиксированная месячная оплата».
 * б) Создать на базе абстрактного класса массив сотрудников и заполнить его.
 * в) *Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort().
 * г) *Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных с использованием foreach.
 * 
 * Сергей Ткачёв
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Workers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует программа вывода отсортированного массива сотрудников");

            int numberOfWorkers = 20;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine(Environment.NewLine+"Создадим список сотрудников:");

            ArrayOfWorkers arr = new ArrayOfWorkers();

            arr.Init(numberOfWorkers);

            arr.Print();

            Console.WriteLine(Environment.NewLine+"Отсортируем список по зарплате:");

            arr.Sort();
            arr.Print();

            Console.ReadKey();
        }
    }
}
