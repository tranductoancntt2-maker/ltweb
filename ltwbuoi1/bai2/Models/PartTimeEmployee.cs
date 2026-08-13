namespace QuanLyNhanVien.Models;

public class PartTimeEmployee : Employee
{
    public PartTimeEmployee(
        string id,
        string fullName,
        string department,
        DateTime startDate,
        decimal basicSalary)
        : base(id, fullName, department, startDate, basicSalary)
    {
    }

    public override decimal CalculateSalary()
    {
        return BasicSalary * 0.85m;
    }
}