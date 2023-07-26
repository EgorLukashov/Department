using System.Collections.Generic;

namespace Department.Entity;

public class Employee
{
    //[Key]
    public int EmployeeId {get; set; }
    public string? Surname {get; set; }
    public string? Name {get; set; }
    public string? MiddleName {get; set; }
    public string? Address {get; set; }
    public string? Phone {get; set; }
    public string? Status {get; set; }
    public virtual ICollection<Meeting>? Meeting { get; set; }
    public virtual ICollection<Commission>? Commission { get; set; }
    public virtual ICollection<Membership>? Membership { get; set; }


}