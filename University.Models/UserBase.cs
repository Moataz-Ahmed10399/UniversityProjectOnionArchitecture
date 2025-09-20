using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Models
{
    public abstract class UserBase
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]

            public int Id { get; set; }
            public string Username { get; set; }
            public string PasswordHash { get; set; } //يخزن نتيجة التشفير بدل الباسورد الأصلي.
            public string Email { get; set; }

            public int RoleId { get; set; }
            public Roles Role { get; set; }
    }
}
