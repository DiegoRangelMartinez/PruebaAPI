using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Country
    {
        [Required, MaxLength(2)]
        public string Code { get; set; }
        [Required, MaxLength(3)]
        public string AlphaCodeThree { get; set; }
        [Required, MaxLength(75)]
        public string Name { get; set; }
        [Required, MaxLength(3)]
        public string NumericCode { get; set; }
        public bool IsIndependent { get; set; }
        public List<Department> Departments { get; set; }

    }
}
