using Azure.AI.OpenAI;
using Azure;
using OpenAI.Chat;
using System.Text.Json;

namespace WinFormsBlazorApp.Services
{
    internal class AzureOpenAIChatService : IChatService
    {
        private readonly ChatClient _chatClient;
        private readonly List<ChatMessage> _conversationHistory;
        private readonly string _systemPrompt;

        // レスポンスの構造を表すクラス
        public class ChatResponse
        {
            public string Answer { get; set; } = "";
            public Dictionary<string, bool> Topics { get; set; } = new Dictionary<string, bool>();
        }

        public AzureOpenAIChatService(string endpoint, string apiKey, string deploymentName, string systemPrompt)
        {
            // Azure OpenAI クライアントの初期化
            var azureClient = new AzureOpenAIClient(
                new Uri(endpoint),
                new AzureKeyCredential(apiKey));

            // チャットクライアントの取得
            _chatClient = azureClient.GetChatClient(deploymentName);
            _conversationHistory = new List<ChatMessage>();

            // システムプロンプトの設定
            _systemPrompt = systemPrompt;

            // システムプロンプトを履歴に追加
            ClearHistory();
        }

        public async Task<string> SendMessageAsync(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
                throw new ArgumentNullException(nameof(userInput), "メッセージが空です。");

            // ユーザメッセージを履歴に追加
            _conversationHistory.Add(new UserChatMessage(userInput));

            // JSONフォーマットのレスポンスを指定するオプションを設定
            var options = new ChatCompletionOptions
            {
                ResponseFormat = ChatResponseFormat.CreateJsonObjectFormat()
            };

            // チャット完了リクエスト
            ChatCompletion completion = await _chatClient.CompleteChatAsync(_conversationHistory, options);
            string responseText = completion.Content[0].Text;

            // JSON応答の解析
            try
            {
                var chatResponse = JsonSerializer.Deserialize<ChatResponse>(responseText);
                if (chatResponse != null)
                {
                    // トピック情報を文字列として生成
                    string topicInfo = "（トピック: ";
                    var activeTopics = chatResponse.Topics.Where(t => t.Value).Select(t => t.Key);
                    topicInfo += string.Join(", ", activeTopics);
                    topicInfo += "）";

                    // 回答とトピック情報を組み合わせた応答を作成
                    string finalResponse = chatResponse.Answer + Environment.NewLine + topicInfo;

                    // アシスタントの応答を履歴に追加
                    _conversationHistory.Add(new AssistantChatMessage(finalResponse));
                    return finalResponse;
                }
            }
            catch
            {
                // JSON解析に失敗した場合は、元のテキストをそのまま返す
            }

            // JSON解析に失敗した場合、元のテキストを使用
            _conversationHistory.Add(new AssistantChatMessage(responseText));
            return responseText;
        }

        public void ClearHistory()
        {
            // 履歴をクリアし、システムプロンプトを先頭へ追加
            _conversationHistory.Clear();
            if (!string.IsNullOrEmpty(_systemPrompt))
            {
                _conversationHistory.Add(new SystemChatMessage(_systemPrompt));
            }
        }
    }
}