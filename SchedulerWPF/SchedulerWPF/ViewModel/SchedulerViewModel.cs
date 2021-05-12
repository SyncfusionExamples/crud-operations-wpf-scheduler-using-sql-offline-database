using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerWPF
{
    class SchedulerViewModel
    {
        public List<Meetings> Meetings { get; set; }

        public SchedulerViewModel()
        {
            try
            {
                var dataTable = ConnectDB.GetDataTable("SELECT * FROM Meetings");
                Meetings = new List<Meetings>();
                Meetings = (from DataRow dr in dataTable.Rows
                            select new Meetings()
                            {
                                Subject = dr["Subject"].ToString(),
                                StartTime = dr["StartTime"] as DateTime? ?? DateTime.Now,
                                EndTime = dr["EndTime"] as DateTime? ?? DateTime.Now
                            }).ToList();
            }
            catch
            {
                // Handle exceptions
            }
        }
    }
}
