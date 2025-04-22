using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using WinFormsBlazorApp.Pages;
using WinFormsBlazorApp.Services;

namespace WinFormsBlazorApp.Forms
{
    public partial class MainForm : Form
    {
        //生文字列リテラルでシステムプロンプトを定義
        private const string SystemPrompt = """
            あなたは長年の開発経験をもつプログラミング教師です。以下のルールに従って回答してください。

            - ロールプレイングゲームに登場する村の長老のような話し方をしてください
            - 簡潔に3文程度で要点をわかりやすく解説してください
            - プログラミングの話題以外の場合は、その話題に回答できないと返事してください
            - C#以外の言語の話題になったら、その言語を褒めつつC#をさりげなくおすすめしてください

            重要: 必ず以下のJSON形式で回答を返してください。
            {
              "Answer": "ここに通常の回答を入れる",
              "Topics": {
                "フロントエンド": true/false,   // HTML, CSS, JavaScript, UIフレームワークなど
                "バックエンド": true/false,     // サーバーサイド処理、APIなど
                "データベース": true/false,     // SQL, NoSQL, データモデリング
                "デスクトップ開発": true/false, // WinForms, WPF, MAUI等
                "モバイル開発": true/false,     // Android, iOS, MAUI等
                "ゲーム開発": true/false,       // Unityなど
                "アルゴリズム": true/false,     // データ構造、計算効率など
                "開発ツール": true/false,       // Git, VS, CI/CDなど
                "クラウド": true/false,         // Azure, AWS等のクラウドサービス
                "AI/ML": true/false,            // 人工知能、機械学習関連
                "セキュリティ": true/false,     // セキュアコーディング、認証等
                "非プログラミング": true/false   // プログラミング以外の話題
              }
            }

            各トピックはユーザーの質問に関連するかどうかをtrueまたはfalseで示してください。
            ユーザーの入力内容を分析し、該当するトピックにはtrueを、該当しないトピックにはfalseを設定してください。
            """;

        public MainForm()
        {
            InitializeComponent();
            var services = new ServiceCollection();
            services.AddWindowsFormsBlazorWebView();
            services.AddScoped<IChatService, AzureOpenAIChatService>(
                serviceProvider =>
                {
                    var endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT");
                    var apiKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_KEY");
                    var deploymentName = Environment.GetEnvironmentVariable("AZURE_OPENAI_DEPLOYMENT_NAME");
                    if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(deploymentName))
                    {
                        throw new InvalidOperationException("Azure OpenAI configuration is missing.");
                    }
                    return new AzureOpenAIChatService(endpoint, apiKey, deploymentName, SystemPrompt);
                });
            blazorWebView1.HostPage = "wwwroot\\index.html";
            blazorWebView1.Services = services.BuildServiceProvider();
            blazorWebView1.RootComponents.Add<Chat>("#app");
        }
    }
}
