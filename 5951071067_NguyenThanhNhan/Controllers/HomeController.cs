using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _5951071067_NguyenThanhNhan.Models;
using System.Data;

namespace _5951071067_NguyenThanhNhan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        db dbop = new db();
        String msg;


        public IActionResult Index()
        {
            Employee emp = new Employee();
            emp.Flag = "get";
            DataSet ds = dbop.Empget(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Employee
                {
                    Sr_no = Convert.ToInt32(dr["Sr_no"]),
                    Emp_name = dr["Emp_name"].ToString(),
                    City = dr["City"].ToString(),
                    State = dr["State"].ToString(),
                    Contry= dr["country"].ToString(),
                    Department= dr["Department"].ToString()
                }) ;
                
            }

            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind] Employee emp)
        {
            try
            {
                emp.Flag = "insert";
                dbop.Empdml(emp, out msg);
                TempData["msg"] = msg;

            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Employee emp = new Employee();
            emp.Sr_no = id;
            emp.Flag = "getid";
            DataSet ds = dbop.Empget(emp, out msg);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                emp.Sr_no = Convert.ToInt32(dr["Sr_no"]);
                emp.Emp_name = dr["Emp_name"].ToString();
                emp.City  = dr["City"].ToString();
                emp.State = dr["State"].ToString();
                emp.Contry = dr["country"].ToString();
                emp.Department = dr["Department"].ToString();
            }
            return View(emp);
        }
        [HttpPost]
        public IActionResult Edit(int id,[Bind] Employee emp)
        {
            try
            {
                emp.Sr_no = id;
                emp.Flag = "update";
                dbop.Empdml(emp, out msg);
                TempData["msg"] = msg;

            }
            catch (Exception )
            {
                TempData["msg"] = msg;
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult delete(int id, [Bind] Employee emp)
        {
            try
            {
                emp.Sr_no = id;
                emp.Flag = "delete";
                dbop.Empdml(emp, out msg);
                TempData["msg"] = msg;
            }
            catch (Exception )
            {

                TempData["msg"] = msg;
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
