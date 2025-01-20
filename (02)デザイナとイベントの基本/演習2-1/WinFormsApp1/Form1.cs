namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private const int WorkMinutes = 25;
        private const int SecondsPerMinute = 60;
        private bool _isRunning = false;
        private int _remainingSeconds = WorkMinutes * SecondsPerMinute;  // 25��

        public Form1()
        {
            InitializeComponent();
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
                _remainingSeconds = WorkMinutes * SecondsPerMinute;  // ���Z�b�g
            }

            int minutes = _remainingSeconds / SecondsPerMinute;
            int seconds = _remainingSeconds % SecondsPerMinute;
            labelTime.Text = $"{minutes:00}:{seconds:00}";
        }
    }
}
