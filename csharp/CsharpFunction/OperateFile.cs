using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//file
using System.IO;

namespace CsharpFunction
{
    /*
     * 功能
     * 操作文件：创建 删除 查找并打开 移动 复制 重命名 追加内容
     * Epulari T 
     * 2018.4.3
     */
    class OperateFile
    {
        /// <summary>
        /// Create file.
        /// </summary>
        /// <param name="fullname">The file name include absolute paths and extension name.</param>
        public void CreateFile(string fullname)
        {
            if (!File.Exists(fullname))
            {
                File.Create(fullname);
            }
            else
            {
                Console.Write("The file already exists!");
            }
        }

        /// <summary>
        /// Delete file.
        /// </summary>
        /// <param name="fullname">The file name include absolute paths and extension name.</param>
        public void DeleteFile(string fullname)
        {
            if (File.Exists(fullname))
            {
                File.Delete(fullname);
            }
            else
            {
                Console.Write("The file does not exist!");
            }
        }

        /// <summary>
        /// Search and open file .
        /// </summary>
        /// <param name="fullname">The file name include absolute paths and extension name.</param>
        public void SearchFile(string fullname)
        {
            if (File.Exists(fullname))
            {
                File.Open(fullname, FileMode.Open);
            }
            else
            {
                Console.Write("The file does not exist!");
            }
        }

        /// <summary>
        /// Move file.
        /// </summary>
        /// <param name="sourcename">The source file name include absolute paths and extension name.</param>
        /// <param name="desname">The destination file name include absolute paths and extension name.</param>
        /// <param name="iscover">The desname already exists. true-cover, false-uncover</param>
        public void MoveFile(string sourcename, string desname, bool iscover)
        {
            if (!File.Exists(sourcename))
            {
                Console.Write("The source file does not exist!");
            }
            else if (File.Exists(desname) && !iscover)
            {
                Console.Write("The destination file already exists!");
            }
            else
            {
                DeleteFile(desname);
                File.Move(sourcename, desname);
            }
        }

        /// <summary>
        /// Copy file.
        /// </summary>
        /// <param name="sourcename">The source file name include absolute paths and extension name.</param>
        /// <param name="desname">The destination file name include absolute paths and extension name.</param>
        /// <param name="iscover">The desname already exists. true-cover, false-uncover</param>
        public void CopyFile(string sourcename, string desname, bool iscover)
        {
            if (!File.Exists(sourcename))
            {
                Console.Write("The source file does not exist!");
            }
            else if (File.Exists(desname) && !iscover)
            {
                Console.Write("The destination file already exists!");
            }
            else
            {
                DeleteFile(desname);
                File.Copy(sourcename, desname);
            }
        }

        /// <summary>
        /// Rename file .
        /// </summary>
        /// <param name="sourcename">The source file name include absolute paths and extension name.</param>
        /// <param name="desname">It has the same path, different names.</param>
        public void RenameFile(string sourcename, string desname)
        {
            if (!File.Exists(sourcename))
            {
                Console.Write("The source file does not exist!");
            }
            else if (File.Exists(desname))
            {
                Console.Write("The destination file already exists!");
            }
            else
            {
                File.Move(sourcename, desname);
            }
        }

        /// <summary>
        /// Append content.
        /// </summary>
        /// <param name="fullname">The file name include absolute paths and extension name.</param>
        /// <param name="content">Content to be append to the file.</param>
        public void AppendContent(string fullname, string content)
        {
            if (File.Exists(fullname))
            {
                File.AppendAllText(fullname, content);
            }
            else
            {
                Console.Write("The file already exists!");
            }
        }
        
    }
}
