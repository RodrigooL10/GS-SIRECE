using SIRECE.Services;

namespace SIRECE
{
    /// <summary>
    /// Classe principal responsável por iniciar a aplicação SIRECE.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Ponto de entrada da aplicação. Responsável pelo login e chamada do menu principal.
        /// </summary>
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "SIRECE - Sistema Integrado de Resiliência Energética";
            Console.WriteLine("=== Bem-vindo ao SIRECE ===");

            bool logado = false;

            while (!logado)
            {
                Console.Write("Usuário: ");
                string usuario = Console.ReadLine();
                Console.Write("Senha: ");
                string senha = Console.ReadLine();

                if (UsuarioService.Login(usuario, senha))
                {
                    logado = true;
                    LogService.Registrar($"Login bem-sucedido para o usuário '{usuario}'");
                }
                else
                {
                    Console.WriteLine("Usuário ou senha inválidos. Tente novamente.\n");
                    LogService.Registrar($"Falha de login com usuário '{usuario}'");
                }
            }

            Console.WriteLine("\nLogin bem-sucedido!\n");
            MenuPrincipal();
        }

        /// <summary>
        /// Exibe o menu principal do sistema com as funcionalidades disponíveis.
        /// </summary>
        static void MenuPrincipal()
        {
            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("\n--- Menu Principal ---");
                Console.WriteLine("1. Registrar Falha");
                Console.WriteLine("2. Simular Sensor");
                Console.WriteLine("3. Gerar Relatório");
                Console.WriteLine("4. Ver Falhas");
                Console.WriteLine("5. Ver Logs");
                Console.WriteLine("6. Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();
                LogService.Registrar($"Menu: opção '{opcao}' selecionada");

                switch (opcao)
                {
                    case "1":
                        FalhaService.RegistrarFalha();
                        break;
                    case "2":
                        SensorService.SimularFalhas();
                        break;
                    case "3":
                        RelatorioService.GerarRelatorio();
                        break;
                    case "4":
                        FalhaService.ListarFalhas();
                        break;
                    case "5":
                        LogService.MostrarLogs();
                        break;
                    case "6":
                        sair = true;
                        Console.WriteLine("Saindo...");
                        LogService.Registrar("Usuário finalizou o programa.");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}
