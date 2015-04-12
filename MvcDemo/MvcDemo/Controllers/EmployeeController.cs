using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class EmployeeController : Controller
    {

        public ActionResult Index()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.Employees.ToList();

            return View(employees);
        }

        public ActionResult EmployeeBlList()
        {
            BL.EmployeeBL empBL = new BL.EmployeeBL();
            List<BL.Employee> employees = empBL.Employees.ToList();

            return View(employees);
        }


        public ActionResult Details(int id)
        {

            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Single(x => x.EmployeeId == id);

            return View(employee);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        foreach (string key in formCollection.AllKeys)
        //        {
        //            Response.Write("Key = " + key + "  ");
        //            Response.Write("Value = " + formCollection[key]);
        //            Response.Write("<br/>");
        //        }
        //    }
        //    return View();
        //}


        //[HttpPost]
        //public ActionResult Create(string name, string gender, string city, int departmentId, DateTime dateOfBirth)
        //{
        //    BL.Employee employee = new BL.Employee();
        //    // Retrieve form data using form collection
        //    employee.Name = name;
        //    employee.Gender = gender;
        //    employee.City = city;
        //    employee.DepartmentId = departmentId;
        //    employee.DateOfBirth = dateOfBirth;

        //    BL.EmployeeBL employeeBL = new BL.EmployeeBL();

        //    employeeBL.AddEmmployee(employee);
        //    return RedirectToAction("EmployeeBlList");
        //}


        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    BL.Employee employee = new BL.Employee();
        //    // Retrieve form data using form collection
        //    employee.Name = formCollection["Name"];
        //    employee.Gender = formCollection["Gender"];
        //    employee.City = formCollection["City"];
        //    employee.DepartmentId = Convert.ToInt32(formCollection["DepartmentId"]);
        //    employee.DateOfBirth = Convert.ToDateTime(formCollection["DateOfBirth"]);

        //    BL.EmployeeBL employeeBL = new BL.EmployeeBL();

        //    employeeBL.AddEmmployee(employee);
        //    return RedirectToAction("EmployeeBlList");
        //}


        //[HttpPost]
        //public ActionResult Create(BL.Employee employee)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        BL.EmployeeBL employeeBL = new BL.EmployeeBL();

        //        employeeBL.AddEmmployee(employee);
        //        return RedirectToAction("EmployeeBlList");
        //    }
        //    return View();
        //}


        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {

            try
            {
                if (ModelState.IsValid)
                {

                    BL.Employee employee = new BL.Employee();
                    if (TryUpdateModel<BL.Employee>(employee))
                    {
                        BL.EmployeeBL employeeBL = new BL.EmployeeBL();
                        employeeBL.AddEmmployee(employee);
                        return RedirectToAction("EmployeeBlList");
                    }
                    else
                    {
                        return View();
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                throw;
            }
        }



    }
}
