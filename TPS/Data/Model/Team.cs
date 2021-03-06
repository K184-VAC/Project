using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPS.Data.Model
{
    public class Team
    {
        public Guid Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength]
        public string Description { get; set; } = string.Empty;
        public virtual HashSet<TeamMember>? Memberships { get; set; }
        public virtual HashSet<Project>? Projects { get; set; }

        public Team(string name){
            Name = name;
        }
        
    }
}