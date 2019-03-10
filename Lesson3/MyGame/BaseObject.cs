using System;
using System.Drawing;

namespace MyGame
{
    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        public delegate void Message();

        /// <summary>Инициализирует объект BaseObject</summary>
        /// <param name="pos">Позиция</param>
        /// <param name="dir">Направление</param>
        /// <param name="size">Размер</param>
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        /// <summary>Метод отрисовки объекта</summary>
        public abstract void Draw();


        /// <summary>Метод обновления местоположения объекта</summary>
        public abstract void Update();


        /// <summary>Возвращает истину, если произашло пересечение объектов</summary>
        /// <param name="o">Объект, реализующий ICollision</param>
        /// <returns></returns>
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);

        public Rectangle Rect => new Rectangle(Pos, Size);

    }
}

