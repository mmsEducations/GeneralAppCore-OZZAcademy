using System;
using System.Collections.Generic;

namespace GeneralAppCore.EF.Entities;

public partial class Lesson
{
    public int LessonId { get; set; }

    public int StudentId { get; set; }

    public string LessonName { get; set; } = null!;

    public DateTime Creadate { get; set; }

    public virtual Student Student { get; set; } = null!;
}
