using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiredExamDomain.Models
{
    public class Exam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int examId { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<articles> articles { get; set; }
        public List<question> quetions { get; set; }
    }

    public class question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //auo increment *** 
        public int questionId { get; set; }
        
        public string contextQuestion { get; set; }
   
        public string aoption { get; set; }
   
        public string boption { get; set; }
        
        public string coption { get; set; }
 
        public string doption { get; set; }
      
        public string trueoption { get; set; }
        public Exam Exam { get; set; }
        public int examId { get; set; }
        public int order { get; set; }
    }
}
