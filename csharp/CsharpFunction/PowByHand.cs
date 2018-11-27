using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Pow by hand
using System.Diagnostics;

namespace CsharpFunction
{
    /*
     * 功能
     * 模拟手算m^n的实现方法
     * Epulari T 
     * 2018.4.7
     */
    class PowByHand
    {
        public void PowHand()
        {
            int baseNum;
            Console.Write("请输入底数:");
            baseNum = Convert.ToInt32(Console.ReadLine());
            int testN;
            Console.Write("请输入指数:");
            testN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("科学计数法结果:" + Math.Pow(baseNum, testN).ToString());
            int[] result = Power(baseNum, testN);
            Console.WriteLine("计算结果:");
            for (int i = result.Length - 1; i >= 0; i--)
            {
                Console.Write(result[i]);
            }
            Console.ReadKey();
        }

        int[] Power(int baseNum, int n)
        {
            int[] result;
            if (n < 0)
            {
                throw new Exception("现在还不支持负指数");
            }
            if (n == 0)
            {
                result = new int[1];
                result[0] = 1;
                return result;
            }
            //获得结果位数
            int size = (int)(n * Math.Log10(baseNum)) + 1;
            result = new int[size];
            result[0] = 1;
            for (int i = 0; i < n; i++)
            {
                int totalBit = 0;//最高位
                for (int j = result.Length - 1; j >= 0; j--)
                {
                    if (result[j] > 0)
                    {
                        totalBit = j + 1; //获得最高位
                        break;
                    }
                }
                Debug.Assert(totalBit != 0);
                for (int k = totalBit - 1; k >= 0; k--)
                {
                    //从高位到低位开始算
                    int temp = result[k] * baseNum;
                    //产生一个进位
                    if (temp >= 10)
                    {
                        //向高位进位，模拟手算
                        result[k + 1] += temp / 10;
                        //检查该位是否还需要进位
                        CheckCarray(result, k + 1);
                        temp %= 10;
                    }
                    result[k] = temp;
                }
            }
            Console.WriteLine("位数：" + size);
            return result;
        }
        void CheckCarray(int[] m, int n)
        {
            if (m[n] >= 10)
            {
                //向高位进位，模拟手算
                m[n + 1] += m[n] / 10;
                //设置当前位
                m[n] %= 10;
                //检查下一个位时候需要进位
                CheckCarray(m, n + 1);
            }
        }
    }
}
