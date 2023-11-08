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
            ((System.ComponentModel.ISupportInitialize)graphicsarea).BeginInit();
            SuspendLayout();
            // 
            // singlecommandbox
            // 
            singlecommandbox.Location = new Point(51, 338);
            singlecommandbox.Name = "singlecommandbox";
            singlecommandbox.Size = new Size(392, 27);
            singlecommandbox.TabIndex = 3;
            // 
            // runbutton
            // 
            runbutton.Location = new Point(96, 383);
            runbutton.Name = "runbutton";
            runbutton.Size = new Size(94, 29);
            runbutton.TabIndex = 4;
            runbutton.Text = "Run";
            runbutton.UseVisualStyleBackColor = true;
            // 
            // syntaxbutton
            // 
            syntaxbutton.Location = new Point(304, 383);
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
            graphicsarea.Location = new Point(589, 12);
            graphicsarea.Name = "graphicsarea";
            graphicsarea.Size = new Size(400, 400);
            graphicsarea.TabIndex = 6;
            graphicsarea.TabStop = false;
            // 
            // completecommandbox
            // 
            completecommandbox.Location = new Point(44, 21);
            completecommandbox.Multiline = true;
            completecommandbox.Name = "completecommandbox";
            completecommandbox.Size = new Size(399, 302);
            completecommandbox.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1048, 546);
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
    }
}