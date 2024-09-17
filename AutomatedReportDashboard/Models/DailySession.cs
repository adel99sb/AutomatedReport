using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class DailySession
    {
        public DateTime date { get; set; }

        public Guid sessions_RecordId { get; set; }
        public string subject_Title { get; set; }


    }
}
