using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedReportCore.Responces.DTOs
{
    public class GroupedSessionDto
    {
        public Guid Id { get; set; }
        public string Class { get; set; }
        public string From_Time { get; set; }
        public string To_Time { get; set; }
        public string Subject { get; set; }
        public string Hall { get; set; }
    }
}
