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
            SetupNotifyIcon();
            _remainingSeconds = _workMinutes * SecondsPerMinute;  // 初期化
        }

        private void SetupNotifyIcon()
        {
            // 基本プロパティの設定
            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.Text = "ポモドーロタイマー";

            // ウィンドウを表示するデリゲートをローカルで宣言
            Action showMainWindow = () => {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            };

            // イベントをラムダ式で設定
            notifyIcon1.DoubleClick += (s, e) => showMainWindow();

            // コンテキストメニューの作成
            var menu = new ContextMenuStrip();

            // 表示メニュー項目の追加
            var showItem = new ToolStripMenuItem("表示");
            showItem.Click += (s, e) => showMainWindow();
            menu.Items.Add(showItem);

            // 終了メニュー項目の追加
            var exitItem = new ToolStripMenuItem("終了");
            exitItem.Click += (s, e) => {
                Application.Exit();
            };
            menu.Items.Add(exitItem);

            // メニューをNotifyIconに設定
            notifyIcon1.ContextMenuStrip = menu;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;  // フォームを閉じるのをキャンセル
                this.Hide();      // 代わりに非表示にする

                //バルーン通知
                notifyIcon1.ShowBalloonTip(
                    1000,
                    "ポモドーロタイマー",
                    "タイマーはバックグラウンドで実行中です",
                    ToolTipIcon.Info);
            }

            base.OnFormClosing(e);
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
                notifyIcon1.ShowBalloonTip(2000, "ポモドーロタイマー", "時間になりました！", ToolTipIcon.Info);
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
            string time = $"{minutes:00}:{seconds:00}";
            labelTime.Text = time;
            notifyIcon1.Text = time;  // タスクトレイアイコンのツールチップにも表示
        }
    }
}