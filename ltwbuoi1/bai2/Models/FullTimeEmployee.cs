namespace QuanLyNhanVien.Models;

public class FullTimeEmployee : Employee
{
    public decimal Allowance { get; set; }

    public FullTimeEmployee(
        string id,
        string fullName,
        string department,
        DateTime startDate,
        decimal basicSalary,
        decimal allowance)
        : base(id, fullName, department, startDate, basicSalary)
    {
        Allowance = allowance;
    }

    public override decimal CalculateSalary()
    {
        return BasicSalary + Allowance;
    }
}