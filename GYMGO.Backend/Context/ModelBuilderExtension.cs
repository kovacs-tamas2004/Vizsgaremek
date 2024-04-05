using GYMGO.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GYMGO.Backend.Context
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<Trainer> trainers = new List<Trainer>
            {
                new Trainer
                {
                    Id=Guid.NewGuid(),
                    FirstName="Zsolt",
                    LastName="Faragó",
                    BirthsDay=new DateTime(1989,07,10),
                    Email="farago.zsolt@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Trainer
                {
                    Id=Guid.NewGuid(),
                    FirstName="Anita",
                    LastName="Nagy",
                    BirthsDay=new DateTime(1992,02,23),
                    Email="nagyanita0223@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Trainer
                {
                    Id=Guid.NewGuid(),
                    FirstName="Béla",
                    LastName="Lakatos",
                    BirthsDay=new DateTime(2000,11,15),
                    Email="lakbela@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Trainer
                {
                    Id=Guid.NewGuid(),
                    FirstName="László",
                    LastName="Kiss",
                    BirthsDay=new DateTime(1988,12,01),
                    Email="farago1998@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                },
                new Trainer
                {
                    Id=Guid.NewGuid(),
                    FirstName="Brigitta",
                    LastName="Szekeres",
                    BirthsDay=new DateTime(2002,04,30),
                    Email="brigitta.szekeres@gmail.com",
                    AgeGroupId=Guid.NewGuid(),
                    WorkingTypeId=Guid.NewGuid(),
                }
            };
            // Trainers
            modelBuilder.Entity<Trainer>().HasData(trainers);

            List<Visitor> visitors = new List<Visitor>
            {
                new Visitor
                {
                    Id=Guid.NewGuid(),
                    FirstName="Bence",
                    LastName="Ábrahám",
                    BirthsDay=new DateTime(1994,03,24),
                    Email="abraham1994@gmail.com",
                    WorkingFormId=Guid.NewGuid(),
                },
                new Visitor
                {
                    Id=Guid.NewGuid(),
                    FirstName="Kevin",
                    LastName="Lakatos",
                    BirthsDay=new DateTime(2000,11,30),
                    Email="lakkev1130@gmail.com",
                    WorkingFormId=Guid.NewGuid(),
                },
                new Visitor
                {
                    Id=Guid.NewGuid(),
                    FirstName="Eszter",
                    LastName="Kiss",
                    BirthsDay=new DateTime(1996,09,03),
                    Email="eszterkiss@gmail.com",
                    WorkingFormId=Guid.NewGuid(),
                },
                new Visitor
                {
                    Id=Guid.NewGuid(),
                    FirstName="Gréta",
                    LastName="Kovács",
                    BirthsDay=new DateTime(1982,07,28),
                    Email="kovacs.greta0728@gmail.com",
                    WorkingFormId=Guid.NewGuid(),
                },
                new Visitor
                {
                    Id=Guid.NewGuid(),
                    FirstName="Ákos",
                    LastName="Nagy",
                    BirthsDay=new DateTime(2000,01,11),
                    Email="nagyakos0111@gmail.com",
                    WorkingFormId=Guid.NewGuid(),
                },
                new Visitor
                {
                    Id=Guid.NewGuid(),
                    FirstName="Kamilla",
                    LastName="Hortobágyi",
                    BirthsDay=new DateTime(1999,02,24),
                    Email="horkamilla0224@gmail.com",
                    WorkingFormId=Guid.NewGuid(),
                },
                new Visitor
                {
                    Id=Guid.NewGuid(),
                    FirstName="Ferenc",
                    LastName="Hajnal",
                    BirthsDay=new DateTime(2003,10,08),
                    Email="ferenc.hajnal@gmail.com",
                    WorkingFormId=Guid.NewGuid(),
                },
                new Visitor
                {
                    Id=Guid.NewGuid(),
                    FirstName="Enikő",
                    LastName="Papp",
                    BirthsDay=new DateTime(1997,09,16),
                    Email="pappeniko0916@gmail.com",
                    WorkingFormId=Guid.NewGuid(),
                }
            };
            // Visitors
            modelBuilder.Entity<Visitor>().HasData(visitors);

            List<Owner> owners = new List<Owner>
            {
                new Owner
                {
                    Id=Guid.NewGuid(),
                    FirstName="Virág",
                    LastName="Sánta",
                    BirthsDay=new DateTime(1987,11,26),
                    Email="santa.virag1126@gmail.com",
                    Tulajdon="Global Fitness",
                    Telepules="Szeged",
                },
                new Owner
                {
                    Id=Guid.NewGuid(),
                    FirstName="Endre",
                    LastName="Szabó",
                    BirthsDay=new DateTime(1978,05,21),
                    Email="endre.szabo@gmail.com",
                    Tulajdon="Gym Class",
                    Telepules="Szeged",
                },
                new Owner
                {
                    Id=Guid.NewGuid(),
                    FirstName="Patrik",
                    LastName="Barta",
                    BirthsDay=new DateTime(1983,03,24),
                    Email="patrikbarta@gmail.com",
                    Tulajdon="Chili Fitness",
                    Telepules="Budapest",
                }
            };
            // Owners
            modelBuilder.Entity<Owner>().HasData(owners);
        }
    }
}
