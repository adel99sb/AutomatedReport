using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Data
{
    public class AddSessionRequste1
    {
        public Guid divisionId {  get; set; }
        public Guid _ClassId { get; set; }
        public Guid subjectId { get; set; }
        public int day {  get; set; }
        public Guid hallId { get; set; }
    }
}
