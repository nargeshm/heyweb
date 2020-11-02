using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal
{
   public  class User
    {
        public int UserId { get; set; }
        public string name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Question>questions { get; set; }

        [ForeignKey("answer")]
        public int? AnswerId { get; set; }
        public Answer answer { get; set; }
    }
}
 