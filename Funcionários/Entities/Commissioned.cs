using System.Globalization;
using System.Text;
using Funcionários.Entities.Enums;

namespace Funcionários.Entities
{
    internal class Commissioned : Employee
    {
        public double TotalSold { get; set; }
        public double Percentual { get; set; }
        public double BaseSalary { get; set; }

        public Commissioned(string name, int id, Position position, TypeContract typeContract, double totalSold, double percentual, double baseSalary)
            : base(name, id, position, typeContract)
        {
            TotalSold = totalSold;
            Percentual = percentual;
            BaseSalary = baseSalary;
        }

        private double CalcComission()
        {
            return (TotalSold * Percentual) / 100;
        }

        public override double CalcPayment()
        {
            return BaseSalary + CalcComission();
        }

        public override string SaveFile()
        {
            return Name + "," + Id + "," + Position + "," + TypeContract + "," + TotalSold + "," + Percentual + "," + BaseSalary.ToString("F2", CultureInfo.InvariantCulture);
        }

        public override string ToString()
        {
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            StringBuilder sb = new StringBuilder();

            sb.Append($"Name: {Name}");
            sb.Append($", Salário base: ${BaseSalary.ToString("F2", cultureInfo)}");
            sb.Append($", Total vendido: {TotalSold}");
            sb.Append($", Porcentual por comissão: {Percentual}%");
            sb.Append($", Valor da comissão: ${CalcComission().ToString("F2", cultureInfo)}");
            sb.Append($", Salário final: ${CalcPayment().ToString("F2", cultureInfo)}");
            return sb.ToString();
        }
    }
}
