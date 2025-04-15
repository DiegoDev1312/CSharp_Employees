using Funcionários.Entities;
using Funcionários.Exceptions;
using Funcionários.Services;

namespace Funcionários
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = Path.Combine(folder, "db", "bd.txt");

            try
            {
                List<Employee> employees = new List<Employee>();
                bool continueOption = true;

                var options = new Dictionary<string, Action>
                    {
                        { "1", () => { OptionsServices.ShowAllEmployees(path); } },
                        { "2", () => { OptionsServices.RegisterEmployees(path, employees); } },
                        { "3", () => { OptionsServices.SearchEmployeeById(path); } },
                        { "4", () => { OptionsServices.DeleteUserById(path); } },
                        { "s", () => {
                            Console.WriteLine("Saindo ....");
                            continueOption = false;
                        }},

                    };

                while (continueOption)
                {
                    Console.Clear();

                    Console.WriteLine("---------- Menu ----------");
                    Console.WriteLine();
                    Console.WriteLine("1 - Listar todos os funcionários");
                    Console.WriteLine("2 - Adicionar novos funcionários");
                    Console.WriteLine("3 - Procurar funcionário por ID");
                    Console.WriteLine("4 - Excluir funcionário por ID");
                    Console.WriteLine("S - Sair");

                    string entry = Console.ReadLine();

                    if (options.TryGetValue(entry.ToLower(), out Action action))
                    {
                        Console.Clear();
                        action.Invoke();
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida");
                    }

                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
            catch (FileException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
