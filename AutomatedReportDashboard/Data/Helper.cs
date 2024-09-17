using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp1.Data
{
    public static class Helper
    {
        public static T ToObj<T>(this object data)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var Result = JsonSerializer.Deserialize<T>(data.ToString(), options);
            return Result;
        }
        public static string ConvertDayToArabic(string day)
        {
            return day switch
            {
                "Sunday" => "احد",
                "Monday" => "اثنين",
                "Tuesday" => "ثلاثاء",
                "Wednesday" => "اربعاء",
                "Thursday" => "خميس",
                "Friday" => "جمعة",
                "Saturday" => "سبت",
                _ => day
            };
        }
    }
}
