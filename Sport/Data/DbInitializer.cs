using Sport.Models;
using System;
using System.Linq;

namespace Sport.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SpordiContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Sportlased.Any())
            {
                return;   // DB has been seeded
            }

            var sportlased = new Sportlane[]
            {
            new Sportlane{Eesnimi="Carson",Perekonnanimi="Alexander",RegistreeringuKP=DateTime.Parse("2005-09-01")},
            new Sportlane{Eesnimi="Meredith",Perekonnanimi="Alonso",RegistreeringuKP=DateTime.Parse("2002-09-01")},
            new Sportlane{Eesnimi="Arturo",Perekonnanimi="Anand",RegistreeringuKP=DateTime.Parse("2003-09-01")},
            new Sportlane{Eesnimi="Gytis",Perekonnanimi="Barzdukas",RegistreeringuKP=DateTime.Parse("2002-09-01")},
            new Sportlane{Eesnimi="Yan",Perekonnanimi="Li",RegistreeringuKP=DateTime.Parse("2002-09-01")},
            new Sportlane{Eesnimi="Peggy",Perekonnanimi="Justice",RegistreeringuKP=DateTime.Parse("2001-09-01")},
            new Sportlane{Eesnimi="Laura",Perekonnanimi="Norman",RegistreeringuKP=DateTime.Parse("2003-09-01")},
            new Sportlane{Eesnimi="Nino",Perekonnanimi="Olivetto",RegistreeringuKP=DateTime.Parse("2005-09-01")}
            };
            foreach (Sportlane s in sportlased)
            {
                context.Sportlased.Add(s);
            }
            context.SaveChanges();

            var spordialad = new Spordiala[]
            {
            new Spordiala{SpordialaID=1050,Nimi="Kergejõustik"},
            new Spordiala{SpordialaID=4022,Nimi="Ujumine"},
            new Spordiala{SpordialaID=4041,Nimi="Maadlus"},
            new Spordiala{SpordialaID=1045,Nimi="Võimlemine"},
            new Spordiala{SpordialaID=3141,Nimi="Uisutamine"},
            new Spordiala{SpordialaID=2021,Nimi="Tennis"},
            new Spordiala{SpordialaID=2042,Nimi="Raskejõustik"}
            };
            foreach (Spordiala c in spordialad)
            {
                context.Spordiala.Add(c);
            }
            context.SaveChanges();

            var registreeringud = new Registreering[]
            {
            new Registreering{SportlaseID=1,SpordialaID=1050},
            new Registreering{SportlaseID=1,SpordialaID=4022},
            new Registreering{SportlaseID=1,SpordialaID=4041},
            new Registreering{SportlaseID=2,SpordialaID=1045},
            new Registreering{SportlaseID=2,SpordialaID=3141},
            new Registreering{SportlaseID=2,SpordialaID=2021},
            new Registreering{SportlaseID=3,SpordialaID=1050},
            new Registreering{SportlaseID=4,SpordialaID=1050},
            new Registreering{SportlaseID=4,SpordialaID=4022},
            new Registreering{SportlaseID=5,SpordialaID=4041},
            new Registreering{SportlaseID=6,SpordialaID=1045},
            new Registreering{SportlaseID=7,SpordialaID=3141},
            };
            foreach (Registreering r in registreeringud)
            {
                context.Registreeringud.Add(r);
            }
            context.SaveChanges();
        }
    }
}