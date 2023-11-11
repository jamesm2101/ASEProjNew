namespace ASEProjNew
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            singlecommandbox = new TextBox();
            runbutton = new Button();
            syntaxbutton = new Button();
            graphicsarea = new PictureBox();
            completecommandbox = new TextBox();
            savebutton = new Button();
            loadbutton = new Button();
            ((System.ComponentModel.ISupportInitialize)graphicsarea).BeginInit();
            SuspendLayout();
            // 
            // singlecommandbox
            // 
            singlecommandbox.Location = new Point(44, 385);
            singlecommandbox.Name = "singlecommandbox";
            singlecommandbox.Size = new Size(434, 27);
            singlecommandbox.TabIndex = 3;
            // 
            // runbutton
            // 
            runbutton.Location = new Point(119, 436);
            runbutton.Name = "runbutton";
            runbutton.Size = new Size(94, 29);
            runbutton.TabIndex = 4;
            runbutton.Text = "Run";
            runbutton.UseVisualStyleBackColor = true;
            // 
            // syntaxbutton
            // 
            syntaxbutton.Location = new Point(314, 436);
            syntaxbutton.Name = "syntaxbutton";
            syntaxbutton.Size = new Size(94, 29);
            syntaxbutton.TabIndex = 5;
            syntaxbutton.Text = "Syntax";
            syntaxbutton.UseVisualStyleBackColor = true;
            syntaxbutton.Click += button1_Click;
            // 
            // graphicsarea
            // 
            graphicsarea.BackColor = SystemColors.ControlDarkDark;
            graphicsarea.Location = new Point(597, 41);
            graphicsarea.Name = "graphicsarea";
            graphicsarea.Size = new Size(400, 400);
            graphicsarea.TabIndex = 6;
            graphicsarea.TabStop = false;
            // 
            // completecommandbox
            // 
            completecommandbox.Location = new Point(44, 61);
            completecommandbox.Multiline = true;
            completecommandbox.Name = "completecommandbox";
            completecommandbox.Size = new Size(434, 302);
            completecommandbox.TabIndex = 7;
            completecommandbox.TextChanged += completecommandbox_TextChanged;
            // 
            // savebutton
            // 
            savebutton.Location = new Point(119, 28);
            savebutton.Name = "savebutton";
            savebutton.Size = new Size(94, 29);
            savebutton.TabIndex = 8;
            savebutton.Text = "Save";
            savebutton.UseVisualStyleBackColor = true;
            savebutton.Click += savebutton_Click;
            // 
            // loadbutton
            // 
            loadbutton.Location = new Point(314, 28);
            loadbutton.Name = "loadbutton";
            loadbutton.Size = new Size(94, 29);
            loadbutton.TabIndex = 9;
            loadbutton.Text = "Load";
            loadbutton.UseVisualStyleBackColor = true;
            loadbutton.Click += loadbutton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1048, 546);
            Controls.Add(loadbutton);
            Controls.Add(savebutton);
            Controls.Add(completecommandbox);
            Controls.Add(graphicsarea);
            Controls.Add(syntaxbutton);
            Controls.Add(runbutton);
            Controls.Add(singlecommandbox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)graphicsarea).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox singlecommandbox;
        private Button runbutton;
        private Button syntaxbutton;
        private PictureBox graphicsarea;
        private TextBox completecommandbox;
        private Button savebutton;
        private Button loadbutton;
    }
}