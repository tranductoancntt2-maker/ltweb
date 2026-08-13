using QuanLyNhanVien.Models;

namespace QuanLyNhanVien;

class Program
{
    static List<Employee> employees = new();

    static void Main()
    {
        while (true)
        {
            ShowMenu();

            Console.Write("Chon chuc nang: ");
            string choice = Console.ReadLine() ?? "";

            Console.Clear();

            switch (choice)
            {
                case "1":
                    AddEmployee();
                    break;

                case "2":
                    DisplayEmployees();
                    break;

                case "3":
                    CalculateSalaries();
                    break;

                case "4":
                    CalculateTotalSalary();
                    break;

                case "5":
                    FindHighestSalary();
                    break;

                case "6":
                    SortBySalary();
                    break;

                case "7":
                    StatisticsByDepartment();
                    break;

                case "8":
                    FindEmployeesOver5Years();
                    break;

                case "9":
                    ExportMonthlySalary();
                    break;

                case "0":
                    Console.WriteLine("Da thoat chuong trinh.");
                    return;

                default:
                    Console.WriteLine("Chuc nang khong hop le.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Nhan ENTER de tiep tuc...");
            Console.ReadLine();

            Console.Clear();
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("       QUAN LY NHAN VIEN VA TINH LUONG");
        Console.WriteLine("==============================================");
        Console.WriteLine("1. Them nhan vien");
        Console.WriteLine("2. Hien thi danh sach nhan vien");
        Console.WriteLine("3. Tinh luong nhan vien");
        Console.WriteLine("4. Tinh tong quy luong");
        Console.WriteLine("5. Tim nhan vien co luong cao nhat");
        Console.WriteLine("6. Sap xep nhan vien theo luong");
        Console.WriteLine("7. Thong ke luong theo phong ban");
        Console.WriteLine("8. Loc nhan vien lam viec tren 5 nam");
        Console.WriteLine("9. Xuat bang luong theo thang");
        Console.WriteLine("0. Thoat");
    }

    static void AddEmployee()
    {
        Console.WriteLine("THEM NHAN VIEN");
        Console.WriteLine("1. Nhan vien chinh thuc");
        Console.WriteLine("2. Nhan vien thoi vu");
        Console.WriteLine("3. Nhan vien thu viec");
        Console.WriteLine("4. Nhan vien kinh doanh");

        int type = ReadInt("Chon loai nhan vien: ");

        Console.Write("Ma nhan vien: ");
        string id = Console.ReadLine() ?? "";

        if (employees.Any(e =>
            e.Id.Equals(id, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Ma nhan vien da ton tai.");
            return;
        }

        Console.Write("Ho ten: ");
        string fullName = Console.ReadLine() ?? "";

        Console.Write("Phong ban: ");
        string department = Console.ReadLine() ?? "";

        DateTime startDate =
            ReadDate("Ngay vao lam (dd/MM/yyyy): ");

        decimal basicSalary =
            ReadDecimal("Luong co ban: ");

        Employee employee;

        switch (type)
        {
            case 1:
                {
                    decimal allowance =
                        ReadDecimal("Phu cap: ");

                    employee = new FullTimeEmployee(
                        id,
                        fullName,
                        department,
                        startDate,
                        basicSalary,
                        allowance);

                    break;
                }

            case 2:
                {
                    employee = new PartTimeEmployee(
                        id,
                        fullName,
                        department,
                        startDate,
                        basicSalary);

                    break;
                }

            case 3:
                {
                    int workingHours =
                        ReadInt("So gio lam: ");

                    decimal hourlyRate =
                        ReadDecimal("Don gia gio: ");

                    employee = new ProbationEmployee(
                        id,
                        fullName,
                        department,
                        startDate,
                        basicSalary,
                        workingHours,
                        hourlyRate);

                    break;
                }

            case 4:
                {
                    decimal sales =
                        ReadDecimal("Doanh so: ");

                    decimal commissionRate =
                        ReadDecimal(
                            "Ty le hoa hong (5% nhap 0.05): ");

                    employee = new BusinessEmployee(
                        id,
                        fullName,
                        department,
                        startDate,
                        basicSalary,
                        sales,
                        commissionRate);

                    break;
                }

            default:
                Console.WriteLine("Loai nhan vien khong hop le.");
                return;
        }

        employees.Add(employee);

        Console.WriteLine("Them nhan vien thanh cong.");
    }

    static void DisplayEmployees()
    {
        Console.WriteLine(
            "========== DANH SACH NHAN VIEN ==========");

        if (employees.Count == 0)
        {
            Console.WriteLine("Danh sach nhan vien dang trong.");
            return;
        }

        foreach (Employee employee in employees)
        {
            Console.WriteLine();
            Console.WriteLine(
                $"Loai: {GetEmployeeType(employee)}");

            employee.Display();

            switch (employee)
            {
                case FullTimeEmployee fullTime:
                    Console.WriteLine(
                        $"Phu cap: {fullTime.Allowance:N0}");
                    break;

                case PartTimeEmployee:
                    Console.WriteLine(
                        "He so luong: 85%");
                    break;

                case ProbationEmployee probation:
                    Console.WriteLine(
                        $"So gio lam: {probation.WorkingHours}");

                    Console.WriteLine(
                        $"Don gia gio: {probation.HourlyRate:N0}");
                    break;

                case BusinessEmployee business:
                    Console.WriteLine(
                        $"Doanh so: {business.Sales:N0}");

                    Console.WriteLine(
                        $"Ty le hoa hong: {business.CommissionRate:P0}");
                    break;
            }
        }
    }

    static void CalculateSalaries()
    {
        Console.WriteLine("========== BANG LUONG ==========");

        if (employees.Count == 0)
        {
            Console.WriteLine("Danh sach nhan vien dang trong.");
            return;
        }

        foreach (Employee employee in employees)
        {
            Console.WriteLine(
                $"Ma: {employee.Id,-10} | " +
                $"Ho ten: {employee.FullName,-20} | " +
                $"Loai: {GetEmployeeType(employee),-20} | " +
                $"Luong: {employee.CalculateSalary(),15:N0}");
        }
    }

    static void CalculateTotalSalary()
    {
        decimal total =
            employees.Sum(e => e.CalculateSalary());

        Console.WriteLine("========== TONG QUY LUONG ==========");
        Console.WriteLine(
            $"Tong quy luong: {total:N0}");
    }

    static void FindHighestSalary()
    {
        Console.WriteLine(
            "========== NHAN VIEN LUONG CAO NHAT ==========");

        if (employees.Count == 0)
        {
            Console.WriteLine("Danh sach nhan vien dang trong.");
            return;
        }

        Employee employee =
            employees
                .OrderByDescending(
                    e => e.CalculateSalary())
                .First();

        Console.WriteLine(
            $"Ma nhan vien: {employee.Id}");

        Console.WriteLine(
            $"Ho ten: {employee.FullName}");

        Console.WriteLine(
            $"Phong ban: {employee.Department}");

        Console.WriteLine(
            $"Loai: {GetEmployeeType(employee)}");

        Console.WriteLine(
            $"Luong: {employee.CalculateSalary():N0}");
    }

    static void SortBySalary()
    {
        Console.WriteLine(
            "========== SAP XEP THEO LUONG ==========");

        if (employees.Count == 0)
        {
            Console.WriteLine("Danh sach nhan vien dang trong.");
            return;
        }

        var result =
            employees
                .OrderByDescending(
                    e => e.CalculateSalary())
                .ToList();

        foreach (Employee employee in result)
        {
            Console.WriteLine(
                $"Ma: {employee.Id,-10} | " +
                $"Ho ten: {employee.FullName,-20} | " +
                $"Luong: {employee.CalculateSalary(),15:N0}");
        }
    }

    static void StatisticsByDepartment()
    {
        Console.WriteLine(
            "========== THONG KE THEO PHONG BAN ==========");

        if (employees.Count == 0)
        {
            Console.WriteLine("Danh sach nhan vien dang trong.");
            return;
        }

        var result =
            employees.GroupBy(
                e => e.Department);

        foreach (var group in result)
        {
            decimal total =
                group.Sum(
                    e => e.CalculateSalary());

            Console.WriteLine(
                $"Phong ban: {group.Key}");

            Console.WriteLine(
                $"So nhan vien: {group.Count()}");

            Console.WriteLine(
                $"Tong luong: {total:N0}");

            Console.WriteLine("------------------------------------------");
        }
    }

    static void FindEmployeesOver5Years()
    {
        Console.WriteLine(
            "========== NHAN VIEN LAM TREN 5 NAM ==========");

        DateTime limit =
            DateTime.Now.AddYears(-5);

        var result =
            employees
                .Where(e => e.StartDate < limit)
                .ToList();

        if (result.Count == 0)
        {
            Console.WriteLine(
                "Khong co nhan vien nao lam tren 5 nam.");

            return;
        }

        foreach (Employee employee in result)
        {
            int years =
                CalculateWorkingYears(
                    employee.StartDate);

            Console.WriteLine(
                $"Ma: {employee.Id,-10} | " +
                $"Ho ten: {employee.FullName,-20} | " +
                $"Tham nien: {years} nam");
        }
    }

    static int CalculateWorkingYears(
        DateTime startDate)
    {
        int years =
            DateTime.Now.Year - startDate.Year;

        if (startDate.Date >
            DateTime.Now.Date.AddYears(-years))
        {
            years--;
        }

        return years;
    }

    static void ExportMonthlySalary()
    {
        Console.WriteLine(
            "========== XUAT BANG LUONG ==========");

        int month =
            ReadInt("Nhap thang: ");

        int year =
            ReadInt("Nhap nam: ");

        Console.WriteLine();
        Console.WriteLine(
            $"BANG LUONG THANG {month}/{year}");

        Console.WriteLine(
            new string('-', 85));

        foreach (Employee employee in employees)
        {
            Console.WriteLine(
                $"Ma: {employee.Id,-10} | " +
                $"Ho ten: {employee.FullName,-20} | " +
                $"Phong: {employee.Department,-15} | " +
                $"Luong: {employee.CalculateSalary(),15:N0}");
        }

        Console.WriteLine(
            new string('-', 85));

        decimal total =
            employees.Sum(
                e => e.CalculateSalary());

        Console.WriteLine(
            $"Tong quy luong: {total:N0}");
    }

    static string GetEmployeeType(
        Employee employee)
    {
        return employee switch
        {
            FullTimeEmployee =>
                "Nhan vien chinh thuc",

            PartTimeEmployee =>
                "Nhan vien thoi vu",

            ProbationEmployee =>
                "Nhan vien thu viec",

            BusinessEmployee =>
                "Nhan vien kinh doanh",

            _ => "Khong xac dinh"
        };
    }

    static int ReadInt(string message)
    {
        while (true)
        {
            Console.Write(message);

            if (int.TryParse(
                Console.ReadLine(),
                out int value))
            {
                return value;
            }

            Console.WriteLine(
                "Vui long nhap so nguyen.");
        }
    }

    static decimal ReadDecimal(string message)
    {
        while (true)
        {
            Console.Write(message);

            if (decimal.TryParse(
                Console.ReadLine(),
                out decimal value))
            {
                return value;
            }

            Console.WriteLine(
                "Vui long nhap so.");
        }
    }

    static DateTime ReadDate(string message)
    {
        while (true)
        {
            Console.Write(message);

            if (DateTime.TryParse(
                Console.ReadLine(),
                out DateTime date))
            {
                return date;
            }

            Console.WriteLine(
                "Ngay khong hop le.");
        }
    }
}