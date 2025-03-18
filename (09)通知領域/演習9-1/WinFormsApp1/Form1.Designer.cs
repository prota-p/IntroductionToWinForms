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
            groupBox1 = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            buttonReset = new Button();
            buttonSettings = new Button();
            notifyIcon1 = new NotifyIcon(components);
            groupBox1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Font = new Font("Yu Gothic UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 128);
            labelTime.Location = new Point(13, 10);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(95, 45);
            labelTime.TabIndex = 0;
            labelTime.Text = "25:00";
            // 
            // buttonStartStop
            // 
            buttonStartStop.Location = new Point(13, 58);
            buttonStartStop.Name = "buttonStartStop";
            buttonStartStop.Size = new Size(95, 23);
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
            // groupBox1
            // 
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(136, 186);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "ポモドーロタイマー";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(labelTime);
            flowLayoutPanel1.Controls.Add(buttonStartStop);
            flowLayoutPanel1.Controls.Add(buttonReset);
            flowLayoutPanel1.Controls.Add(buttonSettings);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 19);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.Size = new Size(130, 164);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(13, 87);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(95, 23);
            buttonReset.TabIndex = 2;
            buttonReset.Text = "リセット";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonSettings
            // 
            buttonSettings.Location = new Point(13, 116);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(95, 23);
            buttonSettings.TabIndex = 3;
            buttonSettings.Text = "設定";
            buttonSettings.UseVisualStyleBackColor = true;
            buttonSettings.Click += buttonSettings_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(136, 186);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelTime;
        private Button buttonStartStop;
        private System.Windows.Forms.Timer timer1;
        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonReset;
        private Button buttonSettings;
        private NotifyIcon notifyIcon1;
    }
}
