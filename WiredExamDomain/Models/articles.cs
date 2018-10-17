using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiredExamDomain.Models
{
    public class source
    {
        [Key]
        public int sourceId { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }
    public class articles
    {
        [Key]
        public int articlesId { get; set; }
        public source sources { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public string publishedAt { get; set; }
    }
}
