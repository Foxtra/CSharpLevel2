/*
 * 1. Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон, 
 * похожий на полет в звездном пространстве.
 * 2. *Заменить кружочки картинками, используя метод DrawImage.
 * 3. *Разработать собственный класс Заставка SplashScreen, аналогичный классу Game. Создайте в нем собственную иерархию объектов и задайте их движение. Предусмотреть кнопки «Начало игры», «Рекорды», «Выход». Добавить на заставку имя автора.
 * 
 * Сергей Ткачёв
 */

using System;
using System.Windows.Forms;

namespace MyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }

}
