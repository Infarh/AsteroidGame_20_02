﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new Form();
            form.Width = 1200;
            form.Height = 900;
           
            //Зачем нужен?
            form.Show();  

            Game.Initialize(form);
            Game.Load();
            Game.Draw();

            Application.Run(form);
            
        }

        
    }
}
