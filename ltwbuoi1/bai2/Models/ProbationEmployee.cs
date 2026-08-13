namespace QuanLyNhanVien.Models;

public class ProbationEmployee : Employee
{
    public int WorkingHours { get; set; }

    public decimal HourlyRate { get; set; }

    public ProbationEmployee(
        string id,
        string fullName,
        string department,
        DateTime startDate,
        decimal basicSalary,
        int workingHours,
        decimal hourlyRate)
        : base(id, fullName, department, startDate, basicSalary)
    {
        WorkingHours = workingHours;
        HourlyRate = hourlyRate;
    }

    public override decimal CalculateSalary()
    {
        return WorkingHours * HourlyRate;
    }
}