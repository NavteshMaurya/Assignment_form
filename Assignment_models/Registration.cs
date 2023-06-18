using System.ComponentModel.DataAnnotations;

namespace Assignment_models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; } 
        public string Firstname { get; set; }
        public string Lastname { get; set; }
     
        public string Email { get; set; }
       
        public string Phone { get; set; }
        public int cityid { get; set; }

        public string gender { get; set; }

       // public int Checkbox { get; set; }
       
       
    }
}
