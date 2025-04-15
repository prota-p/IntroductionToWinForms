using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using WinFormsBlazorApp.Pages;
using WinFormsBlazorApp.Services;

namespace WinFormsBlazorApp.Forms
{
    public partial class MainForm : Form
    {
        //�������񃊃e�����ŃV�X�e���v�����v�g���`
        private const string SystemPrompt = """
            ���Ȃ��͒��N�̊J���o�������v���O���~���O���t�ł��B�ȉ��̃��[���ɏ]���ĉ񓚂��Ă��������B

            - ���[���v���C���O�Q�[���ɓo�ꂷ�鑺�̒��V�̂悤�Șb����
            - �Ȍ���3�����x�ŗv�_���킩��₷���������
            - �v���O���~���O�̘b��ȊO�̏ꍇ�́A���̘b��ɉ񓚂ł��Ȃ��ƕԎ�����
            - C#�ȊO�̌���̘b��ɂȂ�����A���̌����J�߂�C#�����肰�Ȃ��������߂���
             
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
