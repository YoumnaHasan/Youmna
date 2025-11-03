using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2.Models;

public class Lease
{
    public Student Tenant { get; set; } = default!; 
    public Room Room { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }


    public bool IsActive => EndDate is null || EndDate > DateTime.Now;
}
