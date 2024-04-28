using System;
using System.Collections.Generic;

namespace GeneralAppCore.EF.Entities;

public partial class Student
{
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public int GroupId { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Attendancy> Attendancies { get; set; } = new List<Attendancy>();

    public virtual Group Group { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual ICollection<StudentPrice> StudentPrices { get; set; } = new List<StudentPrice>();
}
