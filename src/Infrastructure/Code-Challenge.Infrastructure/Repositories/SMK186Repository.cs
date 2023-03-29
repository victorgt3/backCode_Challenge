using Code_Challenge.Domain.Interface;
using Code_Challenge.Domain.Model;
using Newtonsoft.Json;

namespace Code_Challenge.Infrastructure.Repositories
{
    public class SMK186Repository : ISMK186Repository
    {
        private readonly IHttpClientFactory _clientFactory;
        public SMK186Repository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Minerais> GetMineraisAsync(PayloadMinerais payload,CancellationToken cancellationToken)
        {
            try
            {
                var client = _clientFactory.CreateClient("SMK186");

                var url = $"minerais?mes={payload.Mes}&ano={payload.Ano}&semana={payload.Semana}";

                var httpResponse = await client.GetAsync(url, cancellationToken);

                httpResponse.EnsureSuccessStatusCode();

                var response = await httpResponse.Content.ReadAsStringAsync(cancellationToken);

                var minerais = JsonConvert.DeserializeObject<Minerais>(response);

                return minerais;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro.: {ex.Message}");
            }
        }
    }
}
