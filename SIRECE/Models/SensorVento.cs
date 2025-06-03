namespace SIRECE.Models
{
    /// <summary>
    /// Representa um sensor de vento que simula falhas relacionadas a ventanias.
    /// </summary>
    public class SensorVento : Sensor
    {
        private static readonly string[] locais = { "Zona Norte", "Centro", "Zona Sul", "Zona Leste", "Zona Oeste" };
        private static readonly string[] gravidades = { "alta", "média", "baixa" };

        private static readonly Random rnd = new();

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="SensorVento"/>.
        /// </summary>
        public SensorVento() : base("Sensor de Vento") { }


        /// <summary>
        /// Gera uma falha simulada de vento com dados aleatórios.
        /// </summary>
        /// <returns>Instância de <see cref="FalhaEnergia"/> com dados simulados.</returns>
        public override FalhaEnergia GerarFalha()
        {
            string local = locais[rnd.Next(locais.Length)];
            string gravidade = gravidades[rnd.Next(gravidades.Length)];
            DateTime agora = DateTime.Now;

            return new FalhaEnergia(local, agora, gravidade, Nome);
        }
    }
}
