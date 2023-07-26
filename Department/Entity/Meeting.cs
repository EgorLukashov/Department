using System;

namespace Department.Entity;

public class Meeting
{
    public int MeetingId { get; set; }
    public int CommissionId { get; set; }
    public DateTime? DateOfMeeting {get; set; }
    public string? PlaceOfMeeting { get; set; }
    public int HeadId { get; set; }

    public virtual Employee? Head { get; set; }
    public virtual Commission? Commission { get; set; }
}