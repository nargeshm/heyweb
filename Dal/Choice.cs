using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dal
{
   public class Choice
    {
        public int ChoiceId { get; set; }
        public bool AnswerIstrue { get; set; }
        public string ChoiceText { get; set; }

        [ForeignKey("answer")]
        public int? AnswerId { get; set; }
        public Answer answer { get; set; }

        [ForeignKey("question")]
        public int? QuestionId { get; set; }
        public Question question { get; set; }

    }
}
