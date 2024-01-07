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
        //Two bitmaps created on top of each other to aid the creation of a canvas
        Bitmap OutputBitmap = new Bitmap(400, 400);
        Bitmap CursorBitmap = new Bitmap(400, 400);
        Graphics GraphicalBitMap;
        Canvas myCanvas;
        Parser myParser;

        //Set background colour
        Color BackgroundColour = Color.DarkGray;

        //Command list is created for syntax
        List<string> commandlist = new List<string>(new string[] { "moveto", "drawto", "clear", "reset", "circle", "rectangle", "triangle", "fill", "blue", "black", "green", "red" });

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //centre the form

            //GraphicalBitmap connected to OutputBitmap
            GraphicalBitMap = Graphics.FromImage(OutputBitmap);

            //Canvas created from the two bitmaps to help with graphics
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
        /// Checks for valid commands throughout the command boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void syntaxbutton_Click(object sender, EventArgs e)
        {
            //Whitespace removed from the command box
           string program = completecommandbox.Text.Trim();

            //Errorstring ran through the processor
           string errorsstring = myParser.ProgramProcessor(program);

            //Message box shown with the included errors list (if there is one)
           if (errorsstring != null)
           {
                MessageBox.Show(errorsstring);
                return;  
           }

           else
           {
                errorsstring = "No errors in this code";
                MessageBox.Show(errorsstring);
                return;

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
        /// When the enter key is pressed the single command text box will be processed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void singlecommandbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Whitespace removed
                String program = singlecommandbox.Text.Trim();
                /*GraphicalBitMap.Clear(BackgroundColour);*/

                //Program processed
                myParser.ProgramProcessor(program);

                //Graphics box and command box are refreshed
                singlecommandbox.Clear();
                Refresh();

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
            //Off screen bitmap is added to the form
            g.DrawImageUnscaled(OutputBitmap, 0, 0);
            //Cursor bitmap is added to the form
            g.DrawImageUnscaled(CursorBitmap, 0, 0); 

        }

        /// <summary>
        /// When the run button is clicked it will process the multiline commands
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void runbutton_Click(object sender, EventArgs e)
        {
            //Whitespace removed
            String program = completecommandbox.Text.Trim();
            GraphicalBitMap.Clear(BackgroundColour);

            //Process program
            myParser.ProgramProcessor(program);

            //Command box and graphics box refreshed
            completecommandbox.Clear();
            graphicsarea.Invalidate();
            Refresh();
        }

    }
}