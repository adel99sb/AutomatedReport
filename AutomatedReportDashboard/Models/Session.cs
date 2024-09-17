using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Session
    {
        public Guid Id { get; set; }
        public Guid DivisionId { get; set; }
        public Guid ClassId { get; set; }
        public Guid SubjectId { get; set; }
        public DayOfWeek Day { get; set; }
        public Guid HallId { get; set; }
        public string SubjectName { get; set; }
        public string HallName { get; set; }
        public string SessionTime { get; set; }
    }
}
