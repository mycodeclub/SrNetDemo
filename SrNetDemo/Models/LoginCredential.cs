using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SrNetDemo.Models
{
    [Table("UserCredentials")]
    public class LoginCredential
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [DisplayName("User Name")]
        [Column("userName")]

        public string UserName { get; set; }

        [Required]
        [Column("password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        public string RememberMe { get; set; }
    }
}