using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPS.Data.Model
{
    // Not sure
    public class SchedulingSpreadsheet
    {
        public Guid Id { get; set; }
        [MaxLength]
        public string Description { get; set; } = string.Empty;
        public virtual HashSet<PlannedActivity>? PlannedActivities { get; set; }
        public virtual HashSet<Activity>? Activities { get; set; }
        
    }
}