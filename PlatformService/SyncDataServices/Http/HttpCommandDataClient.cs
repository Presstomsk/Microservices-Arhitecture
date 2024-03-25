namespace PlatformService.SyncDataServices.Http
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using PlatformService.Dtos;

    public class HttpCommandDataClient : ICommandDataClient
    {
        #region Fields

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructors

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        #endregion

        #region Methods

        public async Task SendPlatformToCommand(PlatformReadDto platform)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(platform),
                Encoding.UTF8,
                "application/json"
            );
            var response = await _httpClient.PostAsync(
                _configuration["CommandService"],
                httpContent
            );

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to Command Service was OK!");
            }
            else
            {
                Console.WriteLine("--> Sync POST to Command Service was NOT OK!");
            }
        }

        #endregion
    }
}
