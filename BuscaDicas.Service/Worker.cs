

using BuscaDicas.Modelo;
using BuscaDicas.Service.Model;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BuscaDicas.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly HttpClient _httpClient;

        public Worker(ILogger<Worker> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient.CreateClient();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                var DicasModelReturn = await ObterDicas();
                var dicasModel = ConverterParaDicasModel(DicasModelReturn);
                await InserirDbInterno(dicasModel);

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

        private async Task InserirDbInterno(DicasModel dicasModel)
        {
            HttpResponseMessage r = await _httpClient.PostAsJsonAsync($"https://localhost:7272/api/Dicas", dicasModel);

        }

        private async Task<DicasModelReturn> ObterDicas()
        {
            HttpResponseMessage r = await _httpClient.GetAsync($"https://api.adviceslip.com/advice");

            if (r.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<DicasModelReturn>(await r.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(r.ReasonPhrase);
            }

        }

        private DicasModel ConverterParaDicasModel(DicasModelReturn dicasModelReturn)
        {
            DicasModel dicasModel = new DicasModel();

            dicasModel.Dicas = dicasModelReturn.Slip.advice;
            dicasModel.DataCriacao = DateTime.Now;

            return dicasModel;

        }

    }
}