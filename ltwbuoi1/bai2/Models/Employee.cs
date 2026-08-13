using QuanLyNhanVien.Interfaces;

namespace QuanLyNhanVien.Models;

public abstract class Employee : ICalculateSalary
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public string Department { get; set; }
    public DateTime StartDate { get; set; }
    public decimal BasicSalary { get; set; }

    protected Employee(
        string id,
        string fullName,
        string department,
        DateTime startDate,
        decimal basicSalary)
    {
        Id = id;
        FullName = fullName;
        Department = department;
        StartDate = startDate;
        BasicSalary = basicSalary;
    }

    public abstract decimal CalculateSalary();

    public virtual void Display()
    {
        Console.WriteLine(
            $"Ma: {Id,-8} | " +
            $"Ten: {FullName,-20} | " +
            $"Phong: {Department,-12} | " +
            $"Luong: {CalculateSalary(),15:N0}");
    }
}