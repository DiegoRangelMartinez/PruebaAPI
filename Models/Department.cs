using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Department
    {
        [Required, MaxLength(10)]
        public string Code { get; set; }
        [Required, MaxLength(75)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string DepartmentType { get; set; }
        [Required, MaxLength(2)]
        public string CountryCode { get; set; }
        public Country Country { get; set; }
    } 
}
