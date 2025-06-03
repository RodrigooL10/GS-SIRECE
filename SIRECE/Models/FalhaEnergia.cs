namespace SIRECE.Models
{
    /// <summary>
    /// Representa uma falha no fornecimento de energia detectada no sistema.
    /// </summary>
    public class FalhaEnergia
    {
        /// <summary>
        /// Local onde ocorreu a falha.
        /// </summary>
        public string Local { get; private set; }

        /// <summary>
        /// Data e hora da ocorrência da falha.
        /// </summary>
        public DateTime DataOcorrencia { get; private set; }

        /// <summary>
        /// Gravidade da falha: Baixa, Média ou Alta.
        /// </summary>
        public string Gravidade { get; private set; }

        /// <summary>
        /// Origem da falha: Sensor de Vento, Inundação, Temperatura, etc.
        /// </summary>
        public string Origem { get; private set; }


        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="FalhaEnergia"/>.
        /// </summary>
        /// <param name="local">Local da falha.</param>
        /// <param name="data">Data e hora da ocorrência.</param>
        /// <param name="gravidade">Gravidade da falha.</param>
        /// <param name="origem">Origem da falha.</param>
        public FalhaEnergia(string local, DateTime data, string gravidade, string origem)
        {
            if (string.IsNullOrWhiteSpace(local))
                throw new ArgumentException("Local não pode estar vazio.");

            if (string.IsNullOrWhiteSpace(gravidade))
                throw new ArgumentException("Gravidade não pode estar vazia.");

            if (string.IsNullOrWhiteSpace(origem))
                throw new ArgumentException("Origem não pode estar vazia.");

            Local = local;
            DataOcorrencia = data;
            Gravidade = gravidade;
            Origem = origem;
        }

        /// <summary>
        /// Retorna uma representação em string da falha.
        /// </summary>
        /// <returns>Texto descritivo com data, local, gravidade e origem.</returns>
        public override string ToString()
        {
            return $"{DataOcorrencia:dd/MM/yyyy HH:mm} - {Local} - Gravidade: {Gravidade} - Origem: {Origem}";
        }
    }
}
