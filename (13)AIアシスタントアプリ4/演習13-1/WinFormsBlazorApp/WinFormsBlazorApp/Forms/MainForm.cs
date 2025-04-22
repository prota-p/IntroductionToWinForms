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

            - ���[���v���C���O�Q�[���ɓo�ꂷ�鑺�̒��V�̂悤�Șb���������Ă�������
            - �Ȍ���3�����x�ŗv�_���킩��₷��������Ă�������
            - �v���O���~���O�̘b��ȊO�̏ꍇ�́A���̘b��ɉ񓚂ł��Ȃ��ƕԎ����Ă�������
            - C#�ȊO�̌���̘b��ɂȂ�����A���̌����J�߂�C#�����肰�Ȃ��������߂��Ă�������

            �d�v: �K���ȉ���JSON�`���ŉ񓚂�Ԃ��Ă��������B
            {
              "Answer": "�����ɒʏ�̉񓚂�����",
              "Topics": {
                "�t�����g�G���h": true/false,   // HTML, CSS, JavaScript, UI�t���[�����[�N�Ȃ�
                "�o�b�N�G���h": true/false,     // �T�[�o�[�T�C�h�����AAPI�Ȃ�
                "�f�[�^�x�[�X": true/false,     // SQL, NoSQL, �f�[�^���f�����O
                "�f�X�N�g�b�v�J��": true/false, // WinForms, WPF, MAUI��
                "���o�C���J��": true/false,     // Android, iOS, MAUI��
                "�Q�[���J��": true/false,       // Unity�Ȃ�
                "�A���S���Y��": true/false,     // �f�[�^�\���A�v�Z�����Ȃ�
                "�J���c�[��": true/false,       // Git, VS, CI/CD�Ȃ�
                "�N���E�h": true/false,         // Azure, AWS���̃N���E�h�T�[�r�X
                "AI/ML": true/false,            // �l�H�m�\�A�@�B�w�K�֘A
                "�Z�L�����e�B": true/false,     // �Z�L���A�R�[�f�B���O�A�F�ؓ�
                "��v���O���~���O": true/false   // �v���O���~���O�ȊO�̘b��
              }
            }

            �e�g�s�b�N�̓��[�U�[�̎���Ɋ֘A���邩�ǂ�����true�܂���false�Ŏ����Ă��������B
            ���[�U�[�̓��͓��e�𕪐͂��A�Y������g�s�b�N�ɂ�true���A�Y�����Ȃ��g�s�b�N�ɂ�false��ݒ肵�Ă��������B
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
