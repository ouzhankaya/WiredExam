using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiredExamDomain.Models
{
    public class questions
    {
        public int questionId { get; set; }
      
        public string contextQuestion { get; set; }
       
        public string aoption { get; set; }
       
        public string boption { get; set; }
      
        public string coption { get; set; }
       
        public string doption { get; set; }
        
        public string trueoption { get; set; }
        public int examId { get; set; }
        public int order { get; set; }
    }
}
