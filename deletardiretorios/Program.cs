using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deletardiretorios
{
    class Program
    {
        static void Main(string[] args)
        {
            deletarDiretorios(@"C:\WORK\1-Arquivos Pessoais\Copias");
        }


        private static void deletarDiretorios(string local)
        {
            string[] fileArray = Directory.GetDirectories(local);
            for (int i = 0; i < fileArray.Length; i++)
            {
                if (fileArray[i].Contains(@"\Package") || fileArray[i].Contains(@"\bin") || fileArray[i].Contains(@"\obj"))
                {
                    Console.WriteLine(fileArray[i]);
                    System.IO.DirectoryInfo di = new DirectoryInfo(fileArray[i].ToString());
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                }
                else
                    deletarDiretorios(fileArray[i].ToString());
            }
        }
    }
}
