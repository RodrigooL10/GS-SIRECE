namespace SIRECE.Models
{
    /// <summary>
    /// Representa um usuário do sistema com nome e senha.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Nome do usuário.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Senha do usuário.
        /// </summary>
        public string Senha { get; set; }


        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Usuario"/>.
        /// </summary>
        /// <param name="nome">Nome de login do usuário.</param>
        /// <param name="senha">Senha de acesso do usuário.</param>
        public Usuario(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }
    }
}

