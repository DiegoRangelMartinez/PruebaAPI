using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Department
    {
        [Required, MaxLength(10)]
        public string Code { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [Required, MaxLength(2)]
        public string CountryCode { get; set; }
        public Country Country { get; set; }
        //se agregan para no tener que modificar el script que encontré para dar de alta los departamentos
        public int? Number1 { get; set; }
        public int? Number2 { get; set; }
    } 
}
