using System;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    class SplashScreen
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;

        const int commonSpeed = 3;
        const int planetSpeed = 1;
        const int numOfPlanets = 1;
        const int numOfStars = 1;
        const int numOfAsteroids = 1;
        const int numOfSmallStars = 50;
        const int maxSize = 30;
        const int minSize = 10;
        const int planetSize = 600;


        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        static SplashScreen()
        {
        }

        public static void Load()
        {
            //Random rand = new Random();
            //_objs = new BaseObject[numOfStars + numOfAsteroids + numOfPlanets + numOfSmallStars];

            //for (int i = 0; i < _objs.Length - numOfStars - numOfPlanets - numOfAsteroids; i++)
            //{
            //    _objs[i] = new SmallStar(new Point(Convert.ToInt32(rand.NextDouble() * (double)SplashScreen.Width),
            //        Convert.ToInt32(rand.NextDouble() * (double)SplashScreen.Height)), new Point(rand.Next(-commonSpeed, -1), 0), new Size(1, 1));
            //}

            //for (int i = _objs.Length - numOfStars - numOfPlanets - numOfAsteroids; i < _objs.Length - numOfPlanets - numOfAsteroids; i++)
            //{
            //    int size = rand.Next(minSize / 2, maxSize / 2);
            //    _objs[i] = new Star(new Point(Convert.ToInt32(rand.NextDouble() * (double)SplashScreen.Width),
            //        Convert.ToInt32(rand.NextDouble() * (double)SplashScreen.Height)), new Point(rand.Next(-commonSpeed * 2, -1), 0), new Size(size, size));
            //}

            //for (int i = _objs.Length - numOfPlanets - numOfAsteroids; i < _objs.Length - numOfAsteroids; i++)
            //{
                
            //    _objs[i] = new Planet(new Point(300, 200), new Point(0, 0), new Size(planetSize, planetSize));
            //}

            //for (int i = _objs.Length - numOfAsteroids; i < _objs.Length; i++)
            //{
            //    int size = rand.Next(minSize, maxSize);
            //    _objs[i] = new BaseObject(new Point(Convert.ToInt32(rand.NextDouble() * (double)(SplashScreen.Width - size)),
            //        Convert.ToInt32(rand.NextDouble() * (double)(SplashScreen.Height - size))), new Point(rand.Next(-commonSpeed, commonSpeed),
            //        rand.Next(-commonSpeed, commonSpeed)), new Size(size, size));
            //}
        }

        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            //foreach (BaseObject obj in _objs)
            //    obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            //foreach (BaseObject obj in _objs)
            //    obj.Update();
        }


    }
}
