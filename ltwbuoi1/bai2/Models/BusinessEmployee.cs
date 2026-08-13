namespace QuanLyNhanVien.Models;

public class BusinessEmployee : Employee
{
    public decimal Sales { get; set; }

    public decimal CommissionRate { get; set; }

    public BusinessEmployee(
        string id,
        string fullName,
        string department,
        DateTime startDate,
        decimal basicSalary,
        decimal sales,
        decimal commissionRate)
        : base(id, fullName, department, startDate, basicSalary)
    {
        Sales = sales;
        CommissionRate = commissionRate;
    }

    public override decimal CalculateSalary()
    {
        return BasicSalary + Sales * CommissionRate;
    }
}