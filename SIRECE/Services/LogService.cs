using SIRECE.Models;

namespace SIRECE.Services
{
    /// <summary>
    /// Serviço responsável por registrar e exibir logs do sistema.
    /// </summary>
    public static class LogService
    {
        private static List<LogEvento> logs = new();

        /// <summary>
        /// Registra uma nova ação no log.
        /// </summary>
        /// <param name="acao">Descrição da ação a ser registrada.</param>
        public static void Registrar(string acao)
        {
            var log = new LogEvento(acao);
            logs.Add(log);
        }

        /// <summary>
        /// Exibe todos os logs registrados no sistema.
        /// </summary>
        public static void MostrarLogs()
        {
            Console.WriteLine("\n--- LOGS DO SISTEMA ---");
            if (logs.Count == 0)
            {
                Console.WriteLine("Nenhum log registrado ainda.");
                return;
            }

            foreach (var log in logs)
            {
                Console.WriteLine(log);
            }
        }
    }
}
