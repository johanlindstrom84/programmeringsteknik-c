using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.common.Models;

namespace TimeSheet.common
{
    public class TimesheetProcessor1
    {
        public static int CalculateTimeFourCustomer(List<TimeSheetEntryModel> entries, string customerName)
        {
            int sum = 0;
            foreach (var entry in entries)
            {
               int customerIndex = entry.WorkDone.IndexOf(customerName, StringComparison.OrdinalIgnoreCase);

                if (customerIndex >= 0)
                {
                    sum += entry.HoursWorked;
                }
                
            }
            return sum;
        }
        public static int CalculateTimeWorked(List<TimeSheetEntryModel> entries) =>
              entries.Sum(x => x.HoursWorked);

    }
}
