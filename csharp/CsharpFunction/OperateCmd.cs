using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//process
using System.Diagnostics;

namespace CsharpFunction
{
    /*
     * 功能
     * 操作cmd命令提示符，操作其他程序的运行与停止
     * Epulari T 
     * 2018.4.7
     */
    class OperateCmd
    {
        /// <summary>
        /// 调用cmd
        /// </summary>
        /// <param name="arg">执行语句arg = a + " && " + b + " && " + c  多条命令一次执行</param>
        public void CmdExcute(string arg)
        {
            Process theProcess = new Process();
            theProcess.StartInfo.FileName = "cmd.exe";    //设置要启动的应用程序      
            theProcess.StartInfo.UseShellExecute = false;  //设置是否使用操作系统shell启动进程，当要使用标准输入输出流时要设置为false      
            theProcess.StartInfo.RedirectStandardInput = true;  //指示应用程序是否从StandardInput流中读取      
            theProcess.StartInfo.RedirectStandardOutput = true; //将应用程序的输入写入到StandardOutput流中      
            theProcess.StartInfo.RedirectStandardError = true;  //将应用程序的错误输出写入到StandarError流中      
            theProcess.StartInfo.CreateNoWindow = false;    //是否在新窗口中启动进程     

            string strOutput = null;
            try
            {
                theProcess.Start();
                //将cmd命令写入StandardInput流中。在命令最后要执行退出进程命令：exit，如果不执行它，后面调用ReadToEnd()方法会假死
                theProcess.StandardInput.WriteLine(arg + " & exit");
                //strOutput = theProcess.StandardOutput.ReadToEnd(); //读取所有输出的流的所有字符  
                theProcess.WaitForExit(); //无限期等待，直至进程退出     
                theProcess.Close();  //关闭进程，释放进程    

                //Console.WriteLine(strOutput); //输出进程的输出内容  
            }
            catch (Exception e)
            {
                strOutput = e.Message;
            }
        }

        /// <summary>
        /// 调用其他进程
        /// </summary>
        /// <param name="exepath">进程路径 @"D:\Program Files\PostgreSQL\9.5\bin\pg_restore.exe"</param>
        /// <param name="arg">执行语句</param>
        public void ExeExcuteFollowup(string exepath, string arg)
        {
            Process theProcess = new Process();
            theProcess.StartInfo.FileName = exepath;  
            theProcess.StartInfo.Arguments = arg;    
            theProcess.Start();//启动程序  
        }

        /// <summary>
        /// 调用其他进程，并且结束后执行其他操作
        /// </summary>
        /// <param name="exepath">进程路径 @"D:\Program Files\PostgreSQL\9.5\bin\pg_restore.exe"</param>
        /// <param name="arg">执行语句</param>
        public void ExeExcute(string exepath, string arg)
        {
            Process theProcess = new Process();
            theProcess.StartInfo.FileName = exepath;  
            theProcess.StartInfo.Arguments = arg;  
            theProcess.EnableRaisingEvents = true;//为true时为进程终止时激发System.Diagnostics.Process.Exited事件  
            //进程退出时执行
            theProcess.Exited += (object sender, EventArgs args) =>  //Lambda表达式  
            {  
                //……  
            };
            theProcess.Start();//启动程序  
            theProcess.WaitForExit();//等待进程退出  
        }
    }
}
