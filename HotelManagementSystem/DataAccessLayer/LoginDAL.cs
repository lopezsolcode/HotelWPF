using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelManagementSystem.Models;


namespace HotelManagementSystem.DataAccessLayer
{
    public class LoginDAL
    {
        private readonly HotelDbContext _context;
        public LoginDAL()
        {
            _context = new HotelDbContext();
        }
        public bool ValidateUser(string username, string password)
        {
            return _context.DboUsers.Any(u => u.Username == username && u.Password == password);
        }
    }
}
