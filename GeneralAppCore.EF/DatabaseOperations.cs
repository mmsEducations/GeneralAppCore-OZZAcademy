using GeneralAppCore.EF.Context;
using GeneralAppCore.EF.Entities;

namespace GeneralAppCore.EF
{
    internal class DatabaseOperations
    {

        static void SaveToDb()
        {
            try
            {
                using (EducationContext context = new EducationContext())
                {
                    Group g1 = new Group()
                    {
                        Name = "OZAN Akademi Kurs",
                        StartDate = DateTime.Now.AddYears(2),
                        EndDate = DateTime.Now.AddYears(19),
                        IsActive = false,

                    };
                    context.Groups.Add(g1);
                    int rowsAffected = context.SaveChanges();
                    if (rowsAffected == 1)
                    {
                        Console.WriteLine(g1.ToString() + " bilgilerine sahip kayıt Database eklenmiştir");
                    }
                    else
                    {
                        Console.WriteLine("Database Kayıt ekleme başarısız");
                    }

                    //
                }

            }

            catch (MySpecialException)
            {

            }
            catch (DivideByZeroException)
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine("try bloğunda hata olursa bu kısımçalışacaktır");
                Console.WriteLine("Hata mesajı " + ex.Message);
                Console.WriteLine("Hata detay" + ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Hata olsa  da olmasada bu blok çalışacaktır");
            }
        }






        //IT sektöründe genel olarak sürekli veriler ile çalışır ,VeriKaynağı : Kod ile verilere erişme işi Entity Fraework
        //EF ile eriştiğimiz veriler üzerinden manüpülasyon yapmamızı sağlayan yapıya LİNQ 
        //ORM:Kod tarafında objeler üzerinden db işlemleri yapmamızı sağlıyor 


        //Linq To Xml 
        //Linq To Object 
        //Linq To Entitis 
        //Linq Methodları
        /*
          1)Extension Method Yöntemi 
           Where(x=>x.  || ) 
           Sum()
           Order By 
           Take()
           Select()

        2)Query Yöntemi 
          //Tsql benzer 
         */


        /*

        Daha önce var olmayan yeni vir tip oluşturmuş oluyoruz 
          new
                                   { 

                                   }
         */


        public class MySpecialException : Exception
        {

        }


        static void Ex1()
        {
            var userLogin = new
            {
                UserName = "1",
                Password = 12,
                IsRemember = true,
                Test = 10 * 10
            };

            var userName = userLogin.UserName;

            EducationContext context = new EducationContext();
            List<Student> students = context.Students.ToList();


            List<int> groupIds = students.Select(s => s.GroupId).ToList();

            List<int> uniqueGroupIds = students.Select(s => s.GroupId)
                                                .Distinct()
                                                .ToList();

            var groupsData = context.Groups.OrderByDescending(g => g.StartDate).Skip(1).Take(3);

            var lastGroup = context.Groups.OrderBy(x => x.StartDate).LastOrDefault();

            var studentAndGroupsData = (from s in context.Students
                                        join g in context.Groups
                                        on s.GroupId equals g.GroupId
                                        select new
                                        {
                                            NameLastname = s.Name + " " + s.Lastname,
                                            GroupName = g.Name
                                        });

            int number_ = 1;

            Console.ReadLine();
        }



        static void DeleteGroup()
        {
            try
            {
                using (EducationContext context = new EducationContext())
                {
                    Group group = context.Groups.OrderByDescending(g => g.GroupId).FirstOrDefault();
                    context.Groups.Remove(group);

                    int rowsAffected = context.SaveChanges();
                    if (rowsAffected == 1)
                    {
                        Console.WriteLine(group.ToString() + " bilgilerine sahip kayıt Database^'den silinmiştir");
                    }
                    else
                    {
                        Console.WriteLine("Database silme başarısız");
                    }

                    //
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("try bloğunda hata olursa bu kısımçalışacaktır");
                Console.WriteLine("Hata mesajı " + ex.Message);
                Console.WriteLine("Hata detay" + ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Hata olsa  da olmasada bu blok çalışacaktır");
            }
        }


    }


}
