using Projection_Library.Classes.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Projection
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Debug
            //Probe probe = new Probe();
            //probe.Scan();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ProjectorMain());
        }
    }
}
