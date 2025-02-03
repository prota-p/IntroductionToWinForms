namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private const int SecondsPerMinute = 60;
        private int _workMinutes = 25;  // 定数から変数に変更
        private bool _isRunning = false;
        private int _remainingSeconds;

        public Form1()
        {
            InitializeComponent();
            _remainingSeconds = _workMinutes * SecondsPerMinute;  // 初期化
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (!_isRunning)
            {
                timer1.Start();
                buttonStartStop.Text = "ストップ";
            }
            else
            {
                timer1.Stop();
                buttonStartStop.Text = "スタート";
            }
            _isRunning = !_isRunning;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _remainingSeconds--;
            if (_remainingSeconds < 0)
            {
                timer1.Stop();
                MessageBox.Show("時間になりました！");
                ResetTimer();  // リセット処理を共通メソッドに
                return;
            }

            UpdateDisplay();  // 表示更新を共通メソッドに
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetTimer();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                MessageBox.Show("タイマー動作中は設定を変更できません。");
                return;
            }

            var settingsForm = new SettingsForm(_workMinutes);
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                _workMinutes = settingsForm.GetWorkMinutes();
                ResetTimer();
            }
        }

        // 共通処理をメソッドに抽出
        private void ResetTimer()
        {
            timer1.Stop();
            _remainingSeconds = _workMinutes * SecondsPerMinute;
            UpdateDisplay();
            buttonStartStop.Text = "スタート";
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