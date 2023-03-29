using Code_Challenge.Domain.Model;

namespace Code_Challenge.Application.Interface
{
    public interface ISMK186Service
    {
        /// <summary>
        /// Obter lista de minerais.
        /// </summary>
        /// <param name="payload">Criterios de pequisa</param>
        /// <returns>
        /// Lista de quantidade de minerias por semana.
        /// </returns>
        Task<List<DtoMinerais>> GetMineraisAsync(DtoMinerais payload, CancellationToken cancellationToken);
     }
}
