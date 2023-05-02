using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber.Helper
{
    public class PrimeNumberHelper
    {
        /// <summary>
        /// 判断某个数字是否为质数
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsPrimeNumber(UInt64 number)
        {
            //0，1单独处理（类型UInt64最小0）
            if (number < 2)
                return false;

            //2单独处理
            if (number == 2)
                return true;

            //遍历检查
            for (UInt64 i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
