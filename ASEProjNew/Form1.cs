using System.Runtime.CompilerServices;
using System;
using System.IO;
using System.Windows.Forms;
namespace ASEProjNew
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void loadbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                try
                {
                    if (openFileDialog1.FileName != null)
                    {
                        String FilePath = openFileDialog1.FileName;
                        completecommandbox.Text = File.ReadAllText(openFileDialog1.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not load file" + ex.Message);
                }
        }

        private void completecommandbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save a Text File";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK);
                try
                {
                    if (saveFileDialog1.FileName != "")
                    {
                        System.IO.FileStream fs =
                            (System.IO.FileStream)saveFileDialog1.OpenFile();

                        fs.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not save file" + ex.Message);
                }
        }
    }
}