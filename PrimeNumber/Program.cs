using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeNumber.WinForm.OneThread
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region MyRegion

            //32767
            Console.WriteLine(Int16.MaxValue);
            Console.WriteLine(UInt16.MaxValue);

            //2147483647
            Console.WriteLine(Int32.MaxValue);
            Console.WriteLine(int.MaxValue);
            //4294967295
            Console.WriteLine(UInt32.MaxValue);
            Console.WriteLine(uint.MaxValue);

            //9223372036854775807
            Console.WriteLine(Int64.MaxValue);
            Console.WriteLine(long.MaxValue);
            //18446744073709551615
            Console.WriteLine(UInt64.MaxValue);
            Console.WriteLine(ulong.MaxValue);

            //79228162514264337593543950335
            Console.WriteLine(decimal.MaxValue);

            //3.40282347E+38F
            Console.WriteLine(Single.MaxValue);
            Console.WriteLine(float.MaxValue);

            //1.7976931348623157E+308
            Console.WriteLine(double.MaxValue);
            #endregion


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainForm());
        }
    }
}
