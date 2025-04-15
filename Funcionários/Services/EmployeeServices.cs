using System.Globalization;
using Funcionários.Entities;
using Funcionários.Entities.Enums;

namespace Funcionários.Services
{
    internal class EmployeeServices
    {

        static private Employee RegisterMonthlyEmployee(string name, int id, Position position, TypeContract employeeType, List<Employee> employees)
        {
            Console.Write("Salário mensal: ");
            double monthlySalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            return new MonthlyPayers(name, id, position, employeeType, monthlySalary);
        }

        static private Employee RegisterHourlyEmployee(string name, int id, Position position, TypeContract employeeType, List<Employee> employees)
        {
            Console.Write("Valor por hora: ");
            double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Horas trabalhadas: ");
            double workedHours = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            return new Hourly(name, id, position, employeeType, workedHours, valuePerHour);
        }

        static private Employee RegisterComissionedEmployee(string name, int id, Position position, TypeContract employeeType, List<Employee> employees)
        {
            Console.Write("Salário base: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Vendas totais: ");
            int totalSales = int.Parse(Console.ReadLine());

            Console.Write("Porcentual da comissão: ");
            double comissionPercentual = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            return new Commissioned(name, id, position, employeeType, totalSales, comissionPercentual, baseSalary);
        }

        public static void RegisterEmployee(int amountEmployees, List<Employee> employees) {
            for (int i = 1; i <= amountEmployees; i++)
            {
                Console.WriteLine($"Funcionário #{i}");
                Console.Write("Nome do funcionário: ");
                string name = Console.ReadLine();

                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Posição do funcionário (Assistant, Analyst, Manager, Director): ");
                Position position = Enum.Parse<Position>(Console.ReadLine());

                Console.Write("Tipo de funcionário (Mensalista, Horista, Comissionado): ");
                TypeContract employeeType = Enum.Parse<TypeContract>(Console.ReadLine());

                Employee emp = null;

                switch(employeeType.ToString().ToLower()) {
                    case "mensalista":
                        emp = EmployeeServices.RegisterMonthlyEmployee(name, id, position, employeeType,  employees);
                        break;
                    case "horista":
                        emp = EmployeeServices.RegisterHourlyEmployee(name, id, position, employeeType, employees);
                        break;
                    case "comissionado":
                        emp = EmployeeServices.RegisterComissionedEmployee(name, id, position, employeeType, employees);
                        break;

                }

                if (emp != null)
                {
                    employees.Add(emp);
                }

                Console.WriteLine();
            }
        }

        public static Employee SearchEmployeeById(int id, List<Employee> employees)
        {
            return employees.Find((employee) => employee.Id == id);
        }
    }
}
