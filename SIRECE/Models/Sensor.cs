namespace SIRECE.Models
{
    /// <summary>
    /// Classe abstrata que representa um sensor do sistema.
    /// </summary>
    public abstract class Sensor
    {
        /// <summary>
        /// Nome identificador do sensor.
        /// </summary>
        public string Nome { get; }


        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Sensor"/>.
        /// </summary>
        /// <param name="nome">Nome do sensor.</param>
        public Sensor(string nome)
        {
            Nome = nome;
        }

        /// <summary>
        /// Método abstrato responsável por gerar uma falha simulada.
        /// </summary>
        /// <returns>Uma nova instância de <see cref="FalhaEnergia"/>.</returns>
        public abstract FalhaEnergia GerarFalha();
    }
}
