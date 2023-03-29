using Code_Challenge.Application.Interface;
using Code_Challenge.Domain.Emuns;
using Code_Challenge.Domain.Interface;
using Code_Challenge.Domain.Model;

namespace Code_Challenge.Application.Services
{
    public class SMK186Service : ISMK186Service
    {
        private readonly ISMK186Repository _repository;
        public SMK186Service(ISMK186Repository repository)
        {
            _repository = repository;
        }
        public async Task<List<DtoMinerais>> GetMineraisAsync(DtoMinerais payload, CancellationToken cancellationToken)
        {

            if (ValidacaoDataHora(payload.DataSaida))
                throw new InvalidOperationException("O cargueiro não pode ser carregado aos domingos e horario precisa ser maior que as 08:00.");

            List<DtoMinerais> result = new();

            PayloadMinerais minerais = new()
            {
                Ano = payload.DataSaida.Year,
                Mes = payload.DataSaida.Month,
                Semana = (int)SemanaMes(payload.DataSaida.Day),
            };

            var quantidadeMinerias = await _repository.GetMineraisAsync(minerais, cancellationToken);
            
            foreach(var tipoCargueiro in payload.TipoCargueiro)
            {
                switch (tipoCargueiro)
                {
                    case TipoCargueiro.Inflamavel:
                    {
                       result.AddRange(CalculoInflamavel(quantidadeMinerias.A, payload));
                            continue;
                    }

                    case TipoCargueiro.Refrigerado:
                    {
                        result.AddRange(CalculoRiscoBiologico(quantidadeMinerias.B, payload));
                            continue;
                    }

                    case TipoCargueiro.RiscoBiologico:
                    {
                        result.AddRange(CalculoRefrigerado(quantidadeMinerias.C, payload));
                            continue;   
                    }
                    case TipoCargueiro.SemCaracteristicasEspeciais:
                    {
                        result.AddRange(CalculoSemCaracteristicasEspeciais(quantidadeMinerias.D, payload));
                            continue;   
                    }
                }
            }

            return result;
        }


        public static List<DtoMinerais> CalculoInflamavel(float quantidadeMineriasInflamavel, DtoMinerais minerais)
        {
            var listaMineris = new List<DtoMinerais>();
            int quantidade = 10;
            var quant = quantidadeMineriasInflamavel / quantidade;
            var valorTotal = quant * 5000;
            var tipoCargueiro = new List<TipoCargueiro>
            {
                TipoCargueiro.Inflamavel
            };

            for(var index = 0; index <= quantidade; index++)
            {
                listaMineris.Add(new DtoMinerais()
                {
                    DataSaida = minerais.DataSaida,
                    DataRetorno = minerais.DataRetorno,
                    TipoCargueiro = tipoCargueiro,
                    ValorTotalCarga = valorTotal,
                    QuantidadeCarga = 10
                });
            }
            return listaMineris;
        }

        private static List<DtoMinerais> CalculoRiscoBiologico(float quantidadeMineriasRiscoBiologico, DtoMinerais minerais)
        {
            var listaMineris = new List<DtoMinerais>();
            int quantidade = 2;
            var quant = quantidadeMineriasRiscoBiologico / quantidade;
            var valorTotal = quant * 10000;
            var tipoCargueiro = new List<TipoCargueiro>
            {
                TipoCargueiro.RiscoBiologico
            };

            for (var index = 0; index <= quantidade; index++)
            {
                listaMineris.Add(new DtoMinerais()
                {
                    DataSaida = minerais.DataSaida,
                    DataRetorno = minerais.DataRetorno,
                    TipoCargueiro = tipoCargueiro,
                    ValorTotalCarga = valorTotal,
                    QuantidadeCarga = 10
                });
            }
            return listaMineris;

        }

        private static List<DtoMinerais> CalculoRefrigerado(float quantidadeMineriasRefrigerado, DtoMinerais minerais)
        {
            var listaMineris = new List<DtoMinerais>();
            int quantidade = 2;
            var quant = quantidadeMineriasRefrigerado / quantidade;
            var valorTotal = quant * 30000;
            var tipoCargueiro = new List<TipoCargueiro>
            {
                TipoCargueiro.Refrigerado
            };

            for (var index = 0; index <= quantidade; index++)
            {
                listaMineris.Add(new DtoMinerais()
                {
                    DataSaida = minerais.DataSaida,
                    DataRetorno = minerais.DataRetorno,
                    TipoCargueiro = tipoCargueiro,
                    ValorTotalCarga = valorTotal,
                    QuantidadeCarga = 10
                });
            }

            return listaMineris;
        }

        private static List<DtoMinerais> CalculoSemCaracteristicasEspeciais(float quantidadeMineriasSemCaracteristicasEspeciais, DtoMinerais minerais)
        {
            var listaMineris = new List<DtoMinerais>();
            int quantidade = 15;
            var quant = quantidadeMineriasSemCaracteristicasEspeciais / quantidade;
            var valorTotal = quant * 100;
            var tipoCargueiro = new List<TipoCargueiro>
            {
                TipoCargueiro.SemCaracteristicasEspeciais
            };

            for (var index = 0; index <= quantidade; index++)
            {
                listaMineris.Add(new DtoMinerais()
                {
                    DataSaida = minerais.DataSaida,
                    DataRetorno = minerais.DataRetorno,
                    TipoCargueiro = tipoCargueiro,
                    ValorTotalCarga = valorTotal,
                    QuantidadeCarga = 10
                });
            }
            return listaMineris;
        }

        // Validação se domingo e horario de saida.
        private static bool ValidacaoDataHora(DateTime dateTime)
        {
            DateTime dateRegra = Convert.ToDateTime("08:00:00.0000");

            if (dateTime.DayOfWeek.ToString() == "Sunday" && dateTime.TimeOfDay <= dateRegra.TimeOfDay)
                return true; 
            
            return false;
        }

        // divisão da semana
        private static double SemanaMes(int mes)
        {
            if (mes > 28)
                mes = 28;

            return Math.Ceiling(mes / 7d);
        }
    }
}
