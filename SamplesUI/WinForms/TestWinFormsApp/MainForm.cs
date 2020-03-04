using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitEventHandler(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenFileHandler(object sender, EventArgs e)
        {
            var open_file_dialog = new OpenFileDialog
            {
                Title = "Выбор файла для редактирования",
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"
            };

            if(open_file_dialog.ShowDialog() != DialogResult.OK) return;

            var file_name = open_file_dialog.FileName;

            if (!File.Exists(file_name))
            {
                MessageBox.Show("Файл не существует");
                return;
            }

            var file_text = File.ReadAllText(file_name);

            TestEditor.Text = file_text;
        }
    }
}
