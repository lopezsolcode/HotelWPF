using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Models;

[Table("dbo.Employees")]
public partial class DboEmployee
{
    [Key]
    [Column("employeeID")]
    public int EmployeeId { get; set; }

    [Column("employeeName")]
    [StringLength(250)]
    [Unicode(false)]
    public string EmployeeName { get; set; } = null!;

    [Column("phoneNumber")]
    public long PhoneNumber { get; set; }

    [Column("gender")]
    [StringLength(50)]
    [Unicode(false)]
    public string Gender { get; set; } = null!;

    [Column("email")]
    [StringLength(120)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("userid")]
    public int Userid { get; set; }
}
