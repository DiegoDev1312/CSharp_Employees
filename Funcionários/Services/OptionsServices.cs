using Funcionários.Entities;

namespace Funcionários.Services
{
    internal class OptionsServices
    {
        private static List<Employee> GetAllEmployees(string path)
        {
            List<Employee> employeesInBd = new List<Employee>();
            if (File.Exists(path)) EmployeeFile.AddEmployeeOnList(path, employeesInBd);

            return employeesInBd;
        }

        public static void ShowAllEmployees(string path)
        {
            List<Employee> employees = OptionsServices.GetAllEmployees(path);
            Console.WriteLine("Funcionários: ");

            foreach (Employee employeeInBd in employees)
            {
                Console.WriteLine(employeeInBd);
            }
        }

        public static void RegisterEmployees(string path, List<Employee> employees)
        {
            Console.WriteLine("Cadastro de funcionários: ");

            Console.Write("Informe quantos funcionários deseja cadastrar? ");
            int nEmployees = int.Parse(Console.ReadLine());

            EmployeeServices.RegisterEmployee(nEmployees, employees);

            Console.WriteLine();

            Console.WriteLine("Funcionários adicionados: ");

            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }

            using (StreamWriter sw = File.AppendText(path))
            {
                foreach (Employee employee in employees)
                {
                    Console.WriteLine(employee);
                    sw.WriteLine(employee.SaveFile());
                }
            }
        }

        public static void SearchEmployeeById(string path)
        {
            List<Employee> employees = OptionsServices.GetAllEmployees(path);

            Console.WriteLine("Informe o ID: ");
            int searchId = int.Parse(Console.ReadLine());

            Employee employee = EmployeeServices.SearchEmployeeById(searchId, employees);

            if (employee != null)
            {
                Console.WriteLine(employee);
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado!");
            }
        }

        public static void DeleteUserById(string path)
        {
            List<Employee> employees = OptionsServices.GetAllEmployees(path);

            Console.WriteLine("Informe o ID: ");
            int searchId = int.Parse(Console.ReadLine());

            EmployeeFile.DeleteEmployeeById(searchId, path, employees);
        }
    }
}
