using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SrNetDemo.Models
{
    [Table("Employees")]
    public partial class Employee
    {
        [Key]
        [DisplayName("Employee Id")]
        public int EmployeeId { get; set; }

        [Required]
        [DisplayName("Full Name")]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Email Id")]
        [EmailAddress]
        [Column("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        [Column("password")]
        public string Password { get; set; }

        [NotMapped]
        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [Required]
        [DisplayName("Date Of Birth")]
        [Column("dob")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Dob { get; set; }

        [Required]
        [DisplayName("Mobile No.")]
        [Column("mobile")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please Provide A Valid Mobile Number, i.e. Any digit between [ 0 - 9]")]
        [MaxLength(10, ErrorMessage = "Must be a 10 digit Number")]
        [MinLength(10, ErrorMessage = "Must be a 10 digit Number")]
        public string Mobile { get; set; }

        [DisplayName("Resume")]
        public string ResumeUrl { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ResumeUpload { get; set; }

        [DisplayName("Physically Challenged")]
        [Column("isPhysicallyChallenged")]
        public bool IsPhysicallyChallenged { get; set; }

        [DisplayName("Country")]
        [Column("country")]
        public string Country { get; set; }

        [DisplayName("City")]
        [Column("city")]
        public string city { get; set; }

        [DisplayName("Full Address")]
        [Column("address")]
        public string Address { get; set; }
    }
}