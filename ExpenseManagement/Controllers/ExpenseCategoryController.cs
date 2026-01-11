using Microsoft.AspNetCore.Mvc;
using ExpenseManagement.DataLayer;
using ExpenseManagement.Models;

namespace ExpenseManagement.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        public readonly DbContextExpMgmt _context;

        public ExpenseCategoryController(DbContextExpMgmt context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseCategoryEntity>  ExpenseCategories = _context.ExpenseCategory.ToList();
            return View(ExpenseCategories);
        }

        public IActionResult Create(ExpenseCategoryEntity expenseCategory)
        {
            if (ModelState.IsValid)
            {
                _context.ExpenseCategory.Add(expenseCategory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult GetExpenseCategoryForUpdate(int? id)
        {
            var expenseCaregories = _context.ExpenseCategory.Find(id);
            if (expenseCaregories == null)
                return NotFound();
            return View(expenseCaregories);

        }

        public IActionResult Update(ExpenseCategoryEntity expenseCaregories)
        {
            if (ModelState.IsValid)
            {
                _context.ExpenseCategory.Update(expenseCaregories);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        
         public IActionResult GetExpenseCategoryForDelete(int? id)
        {
            var expenseCaregories = _context.ExpenseCategory.Find(id);

            if (expenseCaregories == null) return NotFound();

            return View(expenseCaregories);
            
        }

        public IActionResult Delete(int? ExpenseCategoryId)
        {
            var expenseCaregories = _context.ExpenseCategory.Find(ExpenseCategoryId);
            if (expenseCaregories == null)
                return NotFound();
            _context.ExpenseCategory.Remove(expenseCaregories);
            _context.SaveChanges();
            return RedirectToAction("Index");   

        }

    }
}
