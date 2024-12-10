
using System.Text.Json.Nodes;

namespace Permutation.BackEnd
{
    public static class DictionaryApi
    {
        private static HttpClient _httpClient = new();

        public static async Task<bool> WordExists(string word)
        {
            try
            {
                using HttpResponseMessage response = await _httpClient.GetAsync(
                    $"https://dictionaryapi.com/api/v3/references/collegiate/json/{word}?key=a09970c7-421c-4da1-b696-922bbbad77ed");
                response.EnsureSuccessStatusCode();
                var responseStr = await response.Content.ReadAsStringAsync();
                var jsonNode = JsonNode.Parse(responseStr);

                try
                {
                    var idNode = jsonNode![0]![0]![0];
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }
    }
}
