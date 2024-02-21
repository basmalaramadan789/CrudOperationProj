using CrudOperation.Data;
using CrudOperation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol;
using System.Reflection.Metadata.Ecma335;

namespace CrudOperation.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext context;

        public EmployeesController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            //TO Appear the the department name
            var result = context.Employees.Include(x => x.Department)
                .OrderBy(x => x.EmployeeName).ToList();
            return View(result);
        }

        public IActionResult Create()
        {

            ViewData["deptlist"] = context.Departments.ToList();

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee model)
        {
            //image
            UploadImage(model);

            if (ModelState.IsValid)
            {
                context.Employees.Add(model);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["deptlist"] = context.Departments.ToList();

            return View();
        }

        private void UploadImage(Employee model)
        {
            var file = HttpContext.Request.Form.Files;
            if (file.Count() > 0)
            {
                // not upload image & new employee
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var fileStream = new FileStream(Path.Combine(@"wwwroot/", "Images", ImageName), FileMode.Create);
                file[0].CopyTo(fileStream);
                model.Image = ImageName;


            }
            else if (model.Image == null && model.EmployeeId == null)
            {
                model.Image = "user_1077114.png";
               //model.Image = "21339b40 - 08b3 - 4915 - ac19 - d42282704f1a.png";
            }
            else
            {
                //Edit
                model.Image = model.Image;
            }
        }

        public IActionResult Edit(int? id)
        {
            ViewData["deptlist"] = context.Departments.ToList();
            var result = context.Employees.Find(id);

            return View("Create", result);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee model)
        {
            UploadImage(model);
            if (ModelState.IsValid)
            {
                context.Employees.Update(model);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewData["deptlist"] = context.Departments.ToList();

            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            var result = context.Employees.Find(id);
            if(result !=null)
            {
                context.Employees.Remove(result);
                context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}