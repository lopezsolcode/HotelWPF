using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Models;

[Table("dbo.Rooms")]
public partial class DboRoom
{
    [Key]
    [Column("roomid")]
    public int Roomid { get; set; }

    [Column("roomNo")]
    [StringLength(250)]
    [Unicode(false)]
    public string RoomNo { get; set; } = null!;

    [Column("roomType")]
    [StringLength(250)]
    [Unicode(false)]
    public string RoomType { get; set; } = null!;

    [Column("bed")]
    [StringLength(250)]
    [Unicode(false)]
    public string Bed { get; set; } = null!;

    [Column("price")]
    public long Price { get; set; }

    [Column("booked")]
    [StringLength(50)]
    [Unicode(false)]
    public string Booked { get; set; } = null!;
}
