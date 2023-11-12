using System.Runtime.CompilerServices;
using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.Design;

namespace ASEProjNew
{
    public partial class Form1 : Form
    {
        const bool RUN = true;
        const bool NO_RUN = false;
        const bool execute = false;
        //two bitmaps to create output on the added picture box
        Bitmap OutputBitmap = new Bitmap(1066, 593);
        Bitmap CursorBitmap = new Bitmap(1066, 593);
        Graphics GraphicalBitMap;
        Color BackgroundColour = Color.DarkGray;
        List<string> commandlist = new List<string>(new string[] { "moveTo", "drawTo", "clear", "reset", "circle", "rectangle", "triangle", "pen", "fill"});

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //centre the form
            GraphicalBitMap = Graphics.FromImage(OutputBitmap);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void syntaxbutton_Click(object sender, EventArgs e)
        {
            if (commandlist.Contains(completecommandbox.Text))
            {
                MessageBox.Show("You have chosen to " + completecommandbox.Text);
            }

            else
                throw new Exception("Enter a valid command");
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
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                try
                {
                    if (saveFileDialog1.FileName != "")
                    {
                        System.IO.File.WriteAllText(saveFileDialog1.FileName, completecommandbox.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not save file" + ex.Message);
                }
        }

        private void singlecommandbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string[] lines = singlecommandbox.Lines;

                for (int i = 0; i <= lines.GetUpperBound(0); i++)
                {
                    MessageBox.Show(lines[i]);
                }
                singlecommandbox.Clear();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void graphicsarea_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitmap, 0, 0); //Off screen bitmap is added to the form
            g.DrawImageUnscaled(CursorBitmap, 0, 0); //cursor is added to the form

        }


        private void runbutton_Click(object sender, EventArgs e)
        {
            string[] lines = completecommandbox.Lines;

            for (int i = 0; i <= lines.GetUpperBound(0); i++)
            {
                MessageBox.Show(lines[i]);
            }
            completecommandbox.Clear();
        }

    }
}