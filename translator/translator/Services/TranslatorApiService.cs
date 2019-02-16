using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace translator.Services
{
    public class TranslatorApiService
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<string> CallTranslatorApi(string word)
        {
            HttpResponseMessage response = await _client.GetAsync($"https://en-arab-dictionary-api.herokuapp.com/api/translator?word={word}");
            var json = await response.Content.ReadAsStringAsync();
            return await ParseResult(json);
        }

        public Task<string> ParseResult(string input)
        {
            JObject json = JObject.Parse(input);
            return Task.FromResult(json["word"].ToString());
        }
    }
}
