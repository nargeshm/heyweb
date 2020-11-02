using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    public class Answer
    {
       public int AnswerId { get; set; }      
       public  List<Choice> choices { get; set; }
       public List<Question> questions { get; set; }
       public List<User> users { get; set; }
    }
}
