using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;

namespace AzureOpenAISample
{
    class Program
    {
        // Azure OpenAI 設定
        private static readonly string? Endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT");
        private static readonly string? ApiKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_KEY");
        private static readonly string? DeploymentName = Environment.GetEnvironmentVariable("AZURE_OPENAI_DEPLOYMENT_NAME");

        static void Main(string[] args)
        {
            // 環境変数の確認
            if (string.IsNullOrEmpty(Endpoint))
            {
                Console.WriteLine("環境変数 AZURE_OPENAI_ENDPOINT が設定されていません。");
                return;
            }

            if (string.IsNullOrEmpty(ApiKey))
            {
                Console.WriteLine("環境変数 AZURE_OPENAI_KEY が設定されていません。");
                return;
            }

            if (string.IsNullOrEmpty(DeploymentName))
            {
                Console.WriteLine("環境変数 AZURE_OPENAI_DEPLOYMENT_NAME が設定されていません。");
                return;
            }

            // Azure OpenAI クライアントの初期化
            AzureOpenAIClient azureClient = new AzureOpenAIClient(
                new Uri(Endpoint),
                new AzureKeyCredential(ApiKey));

            // チャットクライアントの取得
            ChatClient chatClient = azureClient.GetChatClient(DeploymentName);

            // チャット履歴
            List<ChatMessage> conversationMessages = new List<ChatMessage>();

            Console.WriteLine("Azure OpenAIチャットコンソール (終了するには 'exit' と入力)");
            Console.WriteLine("-----------------------------------------------");

            while (true)
            {
                Console.Write("\nあなた: ");
                string? userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput) || userInput.ToLower() == "exit")
                    break;

                SystemChatMessage systemMessage = new SystemChatMessage(userInput);

                // ユーザーメッセージを履歴に追加
                conversationMessages.Add(new UserChatMessage(userInput));

                try
                {
                    // チャット完了リクエスト
                    ChatCompletion completion = chatClient.CompleteChat(conversationMessages);

                    // レスポンスの表示
                    Console.WriteLine($"\nアシスタント: {completion.Content[0].Text}");

                    // アシスタントの応答を履歴に追加
                    conversationMessages.Add(new AssistantChatMessage(completion));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nエラーが発生しました: {ex.Message}");
                }
            }
        }
    }
}