using Microsoft.AspNetCore.Mvc;
using tdtbtbuoi3.Models;

namespace tdtbtbuoi3.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,Name="Hoàng Anh",
                    Email="anh@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/images/Avatar/01.jpg"),
                    Gender=1,Bio="My name is small",
                    Birthday=new DateTime(1998,7,15),
                },
                new Account()
                {
                    Id = 2,Name="Thuấn Phong",
                    Email="phong@gmail.com",
                    Phone="0986456788",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/images/Avatar/02.jpg"),
                    Gender=0,Bio="My name is small",
                    Birthday=new DateTime(1997,7,15),
                },
                new Account()
                {
                    Id = 3,Name="Hoàng Thúy",
                    Email="thuy@gmail.com",
                    Phone="0986456787",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/images/Avatar/03.jpg"),
                    Gender=1,Bio="My name is small",
                    Birthday=new DateTime(1996,7,15),
                },
            };
            ViewBag.Accounts = accounts;
            return View();
        }
        [Route("ho-so-cua-toi/{id}", Name = "profile")]
        public IActionResult Profile(int id)
        {
            List<Account> accounts = new List<Account>
    {
        new Account()
        {
            Id = 1,
            Name = "Hoàng Anh",
            Email = "anh@gmail.com",
            Phone = "0986456789",
            Address = "Hà Nội",
            Avatar = Url.Content("~/images/Avatar/01.jpg"),
            Gender = 1,
            Bio = "My name is small",
            Birthday = new DateTime(1998, 7, 15),
        },
        new Account()
        {
            Id = 2,
            Name = "Thuấn Phong",
            Email = "phong@gmail.com",
            Phone = "0986456788",
            Address = "Hà Nội",
            Avatar = Url.Content("~/images/Avatar/02.jpg"),
            Gender = 0,
            Bio = "My name is small",
            Birthday = new DateTime(1997, 7, 15),
        },
        new Account()
        {
            Id = 3,
            Name = "Hoàng Thúy",
            Email = "thuy@gmail.com",
            Phone = "0986456787",
            Address = "Hà Nội",
            Avatar = Url.Content("~/images/Avatar/03.jpg"),
            Gender = 1,
            Bio = "My name is small",
            Birthday = new DateTime(1996, 7, 15),
        }
    };

            Account account = accounts.FirstOrDefault(ac => ac.Id == id);

            ViewBag.account = account;

            return View();
        }

    }
}
