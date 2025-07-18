using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Models;

[Table("dbo.Customers")]
public partial class DboCustomer
{
    [Key]
    [Column("customerID")]
    public int CustomerId { get; set; }

    [Column("customerName")]
    [StringLength(250)]
    [Unicode(false)]
    public string CustomerName { get; set; } = null!;

    [Column("phoneNumber")]
    public long PhoneNumber { get; set; }

    [Column("nationality")]
    [StringLength(250)]
    [Unicode(false)]
    public string Nationality { get; set; } = null!;

    [Column("gender")]
    [StringLength(50)]
    [Unicode(false)]
    public string Gender { get; set; } = null!;

    [Column("dateOfBirth")]
    public DateOnly DateOfBirth { get; set; }

    [Column("address")]
    [StringLength(350)]
    [Unicode(false)]
    public string Address { get; set; } = null!;
}
