using SIRECE.Models;

namespace SIRECE.Services
{
    /// <summary>
    /// Serviço responsável por gerenciar a lista de alertas emitidos.
    /// </summary>
    public static class AlertaService
    {
        private static List<AlertaEmergencia> alertas = new();

        /// <summary>
        /// Exibe todos os alertas emitidos no console.
        /// </summary>
        public static void ListarAlertas()
        {
            Console.WriteLine("\n--- Alertas Emitidos ---");

            if (alertas.Count == 0)
            {
                Console.WriteLine("Nenhum alerta emitido ainda.");
                return;
            }

            foreach (var alerta in alertas)
            {
                Console.WriteLine(alerta);
            }
        }


        /// <summary>
        /// Retorna a lista de alertas emitidos.
        /// </summary>
        /// <returns>Lista de <see cref="AlertaEmergencia"/>.</returns>
        public static List<AlertaEmergencia> ObterAlertas()
        {
            return alertas;
        }


        /// <summary>
        /// Adiciona um novo alerta à lista de alertas emitidos.
        /// </summary>
        /// <param name="alerta">Alerta a ser adicionado.</param>
        public static void AdicionarAlerta(AlertaEmergencia alerta)
        {
            alertas.Add(alerta);
        }
    }
}
