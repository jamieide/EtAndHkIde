using System.Net.Http.Json;
using System.Text.Json;

namespace EtAndHkIde.CLI.Zotero
{
    public class ZoteroLocalApiService
    {
        private readonly HttpClient _httpClient;

        public ZoteroLocalApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:23119/")
            };
#if DEBUG
            _httpClient.Timeout = TimeSpan.FromMinutes(10);
#endif
        }

        public async Task<ZoteroCollection> GetCollectionAsync(string collectionKey)
        {
            using var response = await _httpClient.GetAsync($"api/users/0/collections/{collectionKey}");
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<ZoteroCollection>())!;
        }

        public async Task<IEnumerable<ZoteroCollection>> GetSubCollectionsAsync(string collectionKey)
        {
            using var response = await _httpClient.GetAsync($"api/users/0/collections/{collectionKey}/collections");
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<ZoteroCollection[]>())!;
        }

        public async Task<IEnumerable<ZoteroItem>> GetItemsByCollectionAsync(string collectionKey)
        {
            using var response = await _httpClient.GetAsync($"api/users/0/collections/{collectionKey}/items");
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<IEnumerable<ZoteroItem>>())!;
        }

        public async Task<IDictionary<string, string>> GetItemTypesAsync()
        {
            using var response = await _httpClient.GetAsync($"api/itemTypes");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadFromJsonAsync<JsonElement>();
            return json.EnumerateArray()
                .Select(x => new KeyValuePair<string, string>(x.GetProperty("itemType").GetString()!, x.GetProperty("localized").GetString()!))
                .ToDictionary();

        }

        public async Task<IDictionary<string, string>> GetItemTypeFieldsAsync(string itemType)
        {
            using var response = await _httpClient.GetAsync($"api/itemTypeFields?itemType={itemType}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadFromJsonAsync<JsonElement>();
            return json.EnumerateArray()
                .Select(x => new KeyValuePair<string, string>(x.GetProperty("field").GetString()!, x.GetProperty("localized").GetString()!))
                .ToDictionary();
        }

    }
}
