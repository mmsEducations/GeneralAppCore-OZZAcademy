// See https://aka.ms/new-console-template for more information

using GeneralAppCore.EF.Context;

Console.WriteLine("Hello, World!");

try
{
    using (var context = new EducationContext())
    {
        GeneralAppCore.EF.Entities.Group sGroup = context.Groups.Where(x => x.GroupId == 1003).FirstOrDefault();
        sGroup.Name = "ESR Akademi2";
        sGroup.StartDate = DateTime.Now;
        int rowsAffected = context.SaveChanges();

        if (rowsAffected == 1)
        {
            Console.WriteLine(sGroup.ToString() + " bilgilerine sahip kayıt Database'den güncellendi");
        }
        else
        {
            Console.WriteLine("Databaseden güncelleme başarısız");
        }
    }

}
catch (Exception)
{

    throw;
}
finally
{
}

int num = 1;
