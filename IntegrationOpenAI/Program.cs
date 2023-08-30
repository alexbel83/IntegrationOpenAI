using IntegrationOpenAI.Introduction;

internal class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("OpenAI Introduction Examples:");

        CapabilityDemonstrator capability = new CapabilityDemonstrator();
        await capability.LanguageTranslation();
    }
}