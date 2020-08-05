using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityDataContext.Models
{
    public class Report
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Invalid Support Level", AllowEmptyStrings = false)]
        [StringLength(maximumLength:3, MinimumLength = 3)]
        public string SupportLevel { get; set; }
        [Required(ErrorMessage = "Invalid MachId", AllowEmptyStrings = false)]
        [StringLength(maximumLength: 20, MinimumLength = 5)]
        public string MachId { get; set; }
        [Required(ErrorMessage = "Invalid SerialNo", AllowEmptyStrings = false)]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string SerialNo { get; set; }
        [Required(ErrorMessage = "Invalid Location", AllowEmptyStrings = false)]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Location { get; set; }
        [Required(ErrorMessage = "Invalid Datetime")]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public DateTime ArrivalDateTime { get; set; }
        [Required(ErrorMessage = "Invalid Status")]
        [Range(0, 50)]
        public int StatusId { get; set; }
        [ForeignKey(nameof(StatusId))]
        public virtual Status Status { get; set; }
        //[LOCATION] VARCHAR(MAX) NULL,
        //[DATE]
        //DATE NULL,
        //[ARRIVAL_TIME] ROWVERSION NULL,
        //[PROBLEM_CODE] VARCHAR(50)  NULL,
        //[DESCRIPTION] VARCHAR(MAX) NULL
        //);


    }
}
