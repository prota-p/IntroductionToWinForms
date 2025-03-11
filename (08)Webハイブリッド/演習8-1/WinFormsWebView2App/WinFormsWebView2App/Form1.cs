namespace WinFormsWebView2App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webView21.Source = new Uri("https://www.google.com");
        }
    }
}
