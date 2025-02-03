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
            _remainingSeconds = _workMinutes * SecondsPerMinute;  // ������
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
                MessageBox.Show("���ԂɂȂ�܂����I");
                ResetTimer();  // ���Z�b�g���������ʃ��\�b�h��
                return;
            }

            UpdateDisplay();  // �\���X�V�����ʃ��\�b�h��
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
            labelTime.Text = $"{minutes:00}:{seconds:00}";
        }
    }
}