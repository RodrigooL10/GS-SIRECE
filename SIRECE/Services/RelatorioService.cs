namespace SIRECE.Services
{
    /// <summary>
    /// Serviço responsável por gerar e exportar relatórios com estatísticas do sistema.
    /// </summary>
    public static class RelatorioService
    {
        /// <summary>
        /// Gera o relatório de falhas exibindo no console e pergunta se deseja exportar para arquivo .txt.
        /// </summary>
        public static void GerarRelatorio()
        {
            Console.WriteLine("\n--- Relatório do Sistema ---");

            var totalFalhas = FalhaService.ObterFalhas().Count();
            var falhas = FalhaService.ObterFalhas();

            var falhasAlta = falhas.Count(f => f.Gravidade.Equals("alta", StringComparison.OrdinalIgnoreCase));
            var falhasMedia = falhas.Count(f => f.Gravidade.Equals("média", StringComparison.OrdinalIgnoreCase));
            var falhasBaixa = falhas.Count(f => f.Gravidade.Equals("baixa", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"Total de falhas e alertas registrados: {totalFalhas}");
            Console.WriteLine($" - Alta: {falhasAlta}");
            Console.WriteLine($" - Média: {falhasMedia}");
            Console.WriteLine($" - Baixa: {falhasBaixa}");

            LogService.Registrar("Relatório gerado no console.");

            Console.Write("\nDeseja exportar esse relatório para um arquivo TXT? (s/n): ");
            string resposta = Console.ReadLine();

            if (resposta.Trim().ToLower() == "s")
            {
                ExportarRelatorioParaTxt(totalFalhas, falhasAlta, falhasMedia, falhasBaixa);
            }
        }


        /// <summary>
        /// Exporta o relatório de falhas para um arquivo .txt na pasta Downloads.
        /// </summary>
        /// <param name="total">Total de falhas.</param>
        /// <param name="alta">Total de falhas graves.</param>
        /// <param name="media">Total de falhas médias.</param>
        /// <param name="baixa">Total de falhas leves.</param>
        private static void ExportarRelatorioParaTxt(int total, int alta, int media, int baixa)
        {
            string nomeArquivo = $"Relatorio_SIRECE_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string downloadsPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"Downloads");

            string pathCompleto = Path.Combine(downloadsPath, nomeArquivo);

            using (StreamWriter writer = new StreamWriter(pathCompleto))
            {
                writer.WriteLine("Relatório do Sistema - SIRECE");
                writer.WriteLine($"Data de geração: {DateTime.Now:dd/MM/yyyy HH:mm}");
                writer.WriteLine("----------------------------------------");
                writer.WriteLine($"Total de falhas registradas: {total}");
                writer.WriteLine($" - Alta: {alta}");
                writer.WriteLine($" - Média: {media}");
                writer.WriteLine($" - Baixa: {baixa}");
                writer.WriteLine("----------------------------------------");
            }

            Console.WriteLine($"\n📁 Relatório exportado com sucesso para:\n{pathCompleto}");
            LogService.Registrar("Relatório exportado para TXT.");
        }
    }
}