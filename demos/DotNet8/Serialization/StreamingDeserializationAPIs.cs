using System.Net.Http.Json;

namespace TaleLearnCode.NewHorizons.DotNet8.Serialization;

public record Book(int id, string title, string author, int publishedYear);

public class StreamingDeserializationAPIs
{

	public static async Task DemoAsync()
	{
		const string RequestUri = "https://api.contoso.com/books";
		using var client = new HttpClient();
		IAsyncEnumerable<Book?> books = client.GetFromJsonAsAsyncEnumerable<Book>(RequestUri);

		await foreach (Book? book in books)
			if (book is not null)
				Console.WriteLine($"Read book '{book.title}'");
	}

}