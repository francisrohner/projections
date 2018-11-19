using Projection_Library.Classes;
using Projection_Library.Classes.Networking;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Projection_Server
{
    static class Program
    {
        #region ConsoleRedirection
        [DllImport("kernel32.dll",
        EntryPoint = "AllocConsole",
        SetLastError = true,
        CharSet = CharSet.Auto,
        CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateFile(
        string lpFileName,
        uint dwDesiredAccess,
        uint dwShareMode,
        uint lpSecurityAttributes,
        uint dwCreationDisposition,
        uint dwFlagsAndAttributes,
        uint hTemplateFile);

        private const int MY_CODE_PAGE = 437;
        private const uint GENERIC_WRITE = 0x40000000;
        private const uint FILE_SHARE_WRITE = 0x2;
        private const uint OPEN_EXISTING = 0x3;

        public static void CreateConsole()
        {
            AllocConsole();

            IntPtr stdHandle = CreateFile(
                "CONOUT$",
                GENERIC_WRITE,
                FILE_SHARE_WRITE,
                0, OPEN_EXISTING, 0, 0
            );

            SafeFileHandle safeFileHandle = new SafeFileHandle(stdHandle, true);
            FileStream fileStream = new FileStream(safeFileHandle, FileAccess.Write);
            Encoding encoding = System.Text.Encoding.GetEncoding(MY_CODE_PAGE);
            StreamWriter standardOutput = new StreamWriter(fileStream, encoding);
            standardOutput.AutoFlush = true;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetOut(standardOutput);

            //Console.Write("This will show up in the Console window.");
        }

        #endregion ConsoleRedirection

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Dictionary<string, string> settings = ParseArgs(args);
            //CreateConsole();
            //Console.WriteLine("Debug");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (settings.ContainsKey("frag") && File.Exists("collection.pm"))
                File.Delete("collection.pm");
            Projection_Server server = new Projection_Server(settings.ContainsKey("debug"));

            Application.Run(server);


            //Probe probe = new Probe();
            //probe.Scan();

            //AllocConsole
            //ProjectionManager pm = new ProjectionManager(true);
            //Console.ReadLine();
        }
        public static Dictionary<string, string> ParseArgs(string[] args)
        {
            if (args == null || args.Length < 1)
                return new Dictionary<string, string>();

            Dictionary<string, string> settings = new Dictionary<string, string>();
            string strArg = String.Concat(args);
            string[] strArr = strArg.Split('-');
            //Ex: -setting1 value1 -setting2 value2 -flag1
            //setting1 value1
            //setting2 value2
            //flag2
            foreach (string arg in strArr)
                if (String.IsNullOrEmpty(arg))
                    continue;
                else if (arg.Contains(" "))
                    settings.Add(arg.Split(' ')[0], arg.Split(' ')[1]);
                else
                    settings.Add(arg, "true");
            
            return settings;
        }

    }
}
