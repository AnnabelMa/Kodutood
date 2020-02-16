
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sport.Models;

namespace Sport.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SpordiContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any Sportlased.
            if (context.Sportlased.Any())
            {
                return;   // DB has been seeded
            }

            var sportlased = new Sportlane[]
            {
                new Sportlane { Eesnimi = "Carson",   Perekonnanimi = "Alexander",
                    RegistreeringuKP = DateTime.Parse("2010-09-01") },
                new Sportlane { Eesnimi = "Meredith", Perekonnanimi = "Alonso",
                    RegistreeringuKP = DateTime.Parse("2012-09-01") },
                new Sportlane { Eesnimi = "Arturo",   Perekonnanimi = "Anand",
                    RegistreeringuKP = DateTime.Parse("2013-09-01") },
                new Sportlane { Eesnimi = "Gytis",    Perekonnanimi = "Barzdukas",
                    RegistreeringuKP = DateTime.Parse("2012-09-01") },
                new Sportlane { Eesnimi = "Yan",      Perekonnanimi = "Li",
                    RegistreeringuKP = DateTime.Parse("2012-09-01") },
                new Sportlane { Eesnimi = "Peggy",    Perekonnanimi = "Justice",
                    RegistreeringuKP = DateTime.Parse("2011-09-01") },
                new Sportlane { Eesnimi = "Laura",    Perekonnanimi = "Norman",
                    RegistreeringuKP = DateTime.Parse("2013-09-01") },
                new Sportlane { Eesnimi = "Nino",     Perekonnanimi = "Olivetto",
                    RegistreeringuKP = DateTime.Parse("2005-09-01") }
            };

            foreach (Sportlane s in sportlased)
            {
                context.Sportlased.Add(s);
            }
            context.SaveChanges();

            var treenerid = new Treener[]
            {
                new Treener { Eesnimi = "Kim",     Perekonnanimi = "Abercrombie",
                    PalkamiseKP = DateTime.Parse("1995-03-11") },
                new Treener { Eesnimi = "Fadi",    Perekonnanimi = "Fakhouri",
                    PalkamiseKP = DateTime.Parse("2002-07-06") },
                new Treener { Eesnimi = "Roger",   Perekonnanimi = "Harui",
                    PalkamiseKP = DateTime.Parse("1998-07-01") },
                new Treener { Eesnimi = "Candace", Perekonnanimi = "Kapoor",
                    PalkamiseKP = DateTime.Parse("2001-01-15") },
                new Treener { Eesnimi = "Roger",   Perekonnanimi = "Zheng",
                    PalkamiseKP = DateTime.Parse("2004-02-12") }
            };

            foreach (Treener i in treenerid)
            {
                context.Treenerid.Add(i);
            }
            context.SaveChanges();

            var osakonds = new Osakond[]
            {
                new Osakond { Nimi = "Motosport",     Eelarve = 350000,
                    AlgusKP = DateTime.Parse("2007-09-01"),
                    TreenerID  = treenerid.Single( i => i.Perekonnanimi == "Abercrombie").ID },
                new Osakond { Nimi = "Veesport", Eelarve = 100000,
                    AlgusKP = DateTime.Parse("2007-09-01"),
                    TreenerID  = treenerid.Single( i => i.Perekonnanimi == "Fakhouri").ID },
                new Osakond { Nimi = "Talisport", Eelarve = 350000,
                    AlgusKP = DateTime.Parse("2007-09-01"),
                    TreenerID  = treenerid.Single( i => i.Perekonnanimi == "Harui").ID },
                new Osakond { Nimi = "Suvesport",   Eelarve = 100000,
                    AlgusKP = DateTime.Parse("2007-09-01"),
                    TreenerID  = treenerid.Single( i => i.Perekonnanimi == "Kapoor").ID }
            };

            foreach (Osakond d in osakonds)
            {
                context.Osakonnad.Add(d);
            }
            context.SaveChanges();

            var spordialad = new Spordiala[]
            {
                new Spordiala {SpordialaID = 1050, Nimi = "Kergejõustik",
                    OsakondID = osakonds.Single( s => s.Nimi == "Suvesport").OsakondID
                },
                new Spordiala {SpordialaID = 4022, Nimi = "Suusatamine",
                    OsakondID = osakonds.Single( s => s.Nimi == "Talisport").OsakondID
                },
                new Spordiala {SpordialaID = 4041, Nimi = "Autoralli",
                    OsakondID = osakonds.Single( s => s.Nimi == "Motosport").OsakondID
                },
                new Spordiala {SpordialaID = 1045, Nimi = "Uisutamine",
                    OsakondID = osakonds.Single( s => s.Nimi == "Talisport").OsakondID
                },
                new Spordiala {SpordialaID = 3141, Nimi = "Vettehüpped",
                    OsakondID = osakonds.Single( s => s.Nimi == "Veesport").OsakondID
                },
                new Spordiala {SpordialaID = 2021, Nimi = "Laskesuusatamine",
                    OsakondID = osakonds.Single( s => s.Nimi == "Talisport").OsakondID
                },
                new Spordiala {SpordialaID = 2042, Nimi = "Purjetamine",
                    OsakondID = osakonds.Single( s => s.Nimi == "Suvesport").OsakondID
                },
            };

            foreach (Spordiala c in spordialad)
            {
                context.Spordiala.Add(c);
            }
            context.SaveChanges();

            var asutuseAssignments = new AsutuseAssignment[]
            {
                new AsutuseAssignment {
                    TreenerID = treenerid.Single( i => i.Perekonnanimi == "Fakhouri").ID,
                    Location = "Smith 17" },
                new AsutuseAssignment {
                    TreenerID = treenerid.Single( i => i.Perekonnanimi == "Harui").ID,
                    Location = "Gowan 27" },
                new AsutuseAssignment {
                    TreenerID = treenerid.Single( i => i.Perekonnanimi == "Kapoor").ID,
                    Location = "Thompson 304" },
            };

            foreach (AsutuseAssignment o in asutuseAssignments)
            {
                context.AsutuseAssignments.Add(o);
            }
            context.SaveChanges();

            var spordialatreenerid = new SpordialaAssignment[]
            {
                new SpordialaAssignment {
                    SpordialaID = spordialad.Single(c => c.Nimi == "Kergejõustik" ).SpordialaID,
                    TreenerID = treenerid.Single(i => i.Perekonnanimi == "Kapoor").ID
                    },
                new SpordialaAssignment {
                    SpordialaID = spordialad.Single(c => c.Nimi == "Kergejõustik" ).SpordialaID,
                    TreenerID = treenerid.Single(i => i.Perekonnanimi == "Harui").ID
                    },
                new SpordialaAssignment {
                    SpordialaID = spordialad.Single(c => c.Nimi == "Suusatamine" ).SpordialaID,
                    TreenerID = treenerid.Single(i => i.Perekonnanimi == "Zheng").ID
                    },
                new SpordialaAssignment {
                    SpordialaID = spordialad.Single(c => c.Nimi == "Autoralli" ).SpordialaID,
                    TreenerID = treenerid.Single(i => i.Perekonnanimi == "Zheng").ID
                    },
                new SpordialaAssignment {
                    SpordialaID = spordialad.Single(c => c.Nimi == "Uisutamine" ).SpordialaID,
                    TreenerID = treenerid.Single(i => i.Perekonnanimi == "Fakhouri").ID
                    },
                new SpordialaAssignment {
                    SpordialaID = spordialad.Single(c => c.Nimi == "Vettehüpped" ).SpordialaID,
                    TreenerID = treenerid.Single(i => i.Perekonnanimi == "Harui").ID
                    },
                new SpordialaAssignment {
                    SpordialaID = spordialad.Single(c => c.Nimi == "Laskesuusatamine" ).SpordialaID,
                    TreenerID = treenerid.Single(i => i.Perekonnanimi == "Abercrombie").ID
                    },
                new SpordialaAssignment {
                    SpordialaID = spordialad.Single(c => c.Nimi == "Purjetamine" ).SpordialaID,
                    TreenerID = treenerid.Single(i => i.Perekonnanimi == "Abercrombie").ID
                    },
            };

            foreach (SpordialaAssignment si in spordialatreenerid)
            {
                context.SpordialaAssignments.Add(si);
            }
            context.SaveChanges();

            var registreering = new Registreering[]
            {
                new Registreering {
                    SportlaneID = sportlased.Single(s => s.Perekonnanimi == "Alexander").ID,
                    SpordialaID = spordialad.Single(c => c.Nimi == "Kergejõustik" ).SpordialaID,

                },
                    new Registreering {
                    SportlaneID = sportlased.Single(s => s.Perekonnanimi == "Alexander").ID,
                    SpordialaID = spordialad.Single(c => c.Nimi == "Suusatamine" ).SpordialaID,

                    },
                    new Registreering {
                    SportlaneID = sportlased.Single(s => s.Perekonnanimi == "Alexander").ID,
                    SpordialaID = spordialad.Single(c => c.Nimi == "Purjetamine" ).SpordialaID,

                    },
                    new Registreering {
                        SportlaneID = sportlased.Single(s => s.Perekonnanimi == "Alonso").ID,
                    SpordialaID =  spordialad.Single(c => c.Nimi == "Vettehüpped" ).SpordialaID,

                    },
                    new Registreering {
                        SportlaneID = sportlased.Single(s => s.Perekonnanimi == "Alonso").ID,
                    SpordialaID = spordialad.Single(c => c.Nimi == "Uisutamine" ).SpordialaID,

                    },
                    new Registreering {
                    SportlaneID = sportlased.Single(s => s.Perekonnanimi == "Alonso").ID,
                    SpordialaID = spordialad.Single(c => c.Nimi == "Laskesuusatamine" ).SpordialaID,

                    },
                    new Registreering {
                    SportlaneID = sportlased.Single(s => s.Perekonnanimi == "Anand").ID,
                    SpordialaID = spordialad.Single(c => c.Nimi == "Kergejõustik" ).SpordialaID
                    },
                    new Registreering {
                    SportlaneID = sportlased.Single(s => s.Perekonnanimi == "Anand").ID,
                    SpordialaID = spordialad.Single(c => c.Nimi == "Autoralli").SpordialaID,

                    },
                new Registreering {
                    SportlaneID = sportlased.Single(s => s.Perekonnanimi == "Barzdukas").ID,
                    SpordialaID = spordialad.Single(c => c.Nimi == "Kergejõustik").SpordialaID,

                    },
                    new Registreering {
                    SportlaneID = sportlased.Single(s => s.Perekonnanimi == "Li").ID,
                    SpordialaID = spordialad.Single(c => c.Nimi == "Autoralli").SpordialaID,

                    },
                    new Registreering {
                    SportlaneID = sportlased.Single(s => s.Perekonnanimi == "Justice").ID,
                    SpordialaID = spordialad.Single(c => c.Nimi == "Vettehüpped").SpordialaID,

                    }
            };

            foreach (Registreering r in registreering)
            {
                var RegistreeringInDataBase = context.Registreeringud.Where(
                    s =>
                            s.Sportlane.ID == r.SportlaneID &&
                            s.Spordiala.SpordialaID == r.SpordialaID).SingleOrDefault();
                if (RegistreeringInDataBase == null)
                {
                    context.Registreeringud.Add(r);
                }
            }
            context.SaveChanges();
        }
    }
}
