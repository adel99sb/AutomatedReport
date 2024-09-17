using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Test
    {

        public Guid Id { get; set; }
        public string Description { get; set; }
        public double TotalMark {  get; set; }
        public bool IsDone { get; set; }
        public Guid SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public Guid? DivisionId { get; set; }
        public DateTime DateTime { get; set; }

    }
}
