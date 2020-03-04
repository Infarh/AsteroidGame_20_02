using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AsteroidGame.VisualObjects;
using AsteroidGame.VisualObjects.Interfaces;

namespace AsteroidGame
{
    static class Game
    {
        /// <summary>Таймаут отрисовки одной сцены</summary>
        private const int __FrameTimeout = 10;

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;
        private static Timer __Timer;

        public static event Action<string> Log;

        public static int Width { get; set; }

        public static int Height { get; set; }

        public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;

            __Context = BufferedGraphicsManager.Current;
            var g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            var timer = new Timer { Interval = __FrameTimeout };
            timer.Tick += OnTimerTick;
            timer.Start();
            __Timer = timer;

            form.KeyDown += OnFormKeyDown;

            Log?.Invoke("Выполнена инициализация");
        }

        private static int __CtrlKeyPressed;
        private static int __UpKeyPressed;
        private static int __DownKeyPressed;
        private static void OnFormKeyDown(object Sender, KeyEventArgs E)
        {
            switch (E.KeyCode)
            {
                case Keys.ControlKey:
                    //__Bullet = new Bullet(__Ship.Position.Y);
                    //__Bullets.Add(new Bullet(__Ship.Position.Y));
                    __CtrlKeyPressed++;
                    break;

                case Keys.Up:
                    //__Ship.MoveUp();
                    __UpKeyPressed++;
                    break;

                case Keys.Down:
                    //__Ship.MoveDown();
                    __DownKeyPressed++;
                    break;
            }

            Log?.Invoke($"Нажата кнопка {E.KeyCode}");
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        private static SpaceShip __Ship;
        private static VisualObject[] __GameObjects;
        //private static Bullet __Bullet;
        private static readonly List<Bullet> __Bullets = new List<Bullet>();
        public static void Load()
        {
            Log?.Invoke("Загрузка данных сцены...");

            var game_objects = new List<VisualObject>();
            var rnd = new Random();

            const int stars_count = 150;
            const int star_size = 5;
            const int star_max_speed = 20;
            for (var i = 0; i < stars_count; i++)
                game_objects.Add(new Star(
                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, star_max_speed), 0),
                    star_size));
            Log?.Invoke($"Создано звёзд {stars_count}");

            const int asteroids_count = 10;
            const int asteroid_size = 25;
            const int asteroid_max_speed = 20;
            for (var i = 0; i < asteroids_count; i++)
                game_objects.Add(new Asteroid(
                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, asteroid_max_speed), 0),
                    asteroid_size));
            Log?.Invoke($"Астероидов создано {asteroids_count}");

            __GameObjects = game_objects.ToArray();
            //__Bullet = new Bullet(200);
            __Ship = new SpaceShip(new Point(10, 400), new Point(5, 5), new Size(10, 10));
            __Ship.ShipDestroyed += OnShipDestroyed;

            Log?.Invoke("Загрузка данных сцены выполнена успешно");
        }

        private static void OnShipDestroyed(object Sender, EventArgs E)
        {
            __Timer.Stop();
            __Buffer.Graphics.Clear(Color.DarkBlue);
            __Buffer.Graphics.DrawString("Game over!!!", new Font(FontFamily.GenericSerif, 60, FontStyle.Bold), Brushes.Red, 200, 100);
            __Buffer.Render();

            Log?.Invoke("Корабль уничтожен");
        }

        /// <summary>Метод визуализации сцены</summary>
        public static void Draw()
        {
            if (__Ship.Energy <= 0) return;
            var g = __Buffer.Graphics;
            g.Clear(Color.Black);

            foreach (var visual_object in __GameObjects)
                visual_object?.Draw(g);

            //__Bullet?.Draw(g);
            foreach (var bullet in __Bullets) bullet.Draw(g);
            __Ship.Draw(g);

            g.DrawString($"Energy: {__Ship.Energy}", new Font(FontFamily.GenericSansSerif, 14, FontStyle.Italic), Brushes.White, 10, 10);

            __Buffer.Render();
        }

        /// <summary>Обновление состояния объектов сцены</summary>
        public static void Update()
        {
            if (__CtrlKeyPressed > 0)
            {
                for (var i = 0; i < __CtrlKeyPressed; i++)
                    __Bullets.Add(new Bullet(__Ship.Position.Y));
                __CtrlKeyPressed = 0;
            }

            if (__UpKeyPressed > 0)
            {
                for (var i = 0; i < __UpKeyPressed; i++)
                    __Ship.MoveUp();

                __UpKeyPressed = 0;
            }

            if (__DownKeyPressed > 0)
            {
                for (var i = 0; i < __DownKeyPressed; i++)
                    __Ship.MoveDown();

                __DownKeyPressed = 0;
            }

            foreach (var visual_object in __GameObjects)
                visual_object?.Update();

            var bullets_to_remove = new List<Bullet>();
            foreach (var bullet in __Bullets)
            {
                bullet.Update();
                if (bullet.Position.X > Width)
                    bullets_to_remove.Add(bullet);
            }
            //__Bullet?.Update();

            for (var i = 0; i < __GameObjects.Length; i++)
            {
                var obj = __GameObjects[i];
                if (obj is ICollision) // Применить "сопоставление с образцом"!
                {
                    var collision_object = (ICollision)obj;
                    __Ship.CheckCollision(collision_object);
                    foreach (var bullet in __Bullets.ToArray())
                        if (bullet.CheckCollision(collision_object))
                        {
                            bullets_to_remove.Add(bullet);
                            __GameObjects[i] = null;
                            MessageBox.Show("Астероид уничтожен!", "Столкновение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    //if (__Bullets.Any(b => b.CheckCollision(collision_object)))
                    //{
                    //    __GameObjects[i] = null;
                    //    MessageBox.Show("Астероид уничтожен!", "Столкновение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //}
                    //foreach (var bullet in __Bullets.Where(b => b.CheckCollision(collision_object)))
                    //    __Bullets.Remove(bullet);
                }
            }

            foreach (var bullet in bullets_to_remove)
                __Bullets.Remove(bullet);
        }
    }
}
