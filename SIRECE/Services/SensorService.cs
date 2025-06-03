using SIRECE.Models;

namespace SIRECE.Services
{
    /// <summary>
    /// Serviço responsável por simular falhas usando sensores.
    /// </summary>
    public static class SensorService
    {
        private static List<Sensor> sensores = new()
        {
            new SensorVento(),
            new SensorTemperatura()
        };

        /// <summary>
        /// Simula falhas em todos os sensores registrados no sistema.
        /// </summary>
        public static void SimularFalhas()
        {
            Console.WriteLine("\n--- Simulação de Falhas via Sensores ---");

            foreach (var sensor in sensores)
            {
                try
                {
                    var falha = sensor.GerarFalha();
                    FalhaService.AdicionarFalha(falha);

                    Console.WriteLine($"✅ {sensor.Nome} detectou falha: {falha}");
                    LogService.Registrar($"Falha simulada pelo {sensor.Nome} em {falha.Local}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Erro ao simular falha no sensor {sensor.Nome}: {ex.Message}");
                    LogService.Registrar($"Erro ao simular falha no sensor {sensor.Nome}: {ex.Message}");
                }
            }
        }
    }
}
