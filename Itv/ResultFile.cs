using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Itv
{
    public class ResultFile : Form
    {
        public static string[] file1 { get; set; }
        public static string[] file2 { get; set; }

        public ResultFile(string[] arr1, string[] arr2)
        {
            file1 = arr1;
            file2 = arr2;
        }
        public string[] Except1()
        {
            if (file1 != null && file2 != null)
            {
                string[] Except1 = file1.Except<string>(file2).ToArray();
                File.WriteAllLines(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Data\ResultExcept1.txt", Except1);
                return Except1;
            }
            else return null;
        }

        public string[] Except2()
        {
            if (file1 != null && file2 != null)
            {
                string[] Except2 = file2.Except<string>(file1).ToArray();
                File.WriteAllLines(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Data\ResultExcept2.txt", Except2);
                return Except2;
            }
            else return null;
        }

    }
}
