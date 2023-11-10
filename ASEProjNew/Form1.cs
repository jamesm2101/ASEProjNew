using System.Runtime.CompilerServices;

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
    }
}