using OpenAI_API;
using OpenAI_API.Models;

namespace IntegrationOpenAI.Completion
{
	public class CompletionDemonstrator
    {
        OpenAIAPI api = new OpenAIAPI("your-openai-api-key");

        public async Task CreativeIdeas()
        {
            string prompt = "Generate five creative ideas for a new marketing campaign.";

            var response = await api.Completions.CreateCompletionAsync(
                prompt,
                Model.DavinciText,
                max_tokens: 200,
                temperature: 0.5
            );

			string generatedIdeas = response.Completions[0].Text;

			Console.WriteLine("Generated Ideas:");
			Console.WriteLine("================");
			Console.WriteLine(generatedIdeas);
        }

        public async Task CodeRefactoring()
        {
			string prompt = "Refactor the following C# function to make it more efficient:\n\n" +
							"```csharp\n" +
							"public int CalculateFactorial(int n)\n" +
							"{\n" +
							"    if (n == 0)\n" +
							"        return 1;\n" +
							"    else\n" +
							"        return n * CalculateFactorial(n-1);\n" +
							"}\n" +
							"```";

			var response = await api.Completions.CreateCompletionAsync(
					prompt,
					Model.DavinciText,
					max_tokens: 150,
					temperature: 0.7
			);

			string refactoredCode = response.Completions[0].Text;

			Console.WriteLine("Refactored C# Code:");
			Console.WriteLine("===================");
			Console.WriteLine(refactoredCode);
		}

        public async Task WritingSalesCopy()
        {
			string prompt = "Write a compelling product description for a high-end smartwatch.";

			var response = await api.Completions.CreateCompletionAsync(
					prompt,
					Model.DavinciText,
					max_tokens: 200,
					temperature: 0.6
			);

			string productDescription = response.Completions[0].Text;

			Console.WriteLine("Product Description:");
			Console.WriteLine("====================");
			Console.WriteLine(productDescription);
		}

        public async Task CountryListInJSON()
        {
			string prompt = "Generate the list of countries with capital in JSON format.";

			var response = await api.Completions.CreateCompletionAsync(
					prompt,
					Model.DavinciText,
					max_tokens: 200
			);

			string countries = response.Completions[0].Text;

			Console.WriteLine("List of countries in JSON format:");
			Console.WriteLine("====================");
			Console.WriteLine(countries);
		}

		public async Task CountryListInJSONWithSchema()
		{
			string prompt = "Generate the list of countries with capital in JSON format using following schema " +
							"""{"Country":"string", "Capital":"string",}""";

			var response = await api.Completions.CreateCompletionAsync(
					prompt,
					Model.DavinciText,
					max_tokens: 200
			);

			string countries = response.Completions[0].Text;

			Console.WriteLine("List of countries in JSON format:");
			Console.WriteLine("====================");
			Console.WriteLine(countries);
		}
    }
}