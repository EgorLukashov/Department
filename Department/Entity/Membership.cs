using System;
using System.ComponentModel.DataAnnotations;

namespace Department.Entity;

public class Membership
{
    [Key]
    public int MemberId { get; set; }
    public string? Position { get; set; }
    public DateTime? StartOfWork {get; set; }
    public DateTime? EndOfWork {get; set; }
    public int CommissionId { get; set; }
    public int EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }
    public virtual Commission? Commission{get; set; }
}