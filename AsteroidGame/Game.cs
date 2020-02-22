using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Game
    {
        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        public static int Width { get; set; }

        public static int Height { get; set; }

        //static Game()
        //{

        //}

        public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            var timer = new Timer { Interval = 100 };
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        private static VisualObject[] __GameObjects;
        private static VisualObject[] __BackObjects;

        public static void Load()
        {
            Random random = new Random();
            double a;
            int l;

            __GameObjects = new VisualObject[30];
            for (var i = 0; i < __GameObjects.Length / 2; i++)
                __GameObjects[i] = new VisualObject(
                    new Point(600, i * 20),
                    new Point(15 - i, 20 - i),
                    new Size(20, 20));

            for (var i = __GameObjects.Length / 2; i < __GameObjects.Length; i++)
                __GameObjects[i] = new Star(
                    new Point(600, i * 20),
                    new Point(- i, 0),
                    20);
            __BackObjects = new Line[50];
            for (var i = 0; i < __BackObjects.Length; i++)
            {
                a = Math.PI * random.Next(360) / 180.0 ;
                l = random.Next(300);
                __BackObjects[i] = new Line(
               new Point( (int)(400 + l * Math.Sin(a))  , (int)(300+ l * Math.Cos(a)) ),
               new Point((int)(10.0 * Math.Sin(a)), (int)(10.0 * Math.Cos(a))),
               new Size(1, 1));
            }
        }

        public static void Draw()
        {
            var g = __Buffer.Graphics;
                 g.Clear(Color.Black);

            //g.DrawRectangle(Pens.White, new Rectangle(50, 50, 200, 200));
            //g.FillEllipse(Brushes.Red, new Rectangle(100, 50, 70, 120));

            foreach (var visual_object in __GameObjects)
                visual_object.Draw(g);

            foreach (var visual_object in __BackObjects)
                visual_object.Draw(g);

            __Buffer.Render();
        }

        public static void Update()
        {
            foreach (var visual_object in __GameObjects)
                visual_object.Update();
            foreach (var visual_object in __BackObjects)
                visual_object.Update();
        }

    }
}
