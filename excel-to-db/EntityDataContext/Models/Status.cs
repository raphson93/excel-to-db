using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityDataContext.Models
{
    public class Status
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Invalid Problem Code", AllowEmptyStrings = false)]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string Code { get; set; }
        [Required(ErrorMessage = "Invalid Problem Code", AllowEmptyStrings = false)]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Description { get; set; }
    }
}
