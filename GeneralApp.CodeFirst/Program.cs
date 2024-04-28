// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

//1
public class HospitalTrackingContext : DbContext
{
    //3 Mapping :Entity 
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<Personel> Personels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=HospitalTrackingDb;Integrated Security=true;Encrypt = False");
    }
}

//2:Entity
public class Hospital
{
    public int HospitalId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public double Capacity { get; set; }
    public int PersonelCount { get; set; }
}

public class Personel
{
    public int PersonelId { get; set; }
    public int Name { get; set; }
}

//Package manager console