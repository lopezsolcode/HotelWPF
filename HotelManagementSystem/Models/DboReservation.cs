using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Models;

[Table("dbo.Reservations")]
public partial class DboReservation
{
    [Key]
    [Column("reservationID")]
    public int ReservationId { get; set; }

    [Column("idRoom")]
    public int IdRoom { get; set; }

    [Column("checkInDate")]
    public DateOnly CheckInDate { get; set; }

    [Column("checkOutDate")]
    public DateOnly? CheckOutDate { get; set; }

    [Column("roomID")]
    public int RoomId { get; set; }

    [Column("employeeID")]
    public int EmployeeId { get; set; }
}
