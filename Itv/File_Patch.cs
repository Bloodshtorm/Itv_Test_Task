using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Itv
{
    class File_Patch
    {
        /// <summary>
        /// Добавление папки "Data" в дирректорию с исполняемым файлом, возвращение пути к указанному файлу
        /// </summary>
        /// <param name="ofd">Передаем форму диалога, для выбора файла</param>
        /// <returns>Путь к указанному файлy или null</returns>
        public string file_to_textbox(OpenFileDialog ofd)
        {
            ofd.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Data";
            DirectoryInfo di = Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Data");
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (ofd.FileName != null)
                {
                    return ofd.FileName;
                }
                else return null;
            }
            else return null;
        }
    }
}
