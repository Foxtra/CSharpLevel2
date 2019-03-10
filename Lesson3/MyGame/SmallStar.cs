using System;
using System.Drawing;

namespace MyGame
{
    class SmallStar : BaseObject
    {
        /// <summary>Инициализирует объект SmallStar при помощи базового конструктора BaseObject</summary>
        /// <param name="pos">Местонахождение</param>
        /// <param name="dir">Направление</param>
        /// <param name="size">Размер</param>
        public SmallStar(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>Метод отрисовки объекта</summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillRectangle(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>Метод обновления местоположения объекта</summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0 - Size.Width)
            {
                Pos.X = Game.Width + Size.Width;
                Pos.Y = Convert.ToInt32((myRandom.RandomDoubleNumber()* (0.9 - 0.1) + 0.1) * (double)Game.Height);
            }
        }
    }
}
