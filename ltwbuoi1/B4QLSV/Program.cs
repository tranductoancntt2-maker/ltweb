namespace QuanLySinhVien;

public class Program
{
    public static void Main(string[] args)
    {
        StudentService service =
            new StudentService();

        StudentConsoleView view =
            new StudentConsoleView();

        MenuManager menuManager =
            new MenuManager(
                service,
                view);

        menuManager.Chay();
    }
}