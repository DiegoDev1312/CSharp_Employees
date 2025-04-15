namespace Funcionários.Entities
{
    internal interface IPayment
    {
        double CalcPayment();

        string SaveFile();
    }
}
