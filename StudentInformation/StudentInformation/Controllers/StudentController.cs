using Microsoft.AspNetCore.Mvc;
using StudentInformation.Data;
using StudentInformation.Models;

namespace StudentInformation.Controllers
{
    public class StudentController : Controller
    {
        private readonly InfoDbContext _infoDbContext;

        public StudentController(InfoDbContext infoDbContext)
        {
            _infoDbContext = infoDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<StudentInfo> objStudentList = _infoDbContext.studentInfos.ToList();
            return View(objStudentList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentInfo student)
        {
            if (ModelState.IsValid)
            {
                _infoDbContext.studentInfos.Add(student);
                _infoDbContext.SaveChanges();
                TempData["success"] = "Category created successfully";
            }
            return View(student);
        }

        public IActionResult Edit(int? id)
        {
            var StudentId = _infoDbContext.studentInfos.Find(id);
            if (StudentId == null)
            {
                return NotFound();
            }
            return View(StudentId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentInfo student)
        {
            if (ModelState.IsValid)
            {
                _infoDbContext.studentInfos.Update(student);
                    _infoDbContext.SaveChanges();
                    TempData["success"] = "studentInfo updated successfully";
                    return RedirectToAction("Index");
            }
            return View(student);
        }
        public IActionResult Delete(int? id)
        {
            var studentId = _infoDbContext.studentInfos.Find(id);
            if (studentId == null)
            {
                return NotFound();
            }
            return View(studentId);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(StudentInfo student)
        {
                _infoDbContext.studentInfos.Remove(student);
                _infoDbContext.SaveChanges();
                TempData["success"] = "Student deleted successfully";
                return RedirectToAction("Index");
          }
       }
    }

