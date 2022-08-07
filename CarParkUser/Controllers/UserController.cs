using CarParkUser.Models;
using CoreLayer.Repository.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;

namespace CarParkUser.Controllers
{
    public class UserController : Controller
    {
        private readonly IStringLocalizer<UserController> _localizer;
        private readonly IRepository<Employee> _personelRrepository;

        public UserController(IStringLocalizer<UserController> localizer, IRepository<Employee> personelRrepository)
        {
            _localizer = localizer;
            _personelRrepository = personelRrepository;
        }

        public IActionResult Index()
        {
            var nameSurnameValue = _localizer["NameSurname"];

            return View();
        }

        public IActionResult Create()
        {


            var result = _personelRrepository.InsertOne(new Employee
            {
                Email = "berkancelikist@gmailcom",
                Password = "12345",
                CreatedDate = System.DateTime.Now,
                UserName = "berkancelik "

            });
            var result2 = _personelRrepository.InsertOne(new Employee
            {
                Email = "ahmetcelik@gmailcom",
                Password = "123452",
                CreatedDate = System.DateTime.Now,
                UserName = "ahmetcelik "

            });
            var result3 = _personelRrepository.InsertOneAsync(new Employee
            {
                Email = "mehmetcelik@gmailcom",
                Password = "12345asfasf",
                CreatedDate = System.DateTime.Now,
                UserName = "mehmetcelik "

            });


            var result4 = _personelRrepository.InsertMany(new List<Employee>
            {
                new Employee
                {
                      Email = "mehmetcelik@gmailcom",
                Password = "12345asfasf",
                CreatedDate = System.DateTime.Now,
                UserName = "mehmetcelik "
                },
                   new Employee
                {
                      Email = "mehmetcelik@gmailcom",
                Password = "12345asfasf",
                CreatedDate = System.DateTime.Now,
                UserName = "mehmetcelik "
                },
                      new Employee
                {
                      Email = "mehmetcelik@gmailcom",
                Password = "12345asfasf",
                CreatedDate = System.DateTime.Now,
                UserName = "mehmetcelik "
                },


            });


            //var result4 = _personelRrepository.AsQueryable();
            //var result5 = _personelRrepository.GetById("mongodbid" asişsdgisdds);
            //var result6 = _personelRrepository.DeleteOne(x=> x.Email.Contains();














            return View();
        }

        [HttpPost]
        public IActionResult Create(UserCreateRequestModel request)
        {
            return View(request);
        }
    }
}
