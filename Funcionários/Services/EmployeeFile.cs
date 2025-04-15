using System.Globalization;
using Funcionários.Entities;
using Funcionários.Entities.Enums;

namespace Funcionários.Services
{
    internal class EmployeeFile
    {
        public static void AddEmployeeOnList (string path, List<Employee> employees) {
            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] lines = sr.ReadLine().Split(",");

                    switch (lines[3])
                    {
                        case "Mensalista":
                            employees.Add(new MonthlyPayers(
                                    lines[0],
                                    int.Parse(lines[1]),
                                    Enum.Parse<Position>(lines[2]),
                                    Enum.Parse<TypeContract>(lines[3]),
                                    double.Parse(lines[4], CultureInfo.InvariantCulture)
                                ));
                            break;
                        case "Horista":
                            employees.Add(new Hourly(
                                    lines[0],
                                    int.Parse(lines[1]),
                                    Enum.Parse<Position>(lines[2]),
                                    Enum.Parse<TypeContract>(lines[3]),
                                    double.Parse(lines[4], CultureInfo.InvariantCulture),
                                    double.Parse(lines[5], CultureInfo.InvariantCulture)
                                ));
                            break;
                        case "Comissionado":
                            employees.Add(new Commissioned(
                                   lines[0],
                                   int.Parse(lines[1]),
                                   Enum.Parse<Position>(lines[2]),
                                   Enum.Parse<TypeContract>(lines[3]),
                                   double.Parse(lines[4], CultureInfo.InvariantCulture),
                                   double.Parse(lines[5], CultureInfo.InvariantCulture),
                                   double.Parse(lines[6], CultureInfo.InvariantCulture)
                               ));
                            break;
                        default: break;
                    }
                }
            }
        }

        public static void DeleteEmployeeById(int id, string path, List<Employee> employees)
        {
            Employee employeebyId = EmployeeServices.SearchEmployeeById(id, employees);

            if (employeebyId != null)
            {
                using (StreamWriter sr = File.CreateText(path))
                {
                    foreach (Employee employee in employees)
                    {
                        if (employee.Id != id) sr.WriteLine(employee.SaveFile());
                    }
                }
                Console.WriteLine("Usuário deletado!");
            } else
            {
                Console.WriteLine("Funcionário não encontrado!");
            }
        }
    }
}
