using IntegrationOpenAI.Completion;

internal class Program
{
    private static async Task Main(string[] args)
    {
		Console.WriteLine("OpenAI Completion Examples:");

		CompletionDemonstrator completion = new CompletionDemonstrator();
		await completion.CountryListInJSONWithSchema();
	}
}