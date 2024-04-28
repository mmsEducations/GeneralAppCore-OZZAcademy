namespace GeneralAppCore.EF.Entities;

public partial class Group
{
    public int GroupId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}

public partial class Group
{
    public override string ToString()
    {
        return $"Grup Adı:{Name}-Kuruluş yılı:{StartDate}";
    }
}
