using System.Runtime.CompilerServices;
using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.Design;
using static System.Windows.Forms.LinkLabel;

namespace ASEProjNew
{
    public partial class Form1 : Form
    {
        const bool RUN = true;
        const bool NO_RUN = false;
        const bool execute = false;
        //two bitmaps to create output on the added picture box
        Bitmap OutputBitmap = new Bitmap(400, 400);
        Bitmap CursorBitmap = new Bitmap(400, 400);
        Graphics GraphicalBitMap;
        Canvas myCanvas;
        Parser myParser;
        Color BackgroundColour = Color.DarkGray;
        List<string> commandlist = new List<string>(new string[] { "moveto", "drawto", "clear", "reset", "circle", "rectangle", "triangle", "pen", "fill"});

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //centre the form
            GraphicalBitMap = Graphics.FromImage(OutputBitmap);
            myCanvas = new Canvas(this, Graphics.FromImage(OutputBitmap), Graphics.FromImage(CursorBitmap));
            myParser = new Parser(myCanvas);
            myCanvas.UpdateCursor();
            GraphicalBitMap.Clear(BackgroundColour);
                

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Checks for valid commands throughout both text boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void syntaxbutton_Click(object sender, EventArgs e)
        {
            string[] completelines = completecommandbox.Lines;
            string[] singlelines = singlecommandbox.Lines;

            if (completecommandbox.Text != null)
            {
                for (int i = 0; i <= completelines.GetUpperBound(0); i++)
                {
                    if (commandlist.Contains(completelines[i]))
                    {
                        MessageBox.Show(completelines[i]+" Command is valid");
                    }

                    else
                        throw new Exception("Enter a valid command");
                }
            }

            if (singlecommandbox.Text != null)
            {
                for (int i = 0; i <= singlelines.GetUpperBound(0); i++)
                {
                    if (commandlist.Contains(singlelines[i]))
                    {
                        MessageBox.Show(singlelines[i]+" Command is valid");
                    }

                    else
                        throw new Exception("Enter a valid command");
                }
            }

            
            if (completecommandbox.Text == null && singlecommandbox.Text == null)
                {
                    throw new Exception("Enter a valid command");
                }
       
        }

        /// <summary>
        /// Load a text file into the multiline text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Save button will allow you to save the multiline command box as a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// When the enter key is pressed the single command text box will check whether it contains valid commands or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void singlecommandbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String program = singlecommandbox.Text.Trim();
                GraphicalBitMap.Clear(BackgroundColour);
                myParser.ProgramProcessor(program);
                singlecommandbox.Clear();


            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        /// <summary>
        /// Bitmaps created on top of the picture box so that cursors and drawings can overlay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graphicsarea_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitmap, 0, 0); //Off screen bitmap is added to the form
            g.DrawImageUnscaled(CursorBitmap, 0, 0);

        }

        /// <summary>
        /// When the run button is clicked it will check whether the multiline textbox contains the correct commands
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void runbutton_Click(object sender, EventArgs e)
        {
            string[] lines = completecommandbox.Lines;

            for (int i = 0; i <= lines.GetUpperBound(0); i++)
            {
                String Input = completecommandbox.Text.Trim().ToLower();
                if (commandlist.Contains(lines[i]))
                {
                    MessageBox.Show(lines[i]);
                }

                else
                    throw new Exception("Enter a valid command");
            }
            completecommandbox.Clear();
        }

    }
}