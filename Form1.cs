using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Mod6Notepad
{
    public partial class Form1 : Form
    {
        string filepath;
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtArea.Clear();
            txtArea.Focus();
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files(*.txt)|*.txt";
            openFileDialog.Title = "Open text files only";
            openFileDialog.ShowDialog();
            if(openFileDialog.FileName != string.Empty)
            {
                filepath = openFileDialog.FileName;
                txtArea.Text = File.ReadAllText(filepath);
            }
            saveToolStripMenuItem.Enabled = true; 
            saveAsToolStripMenuItem.Enabled = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(File.Exists(filepath))
            {
                File.WriteAllText(filepath, txtArea.Text);
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Document(*.txt)|*.txt";
                var result = saveFileDialog.ShowDialog();
                if(result == DialogResult.OK)
                {
                    filepath = saveFileDialog.FileName;
                    Stream stream = saveFileDialog.OpenFile();
                    StreamWriter streamWriter = new StreamWriter(stream);
                    streamWriter.WriteLine(txtArea.Text);
                    streamWriter.Close();
                    stream.Close();
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Document(*.txt)|*.txt";
            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                filepath = saveFileDialog.FileName;
                Stream stream = saveFileDialog.OpenFile();
                StreamWriter streamWriter = new StreamWriter(stream);
                streamWriter.WriteLine(txtArea.Text);
                streamWriter.Close();
                stream.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtArea.SelectedText);
            txtArea.SelectedText = String.Empty;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();
            txtArea.SelectionFont = fontDialog.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            txtArea.SelectionColor = colorDialog.Color;
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtArea.Paste();
        }
    }
}
