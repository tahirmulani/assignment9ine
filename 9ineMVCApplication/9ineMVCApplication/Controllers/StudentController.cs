using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using _9ineMVCApplication.Repository;
using _9ineMVCApplication.Models;
using _9ineMVCApplication.Interfaces;

namespace _9ineMVCApplication.Controllers
{
    public class StudentController : Controller
    {
        readonly IStudentRepository studentRepository;
        public StudentController(IStudentRepository studentRepositoryObj)
        {
            this.studentRepository = studentRepositoryObj;
        }
        DALClass dal = new DALClass();
        // GET: Student
        public ActionResult Index()
        {
            ModelState.Clear();

            return View(studentRepository.GetAllStudents());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var studentDetails = studentRepository.GetStudent(id);
            return View(studentDetails);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View(new StudentModel());
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel studentModel)
        {
            try
            {
                if (studentRepository.AddStudent(studentModel))
                {
                    ViewBag.Message = "Data Saved";
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var studentDetails = studentRepository.GetStudent(id);
            return View(studentDetails);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(StudentModel studentModel)
        {
            try
            {
                if (studentRepository.UpdateStudent(studentModel))
                {
                    ViewBag.Message = "Data Updated";
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View(studentRepository.GetStudent(id));
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, StudentModel studentModel)
        {
            try
            {
                if (studentRepository.DeleteStudent(id))
                {
                    ViewBag.Message = "Data Deleted";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
