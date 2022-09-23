﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program4
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            // This is an example of how you'd initialize the object
            NavigationSystem GPS = new NavigationSystem(4, 5);
            GPS.PrintMap();
            GPS.EvaluateGuess(0, 0);
            GPS.PrintMap();
        }
    }
}
