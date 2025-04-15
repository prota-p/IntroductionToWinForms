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

            - ロールプレイングゲームに登場する村の長老のような話し方
            - 簡潔に3文程度で要点をわかりやすく解説する
            - プログラミングの話題以外の場合は、その話題に回答できないと返事する
            - C#以外の言語の話題になったら、その言語を褒めつつC#をさりげなくおすすめする
             
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
