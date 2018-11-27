using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//directory
using System.IO;
//zip Remember to reference assembly
using System.IO.Compression;

namespace CsharpFunction
{
    /*
     * 功能
     * 操作文件夹：创建 删除 移动 复制 重命名 计算文件夹下子文件和子文件夹的个数 按文件名称排列顺序 压缩 解压缩
     * Epulari T 
     * 2018.4.7
     */
    class OperateDirectory
    {
        /// <summary>
        /// Create directory.
        /// </summary>
        /// <param name="fullname">The directory name include absolute paths and extension name.</param>
        public void CreateDirectory(string fullname)
        {
            if (!Directory.Exists(fullname))
            {
                Directory.CreateDirectory(fullname);
            }
            else
            {
                Console.Write("The directory already exists!");
            }
        }

        /// <summary>
        /// Delete directory.
        /// </summary>
        /// <param name="fullname">The directory name include absolute paths and extension name.</param>
        /// <param name="haschild">true-has child-delete, false-has child-undelete</param>
        public void DeleteDirectory(string fullname, bool haschild)
        {
            if (Directory.Exists(fullname))
            {
                int[] count = CountChild(fullname);
                int[] nochild = new int[2] { 0, 0 };
                if (!Enumerable.SequenceEqual(count, nochild) && !haschild)
                {
                    Console.Write("There are child files or directories in it!");
                    return;
                }
                Directory.Delete(fullname, haschild);

            }
            else
            {
                Console.Write("The directory does not exist!");
            }
        }

        /// <summary>
        /// Move directory.
        /// </summary>
        /// <param name="sourcename">The source directory name include absolute paths and extension name.</param>
        /// <param name="desname">The destination directory name include absolute paths and extension name, and the file name can be different from it.</param>
        public void MoveDirectory(string sourcename, string desname, bool iscover)
        {
            if (!Directory.Exists(sourcename))
            {
                Console.Write("The source directory does not exist!");
            }
            else if (Directory.Exists(desname) && !iscover)
            {
                Console.Write("The destination directory already exists!");
            }
            else
            {
                Directory.Move(sourcename, desname);
            }
        }

        /// <summary>
        /// Copy directory.
        /// </summary>
        /// <param name="sourcename">The source directory name include absolute paths and extension name.</param>
        /// <param name="desname">The destination directory name include absolute paths and extension name.</param>
        /// <param name="cover">Whether to overwrite the directory with the same name.</param>
        public void CopyDirectory(string sourcename, string desname, bool iscover)
        {
            if (!Directory.Exists(sourcename))
            {
                Console.Write("The source directory does not exist!");
            }
            else if (Directory.Exists(desname) && !iscover)
            {
                Console.Write("The destination directory already exists!");
            }
            else
            {
                DeleteDirectory(desname, true);
                CreateDirectory(desname);
                DirectoryInfo info = new DirectoryInfo(sourcename);
                foreach (FileSystemInfo fsi in info.GetFileSystemInfos())
                {
                    String destName = Path.Combine(desname, fsi.Name);

                    if (fsi is FileInfo)
                        File.Copy(fsi.FullName, destName);
                    else
                    {
                        Directory.CreateDirectory(destName);
                        CopyDirectory(fsi.FullName, destName, true);
                    }
                }
            }
        }


        /// <summary>
        /// Rename directory .
        /// </summary>
        /// <param name="sourcename">The source directory name include absolute paths and extension name.</param>
        /// <param name="desname">It has the same path, different names.</param>
        public void RenameDirectory(string sourcename, string desname)
        {
            if (!Directory.Exists(sourcename))
            {
                Console.Write("The source directory does not exist!");
            }
            else if (Directory.Exists(desname))
            {
                Console.Write("The destination directory already exists!");
            }
            else
            {
                Directory.Move(sourcename, desname);
            }
        }

        /// <summary>
        /// Calculate the number of subfolders and subfiles
        /// </summary>
        /// <param name="fullname">The directory name include absolute paths and extension name.</param>
        /// <returns>[dire, file]: directory does not exist[-1, -1], directory exist[>=0, >=0]</returns>
        public int[] CountChild(string fullname)
        {
            if (Directory.Exists(fullname))
            {
                int[] count = { Directory.GetDirectories(fullname).Length, Directory.GetFiles(fullname).Length };
                return count;
            }
            else
            {
                int[] count = { -1, -1 };
                return count;
            }
        }

        /// <summary>
        /// Sort as file name
        /// </summary>
        /// <param name="fullname">The directory name include absolute paths and extension name.</param>
        public void SortAsFileName(string fullname)
        {
            DirectoryInfo dir = new DirectoryInfo(fullname);
            FileInfo[] arrFi = dir.GetFiles("*.*");
            SortName(ref arrFi);
        }
        private void SortName(ref FileInfo[] arrFi)
        {
            Array.Sort(arrFi, delegate (FileInfo x, FileInfo y)
            {
                return x.Name.CompareTo(y.Name);
            });
        }

        /// <summary>
        /// Zip directory .
        /// </summary>
        /// <param name="sourcename">The source directory name include absolute paths and extension name.</param>
        /// <param name="desname">The compressed directory format is zip.</param>
        public void CompressDirectory(string sourcename, string desname)
        {
            if (!Directory.Exists(sourcename))
            {
                Console.Write("The source directory does not exist!");
            }
            else if (File.Exists(desname))
            {
                Console.Write("The directory already exist!");
            }
            else
            {
                ZipFile.CreateFromDirectory(sourcename, desname);
            }
        }

        /// <summary>
        /// Unzip directory .
        /// </summary>
        /// <param name="sourcename">The compressed directory format is zip.</param>
        /// <param name="desname">The destination directory name include absolute paths and extension name.</param>
        public void UnzipDirectory(string sourcename, string desname)
        {
            if (!File.Exists(sourcename))
            {
                Console.Write("The source file does not exist!");
            }
            else if (Directory.Exists(desname))
            {
                Console.Write("The directory already exist!");
            }
            else
            {
                ZipFile.ExtractToDirectory(sourcename, desname);
            }
        }
    }
}
