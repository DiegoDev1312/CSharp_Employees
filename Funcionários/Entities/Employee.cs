using Funcionários.Entities.Enums;

namespace Funcionários.Entities
{
    internal abstract class Employee : IPayment
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Position Position { get; set; }
        public TypeContract TypeContract { get; set; }

        protected Employee(string name, int id, Position position, TypeContract typeContract)
        {
            Name = name;
            Id = id;
            Position = position;
            TypeContract = typeContract;
        }

        public abstract double CalcPayment();

        public abstract string SaveFile();
    }
}
