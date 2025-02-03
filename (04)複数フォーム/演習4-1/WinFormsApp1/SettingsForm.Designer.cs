namespace WinFormsApp1
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxWorkTime = new ComboBox();
            buttonOK = new Button();
            buttonCancel = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // comboBoxWorkTime
            // 
            comboBoxWorkTime.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxWorkTime.FormattingEnabled = true;
            comboBoxWorkTime.Location = new Point(109, 12);
            comboBoxWorkTime.Name = "comboBoxWorkTime";
            comboBoxWorkTime.Size = new Size(121, 23);
            comboBoxWorkTime.TabIndex = 0;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(155, 52);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 1;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(236, 52);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "キャンセル";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 3;
            label1.Text = "作業時間（分）";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 82);
            Controls.Add(label1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(comboBoxWorkTime);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            Text = "タイマー設定";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxWorkTime;
        private Button buttonOK;
        private Button buttonCancel;
        private Label label1;
    }
}