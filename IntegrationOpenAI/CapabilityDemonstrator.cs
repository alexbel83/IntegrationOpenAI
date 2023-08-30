using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

namespace IntegrationOpenAI.Introduction
{
    public class CapabilityDemonstrator
    {
        OpenAIAPI api = new OpenAIAPI("your-openai-api-key");

        public async Task ContentGeneration()
        {
            string prompt = "Generate a product description for a cozy winter sweater.";

            var response = await api.Completions.CreateCompletionAsync(prompt, temperature: 0.7, max_tokens: 50);

            Console.WriteLine(response.Completions[0].Text);
        }

        public async Task CodeGeneration()
        {
            string prompt = "Create a C# function to calculate the factorial of a number.";

            var response = await api.Completions.CreateCompletionAsync(prompt, max_tokens: 100);

            Console.WriteLine(response.Completions[0].Text);
        }

        public async Task LanguageTranslation()
        {
            string translateText = "May the Force be with you!";

            var chatMessages = new List<ChatMessage>()
            {
                new ChatMessage(ChatMessageRole.System,
                "You will receive an English sentence and your task is to translate it into Spanish."),
                  //  "You will be provided with a sentence in English, and your task is to translate it into Spanish."),
                new ChatMessage(ChatMessageRole.User, translateText)
            };

            ChatRequest request = new ChatRequest()
            {
                Messages = chatMessages,
                Model = Model.ChatGPTTurbo,
                Temperature = 0,
                TopP = 1,
                FrequencyPenalty = 0,
                PresencePenalty = 0
            };

            var response = await api.Chat.CreateChatCompletionAsync(request);

            Console.WriteLine($"English Sentence: {translateText}");
            Console.WriteLine($"Translated Sentence: {response.Choices[0].Message.Content}");
        }

        public async Task ConversationalAgent()
        {
            var messages = new List<ChatMessage>()
            {
                new ChatMessage(ChatMessageRole.User, "Hello, what can you do?"),
                new ChatMessage(ChatMessageRole.Assistant, "I'm an AI language model. I can help you with text generation, code-related tasks, language translation, and more."),
                new ChatMessage(ChatMessageRole.User, "That's impressive! Can you give me an example of code generation in C#?"),
                new ChatMessage(ChatMessageRole.Assistant, "Sure! Here's a C# code snippet to calculate the factorial of a number:"),
            };

            var response = await api.Chat.CreateChatCompletionAsync(messages);

            foreach (var message in response.Choices)
            {
                Console.WriteLine(message.Message.Content);
            }
        }
    }
}