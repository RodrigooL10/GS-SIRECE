namespace SIRECE.Models
{
    /// <summary>
    /// Representa um evento de log do sistema.
    /// </summary>
    public class LogEvento
    {
        /// <summary>
        /// Data e hora em que o evento foi registrado.
        /// </summary>
        public DateTime DataHora { get; }

        /// <summary>
        /// Descrição da ação registrada no log.
        /// </summary>
        public string Acao { get; }


        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="LogEvento"/>.
        /// </summary>
        /// <param name="acao">Ação realizada no sistema.</param>
        public LogEvento(string acao)
        {
            DataHora = DateTime.Now;
            Acao = acao;
        }

        /// <summary>
        /// Retorna uma representação em string do log.
        /// </summary>
        /// <returns>Data e descrição da ação.</returns>
        public override string ToString()
        {
            return $"[{DataHora:dd/MM/yyyy HH:mm:ss}] {Acao}";
        }
    }
}
