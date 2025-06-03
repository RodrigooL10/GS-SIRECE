namespace SIRECE.Models
{
    /// <summary>
    /// Representa um alerta de emergência gerado a partir de uma falha energética.
    /// </summary>
    public class AlertaEmergencia
    {
        /// <summary>
        /// Tipo do alerta, como "Falha Elétrica" ou "Falha por Ventania".
        /// </summary>
        public string Tipo { get; private set; }

        /// <summary>
        /// Destinatário do alerta, como "Defesa Civil" ou "Hospitais".
        /// </summary>
        public string Destinatario { get; private set; }

        /// <summary>
        /// Prioridade do alerta: Alta, Média ou Baixa.
        /// </summary>
        public string Prioridade { get; private set; }

        /// <summary>
        /// Data e hora em que o alerta foi criado.
        /// </summary>
        public DateTime DataHora { get; private set; }

        /// <summary>
        /// Local associado à ocorrência da falha que gerou o alerta.
        /// </summary>
        public string Local { get; private set; }


        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="AlertaEmergencia"/>.
        /// </summary>
        /// <param name="tipo">Tipo do alerta.</param>
        /// <param name="destinatario">Destinatário do alerta.</param>
        /// <param name="prioridade">Prioridade do alerta.</param>
        /// <param name="local">Local da ocorrência da falha.</param>
        public AlertaEmergencia(string tipo, string destinatario, string prioridade, string local)
        {
            if (string.IsNullOrWhiteSpace(tipo)) throw new ArgumentException("Tipo do alerta inválido.");
            if (string.IsNullOrWhiteSpace(destinatario)) throw new ArgumentException("Destinatário inválido.");
            if (string.IsNullOrWhiteSpace(prioridade)) throw new ArgumentException("Prioridade inválida.");
            if (string.IsNullOrWhiteSpace(local)) throw new ArgumentException("Local inválido.");


            Tipo = tipo;
            Destinatario = destinatario;
            Prioridade = prioridade;
            DataHora = DateTime.Now;
            Local = local;
        }


        /// <summary>
        /// Retorna uma representação em string do alerta.
        /// </summary>
        /// <returns>Texto descritivo com data, tipo, destinatário, prioridade e local.</returns>
        public override string ToString()
        {
            return $"[{DataHora:dd/MM/yyyy HH:mm}] Tipo: {Tipo}, Para: {Destinatario}, Prioridade: {Prioridade}, Local: {Local}";
        }
    }
}
