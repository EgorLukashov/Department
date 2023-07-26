using System;
using System.Collections.Generic;


namespace Department.Entity;

public class Commission
{
    public int CommissionId { get; set; }
    public string? Name { get; set; }
    public DateTime? DateOfFoundation {get; set; }
    public int HeadId { get; set; }
    public virtual Employee? Head{ get; set; } 
    public virtual ICollection<Meeting>? Meeting { get; set; }
    public virtual ICollection<Membership>? Membership { get; set; }
}