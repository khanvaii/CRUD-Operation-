using DigiTask.Models;
using DigiTask.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigiTask.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeServices ems = new EmployeeServices();
       
        public ActionResult List()
        {
            var data = ems.GetEmployee();
            return View(data);
        }

        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            if(ems.InsertEmployee(employee))
            {
                TempData["InsertMsg"] = "<script>alert(Successfull)</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["InsertErrorMsg"] = "<script>alert( Not Successfull)</script>";
            }
            return View();
        }

        public ActionResult EditEmployee(int id)
        {

            var data = ems.GetEmployee().Find(a=>a.Id==id);
            return View(data);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            if (ems.UpdateEmployee(employee))
            {
                TempData["UpdateMsg"] = "<script>alert(Successfull update)</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["updateErrorMsg"] = "<script>alert( Not Successfull)</script>";
            }
            return View();
        }

        
        public ActionResult DeleteEmployee(int id)
        {
            int r = ems.DeleteEmployee(id);
            if (r > 0)
            {
                TempData["DeleteMsg"] = "<script>alert(Successfull delete)</script>";
                return RedirectToAction("List");

            }
            else
            {
                TempData["deleteErrorMsg"] = "<script>alert( Not Successfull)</script>";
            }
            return View();
        }
    }
}