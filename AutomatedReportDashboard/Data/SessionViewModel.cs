using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace MauiApp1.Data
{
    public class SessionViewModel
    {
        public Guid id { get; set; }
        public Guid sessions_RecordId { get; set; }
        public string Class { get; set; }
        public string Subject { get; set; }
        public string Hall { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime Date { get; set; }
        public string Subject_Title { get; set; }
        public bool IsAlreadyExist { get; set; }

    }
}
