using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal
{
   public  class Question
    {
        public int QuestionId { get; set; }
        public string Description { get; set; }
        [ForeignKey("user")]
        public int? UserId { get; set; }
        public User user { get; set; }
        public List<Choice> choice { get; set; }
    }
}
