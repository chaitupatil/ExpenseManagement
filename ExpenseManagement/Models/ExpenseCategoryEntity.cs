using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Models
{
    public class ExpenseCategoryEntity
    {
        [Key]
        
        public int ExpenseCategoryId { get; set; }

        [Required(ErrorMessage ="Please enter Category Name")]
        [Display (Name ="Expense Category Name")]
        public string ExpenseCategoryName { get; set; }
    }
}
