using Azure.AI.OpenAI;
using Azure;
using OpenAI.Chat;

namespace WinFormsBlazorApp.Services
{
    internal class AzureOpenAIChatService : IChatService
    {
        private readonly ChatClient _chatClient;
        private readonly List<ChatMessage> _conversationHistory;

        public AzureOpenAIChatService(string endpoint, string apiKey, string deploymentName)
        {
            // Azure OpenAI クライアントの初期化
            var azureClient = new AzureOpenAIClient(
                new Uri(endpoint),
                new AzureKeyCredential(apiKey));

            // チャットクライアントの取得
            _chatClient = azureClient.GetChatClient(deploymentName);
            _conversationHistory = new List<ChatMessage>();
        }

        public async Task<string> SendMessageAsync(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
                throw new ArgumentNullException(nameof(userInput), "メッセージが空です。");

            // ユーザーメッセージを履歴に追加
            _conversationHistory.Add(new UserChatMessage(userInput));

            // チャット完了リクエスト
            ChatCompletion completion = await _chatClient.CompleteChatAsync(_conversationHistory);

            // アシスタントの応答を履歴に追加
            _conversationHistory.Add(new AssistantChatMessage(completion));

            // レスポンステキストを返す
            return completion.Content[0].Text;
        }

        public void ClearHistory()
        {
            _conversationHistory.Clear();
        }
    }
}
