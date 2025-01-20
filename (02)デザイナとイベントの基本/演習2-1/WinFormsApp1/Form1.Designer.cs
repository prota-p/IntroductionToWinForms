namespace WinFormsApp1
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
            components = new System.ComponentModel.Container();
            labelTime = new Label();
            buttonStartStop = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Font = new Font("Yu Gothic UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 128);
            labelTime.Location = new Point(35, 20);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(95, 45);
            labelTime.TabIndex = 0;
            labelTime.Text = "25:00";
            // 
            // buttonStartStop
            // 
            buttonStartStop.Location = new Point(46, 79);
            buttonStartStop.Name = "buttonStartStop";
            buttonStartStop.Size = new Size(75, 23);
            buttonStartStop.TabIndex = 1;
            buttonStartStop.Text = "スタート";
            buttonStartStop.UseVisualStyleBackColor = true;
            buttonStartStop.Click += buttonStartStop_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(183, 141);
            Controls.Add(buttonStartStop);
            Controls.Add(labelTime);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTime;
        private Button buttonStartStop;
        private System.Windows.Forms.Timer timer1;
    }
}
