using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDF.ProgramDec.BL.Models
{
   public class User
    {
        public int Id { get; set; }

        [DisplayName("User Id")]
        public string UserId { get; set; }
        
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [DisplayName("LastName")]
        public string LastName { get; set; }
        
        [DisplayName("Password")]
        public string PassCode { get; set; }

        public User()
        {

        }

        public User(string userid, string passcode)
        {
            // A User is trying to log in
            UserId = userid;
            PassCode = passcode; 

           
        }

        public User(int id, string userid, string firstname, string lastname, string passcode)
        {
            //Updated a user
            UserId = userid;
            PassCode = passcode;
            Id = id;
            FirstName = firstname;
            PassCode = passcode;

        }
        public User(string userid, string firstname, string lastname, string passcode)
        {
            //creating a user
            UserId = userid;
            PassCode = passcode;
            FirstName = firstname;
            PassCode = passcode;

        }

    }
}
