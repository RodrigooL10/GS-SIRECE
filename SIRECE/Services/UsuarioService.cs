using SIRECE.Models;

namespace SIRECE.Services
{
    /// <summary>
    /// Serviço responsável por autenticar usuários do sistema.
    /// </summary>
    public static class UsuarioService
    {
        private static List<Usuario> usuarios = new()
        {
            new Usuario("admin", "1234"),
        };

        /// <summary>
        /// Valida o login de um usuário com base no nome e senha.
        /// </summary>
        /// <param name="nome">Nome do usuário.</param>
        /// <param name="senha">Senha do usuário.</param>
        /// <returns>True se as credenciais forem válidas; caso contrário, false.</returns>
        public static bool Login(string nome, string senha)
        {
            return usuarios.Exists(u => u.Nome == nome && u.Senha == senha);
        }
    }
}
