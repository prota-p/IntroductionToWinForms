namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private const int SecondsPerMinute = 60;
        private int _workMinutes = 25;  // �萔����ϐ��ɕύX
        private bool _isRunning = false;
        private int _remainingSeconds;

        public Form1()
        {
            InitializeComponent();
            SetupNotifyIcon();
            _remainingSeconds = _workMinutes * SecondsPerMinute;  // ������
        }

        private void SetupNotifyIcon()
        {
            // ��{�v���p�e�B�̐ݒ�
            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.Text = "�|���h�[���^�C�}�[";

            // �E�B���h�E��\������f���Q�[�g�����[�J���Ő錾
            Action showMainWindow = () => {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            };

            // �C�x���g�������_���Őݒ�
            notifyIcon1.DoubleClick += (s, e) => showMainWindow();

            // �R���e�L�X�g���j���[�̍쐬
            var menu = new ContextMenuStrip();

            // �\�����j���[���ڂ̒ǉ�
            var showItem = new ToolStripMenuItem("�\��");
            showItem.Click += (s, e) => showMainWindow();
            menu.Items.Add(showItem);

            // �I�����j���[���ڂ̒ǉ�
            var exitItem = new ToolStripMenuItem("�I��");
            exitItem.Click += (s, e) => {
                Application.Exit();
            };
            menu.Items.Add(exitItem);

            // ���j���[��NotifyIcon�ɐݒ�
            notifyIcon1.ContextMenuStrip = menu;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;  // �t�H�[�������̂��L�����Z��
                this.Hide();      // ����ɔ�\���ɂ���

                //�o���[���ʒm
                notifyIcon1.ShowBalloonTip(
                    1000,
                    "�|���h�[���^�C�}�[",
                    "�^�C�}�[�̓o�b�N�O���E���h�Ŏ��s���ł�",
                    ToolTipIcon.Info);
            }

            base.OnFormClosing(e);
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (!_isRunning)
            {
                timer1.Start();
                buttonStartStop.Text = "�X�g�b�v";
            }
            else
            {
                timer1.Stop();
                buttonStartStop.Text = "�X�^�[�g";
            }
            _isRunning = !_isRunning;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _remainingSeconds--;
            if (_remainingSeconds < 0)
            {
                timer1.Stop();
                notifyIcon1.ShowBalloonTip(2000, "�|���h�[���^�C�}�[", "���ԂɂȂ�܂����I", ToolTipIcon.Info);
                ResetTimer();
                return;
            }

            UpdateDisplay();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetTimer();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                MessageBox.Show("�^�C�}�[���쒆�͐ݒ��ύX�ł��܂���B");
                return;
            }

            var settingsForm = new SettingsForm(_workMinutes);
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                _workMinutes = settingsForm.GetWorkMinutes();
                ResetTimer();
            }
        }

        // ���ʏ��������\�b�h�ɒ��o
        private void ResetTimer()
        {
            timer1.Stop();
            _remainingSeconds = _workMinutes * SecondsPerMinute;
            UpdateDisplay();
            buttonStartStop.Text = "�X�^�[�g";
            _isRunning = false;
        }

        private void UpdateDisplay()
        {
            int minutes = _remainingSeconds / SecondsPerMinute;
            int seconds = _remainingSeconds % SecondsPerMinute;
            string time = $"{minutes:00}:{seconds:00}";
            labelTime.Text = time;
            notifyIcon1.Text = time;  // �^�X�N�g���C�A�C�R���̃c�[���`�b�v�ɂ��\��
        }
    }
}