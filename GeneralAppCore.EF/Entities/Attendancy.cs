namespace GeneralAppCore.EF.Entities;

public partial class Attendancy
{
    public int AttendanceId { get; set; }

    public int StudentId { get; set; }

    public DateTime Creadate { get; set; }

    public virtual Student Student { get; set; } = null!;
}
