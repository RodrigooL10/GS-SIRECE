using SIRECE.Models;

namespace SIRECE.Services
{
    /// <summary>
    /// Serviço responsável pelo registro e gerenciamento de falhas energéticas.
    /// </summary>
    public static class FalhaService
    {
        private static List<FalhaEnergia> falhas = new();

        /// <summary>
        /// Solicita dados do usuário para registrar uma nova falha via console.
        /// </summary>
        public static void RegistrarFalha()
        {
            try
            {
                Console.Write("\nInforme o local da falha: ");
                string local = Console.ReadLine();

                DateTime data = DateTime.Now;

                Console.Write("Informe a gravidade (baixa, média, alta): ");
                string gravidade = Console.ReadLine();

                Console.Write("Informe a origem (vento, temperatura, inundação, energia): ");
                string origem = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(local) || string.IsNullOrWhiteSpace(gravidade) || string.IsNullOrWhiteSpace(origem))
                {
                    throw new ArgumentException("Todos os campos são obrigatórios.");
                }

                AdicionarFalha(new FalhaEnergia(local, data, gravidade, origem));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\n❌ Erro: {ex.Message}");
                LogService.Registrar($"Erro ao registrar falha: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Erro inesperado: {ex.Message}");
                LogService.Registrar($"Erro inesperado ao registrar falha: {ex.Message}");
            }
        }

        /// <summary>
        /// Adiciona uma nova falha e gera um alerta automático correspondente.
        /// </summary>
        /// <param name="falha">Instância de <see cref="FalhaEnergia"/> contendo os dados da falha.</param>
        public static void AdicionarFalha(FalhaEnergia falha)
        {
            falhas.Add(falha);

            Console.WriteLine("\n✅ Falha registrada com sucesso!");
            LogService.Registrar($"Falha registrada em {falha.Local}, gravidade {falha.Gravidade}, origem {falha.Origem}");

            string tipoAlerta;
            string destinatario;

            if (falha.Origem.Contains("vento", StringComparison.OrdinalIgnoreCase))
            {
                tipoAlerta = "Falha por Ventania";
                destinatario = "Defesa Civil";
            }
            else if (falha.Origem.Contains("temperatura", StringComparison.OrdinalIgnoreCase))
            {
                tipoAlerta = "Falha por Calor Extremo";
                destinatario = "Hospitais";
            }
            else if (falha.Origem.Contains("inundação", StringComparison.OrdinalIgnoreCase))
            {
                tipoAlerta = "Falha por Alagamento";
                destinatario = "Corpo de Bombeiros";
            }
            else
            {
                tipoAlerta = "Falha Elétrica";
                destinatario = "Concessionária de Energia";
            }

            var alertaAuto = new AlertaEmergencia(
                tipo: tipoAlerta,
                destinatario: destinatario,
                prioridade: falha.Gravidade,
                local: falha.Local
            );

            AlertaService.AdicionarAlerta(alertaAuto);

            Console.WriteLine($"🚨 Alerta automático enviado para {destinatario}");
            LogService.Registrar($"Alerta gerado automaticamente para {destinatario} com prioridade {falha.Gravidade}");
        }

        /// <summary>
        /// Exibe todas as falhas registradas no console.
        /// </summary>
        public static void ListarFalhas()
        {
            Console.WriteLine("\n--- Falhas Registradas ---");

            if (falhas.Count == 0)
            {
                Console.WriteLine("Nenhuma falha registrada.");
                return;
            }

            foreach (var falha in falhas)
            {
                Console.WriteLine(falha);
            }
        }

        /// <summary>
        /// Retorna a lista de falhas registradas.
        /// </summary>
        /// <returns>Lista de <see cref="FalhaEnergia"/>.</returns>
        public static List<FalhaEnergia> ObterFalhas()
        {
            return falhas;
        }
    }
}
