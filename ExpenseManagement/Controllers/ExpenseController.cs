using Microsoft.AspNetCore.Mvc;
using ExpenseManagement.DataLayer;
using ExpenseManagement.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AspNetCoreGeneratedDocument;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenseManagement.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly DbContextExpMgmt _context;
        public ExpenseController(DbContextExpMgmt context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseEntity> expenseList = _context.Expenses.ToList();
            foreach (var expense in expenseList)
            {
                expense.ExpenseCategory =_context.ExpenseCategory.FirstOrDefault(u=>u.ExpenseCategoryId == expense.ExpenseCategoryId);
            }

            return View(expenseList);
        }

        public IActionResult Create(ExpenseEntity expenseDetails)
        {
            IEnumerable<SelectListItem> getExpenseCategoryList = _context.ExpenseCategory.Select(u => new SelectListItem
            {
                Text= u.ExpenseCategoryName,
                Value = u.ExpenseCategoryId.ToString()
            });

            ViewBag.PopulateExpenseCategory  = getExpenseCategoryList;
            
            if(ModelState.IsValid)
            {
                _context.Expenses.Add(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
           return View();
        }

        public IActionResult GetExpenseDetailsForUpdate(int? id)
        {
            IEnumerable<SelectListItem> getExpenseCategoryList = _context.ExpenseCategory.Select(u => new SelectListItem
            {
                Text = u.ExpenseCategoryName,
                Value = u.ExpenseCategoryId.ToString()
            });

            ViewBag.PopulateExpenseCategory = getExpenseCategoryList;
            var _expenseDetails = _context.Expenses.Find(id);
            if(_expenseDetails == null)
            {
                return NotFound();

            }
            else
            {
                return View(_expenseDetails);
            }

        }

        [HttpPost]
        public IActionResult Update(ExpenseEntity expenseDetails)
        {


            if (ModelState.IsValid)
            {
                _context.Expenses.Update(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult GetExpenseDetailsForDelete(int? id)
        {
            IEnumerable<SelectListItem> getExpenseCategoryList = _context.ExpenseCategory.Select(u => new SelectListItem
            {
                Text = u.ExpenseCategoryName,
                Value = u.ExpenseCategoryId.ToString()
            });

            ViewBag.PopulateExpenseCategory = getExpenseCategoryList;

            var _expenseDetails = _context.Expenses.Find(id);
            if (_expenseDetails == null)
            {
                return NotFound();

            }
            else
            {
                return View(_expenseDetails);
            }

        }
       
        public IActionResult Delete(int? ExpenseId)
        {
            var _expenseDetails = _context.Expenses.Find(ExpenseId);
            if (_expenseDetails == null)
            {
                return NotFound();

            }
            _context.Expenses.Remove(_expenseDetails);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
