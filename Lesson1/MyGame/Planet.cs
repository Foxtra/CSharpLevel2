using System;
using System.Collections.Generic;
using System.Drawing;

namespace MyGame
{
    class Planet : BaseObject
    {
        List<Bitmap> bitMapList = new List<Bitmap>() {
            new Bitmap("..\\..\\img/giants/star_blue_giant01.png"),
            new Bitmap("..\\..\\img/giants/star_red_giant01.png"), 
            new Bitmap("..\\..\\img/giants/star_white_giant03.png") };

        Bitmap image;
        

        public Planet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = bitMapList[random.Next(0,bitMapList.Count)];
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0 - Size.Width)
            {
                Pos.X = Game.Width + Size.Width;
                image = bitMapList[random.Next(0, bitMapList.Count)];
                Pos.Y = Convert.ToInt32(random.NextDouble() * (double)Game.Height);
                Size.Width = Convert.ToInt32((random.NextDouble() + 0.5) * Size.Width);
                Size.Height = Size.Width;
                Dir.X = Convert.ToInt32((random.NextDouble() + 0.5) * Dir.X);
            }
        }
    }
}
