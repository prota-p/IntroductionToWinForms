namespace WinFormsApp1
{
    public partial class SettingsForm : Form
    {
        private int _workMinutes;

        public SettingsForm(int currentWorkMinutes)
        {
            InitializeComponent();

            // コンボボックスに整数値を追加
            int[] timeOptions = { 15, 25, 45 };
            foreach (int minutes in timeOptions)
            {
                comboBoxWorkTime.Items.Add(minutes);
            }

            // 現在の設定値を選択
            comboBoxWorkTime.SelectedItem = currentWorkMinutes;
            _workMinutes = currentWorkMinutes;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (comboBoxWorkTime.SelectedItem is int selectedMinutes)
            {
                _workMinutes = selectedMinutes;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public int GetWorkMinutes()
        {
            return _workMinutes;
        }
    }
}
