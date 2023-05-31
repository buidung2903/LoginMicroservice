using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginMicroservice.Models.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
        [StringLength(100)]
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}
