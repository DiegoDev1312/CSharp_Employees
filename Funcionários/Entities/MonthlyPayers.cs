using System.Globalization;
using System.Text;
using Funcionários.Entities.Enums;

namespace Funcionários.Entities
{
    internal class MonthlyPayers : Employee
    {
        public double MonthlySalary { get; set; }
        public MonthlyPayers(string name, int id, Position position, TypeContract typeContract, double monthlySalary)
            : base(name, id, position, typeContract)
        {
            MonthlySalary = monthlySalary;
        }

        private double CalcTax()
        {
            return MonthlySalary * 0.05;
        }

        public override double CalcPayment()
        {
            return MonthlySalary - CalcTax();
        }

        public override string SaveFile()
        {
            return Name + "," + Id + "," + Position + "," + TypeContract + "," + MonthlySalary.ToString("F2", CultureInfo.InvariantCulture);
        }

        public override string ToString()
        {
            CultureInfo culture = CultureInfo.InvariantCulture;
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {Name}");
            sb.Append($", Salário bruto: ${MonthlySalary.ToString("F2", culture)}");
            sb.Append($", Valor do imposto (5%): ${CalcTax().ToString("F2", culture)}");
            sb.Append($", Salário liquido: ${CalcPayment().ToString("F2", culture)}");

            return sb.ToString();
        }
    }
}
