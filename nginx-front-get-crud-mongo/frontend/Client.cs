using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace frontend
{
   public class Client
   {
      private readonly JsonSerializerOptions options = new JsonSerializerOptions()
      {
         PropertyNameCaseInsensitive = true,
         PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      };

      private readonly HttpClient client;
      private readonly ILogger<Client> _logger;

      public Client(HttpClient client, ILogger<Client> logger)
      {
         this.client = client;
         this._logger = logger;
      }

      public async Task<ClientInfo[]> GetClientsAsync()
      {
         try {
            var responseMessage = await this.client.GetAsync("/client");
            
            if(responseMessage!=null)
            {
               var stream = await responseMessage.Content.ReadAsStreamAsync();
               return await JsonSerializer.DeserializeAsync<ClientInfo[]>(stream, options);
            }
         }
         catch(HttpRequestException ex)
         {
            _logger.LogError(ex.Message);
            throw;
         }
         return new ClientInfo[] {};

      }
   }
}