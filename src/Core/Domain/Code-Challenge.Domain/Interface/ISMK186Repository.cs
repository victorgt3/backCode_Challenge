using Code_Challenge.Domain.Model;

namespace Code_Challenge.Domain.Interface
{
    public interface ISMK186Repository
    {
        /// <summary>
        /// Obter lista de minerais.
        /// </summary>
        /// <param name="payload">Criterios de pequisa</param>
        /// <returns>
        /// Lista de quantidade de minerias por semana.
        /// </returns>
        Task<Minerais> GetMineraisAsync(PayloadMinerais payload, CancellationToken cancellationToken);
     }
}
