namespace WinFormsBlazorApp.Services
{
    internal interface IChatService
    {
        Task<string> SendMessageAsync(string userInput);
        void ClearHistory();
    }
}
