using System.Globalization;
using System.Text;
using Funcionários.Entities.Enums;

namespace Funcionários.Entities
{
    internal class Hourly : Employee
    {
        public double WorkedHours { get; set; }
        public double ValuePerHour { get; set; }

        public Hourly(string name, int id, Position position, TypeContract typeContract, double workedHours, double valuePerHour)
            : base(name, id, position, typeContract)
        {
            WorkedHours = workedHours;
            ValuePerHour = valuePerHour;
        }

        public override double CalcPayment()
        {
            return WorkedHours * ValuePerHour;
        }

        public override string SaveFile()
        {
            return Name + "," + Id + "," + Position + "," + TypeContract + "," + WorkedHours + "," + ValuePerHour.ToString("F2", CultureInfo.InvariantCulture);
        }

        public override string ToString()
        {
            CultureInfo culture = CultureInfo.InvariantCulture;
            StringBuilder sb = new StringBuilder();

            sb.Append($"Name: {Name}");
            sb.Append($", Horas trabalhadas: {WorkedHours.ToString("F2", culture)}");
            sb.Append($", Valor por hora: ${ValuePerHour.ToString("F2", culture)}");
            sb.Append($", Salário final: ${CalcPayment().ToString("F2", culture)}");

            return sb.ToString();
        }
    }
}
