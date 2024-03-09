using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using WebService.Data.Contexts;

namespace WebService.Data.Seeds
{
    public static class Seeding
    {
        public static void Seed(ApplicationDbContext dbContext)
        {
           
            var toyota = new Brand() { Id=1, Name="Toyota" };
            var ford = new Brand() { Id=2, Name="Ford" };
            var mercedes = new Brand() { Id=3, Name="Mercedes" };
            var bmw = new Brand() { Id=4, Name="BMW" };
            var lada = new Brand() { Id=5, Name="Lada" };
            var mazda = new Brand() { Id=6, Name="Mazda" };
            var audi = new Brand() { Id=7, Name="Audi" };
            var dodge = new Brand() { Id=8, Name="Dodge" };
            var chevrolet = new Brand() { Id=9, Name="Chevrolet" };
            var jeep = new Brand() { Id=10, Name="Jeep" };
            var infiniti = new Brand() { Id=11, Name="Infiniti" };
            var lamburgumbur = new Brand() { Id=12, Name="Lamburgumbur" };
            var tesla = new Brand() { Id=13, Name="Tesla" };
            var vw = new Brand() { Id=14, Name="Volkswagen" };
            var kia = new Brand() { Id=15, Name="Kia" };
            var hundai = new Brand() { Id=1, Name="Hundai" };
            var nissan = new Brand() { Id=1, Name="Nissan" };

            dbContext.Brands.AddRange(new List<Brand>() { toyota, ford, mercedes, bmw, lada, mazda, audi, dodge, chevrolet, jeep, infiniti, lamburgumbur, tesla, vw, kia, hundai, nissan });
            dbContext.SaveChanges();

            dbContext.Models.AddRange(new List<Model>()
            {
                new Model(){BrandId=toyota.Id,Name="Corolla"},
                  new Model(){BrandId=toyota.Id,Name="Prius"},
                  new Model(){BrandId=toyota.Id,Name="Camry"},
                  new Model(){BrandId=toyota.Id,Name="Rav4"},

                new Model(){BrandId=ford.Id,Name="Edge"},
                  new Model(){BrandId=ford.Id,Name="Escort"},
                  new Model(){BrandId=ford.Id,Name="Focus"},
                  new Model(){BrandId=ford.Id,Name="Fusion"},


                new Model(){BrandId=mercedes.Id,Name="A Class"},
                  new Model(){BrandId=mercedes.Id,Name="B Class"},
                  new Model(){BrandId=mercedes.Id,Name="C Class"},
                  new Model(){BrandId=mercedes.Id,Name="E Class"},
                  new Model(){BrandId=mercedes.Id,Name="S Class"},
                  new Model(){BrandId=mercedes.Id,Name="G Class"},

                new Model(){BrandId=bmw.Id,Name="1 Series"},
                  new Model(){BrandId=bmw.Id,Name="2 Series"},
                  new Model(){BrandId=bmw.Id,Name="3 Series"},
                  new Model(){BrandId=bmw.Id,Name="4 Series"},
                  new Model(){BrandId=bmw.Id,Name="5 Series"},
                  new Model(){BrandId=bmw.Id,Name="6 Series"},
                  new Model(){BrandId=bmw.Id,Name="7 Series"},
                  new Model(){BrandId=bmw.Id,Name="8 Series"},
                  new Model(){BrandId=bmw.Id,Name="M Series"},
                  new Model(){BrandId=bmw.Id,Name="Z Series"},
                  new Model(){BrandId=bmw.Id,Name="I Series"},

                new Model(){BrandId=lada.Id,Name="2101"},
                  new Model(){BrandId=lada.Id,Name="21011"},
                  new Model(){BrandId=lada.Id,Name="21013"},
                  new Model(){BrandId=lada.Id,Name="2102"},
                  new Model(){BrandId=lada.Id,Name="2103"},
                  new Model(){BrandId=lada.Id,Name="2104"},
                  new Model(){BrandId=lada.Id,Name="2105"},
                  new Model(){BrandId=lada.Id,Name="2106"},
                  new Model(){BrandId=lada.Id,Name="2107"},
                  new Model(){BrandId=lada.Id,Name="2108"},
                  new Model(){BrandId=lada.Id,Name="2109"},
                  new Model(){BrandId=lada.Id,Name="2110"},
                  new Model(){BrandId=lada.Id,Name="2111"},
                  new Model(){BrandId=lada.Id,Name="2112"},

                new Model(){BrandId=mazda.Id,Name="2"},
                  new Model(){BrandId=mazda.Id,Name="3"},
                  new Model(){BrandId=mazda.Id,Name="323"},
                  new Model(){BrandId=mazda.Id,Name="5"},
                  new Model(){BrandId=mazda.Id,Name="6"},
                  new Model(){BrandId=mazda.Id,Name="B-series"},
                  new Model(){BrandId=mazda.Id,Name="CX-3"},
                  new Model(){BrandId=mazda.Id,Name="CX-30"},
                  new Model(){BrandId=mazda.Id,Name="CX-5"},
                  new Model(){BrandId=mazda.Id,Name="CX-60"},
                  new Model(){BrandId=mazda.Id,Name="CX-7"},
                  new Model(){BrandId=mazda.Id,Name="CX-9"},
                  new Model(){BrandId=mazda.Id,Name="CX-90"},
                  new Model(){BrandId=mazda.Id,Name="MX-60"},

                new Model(){BrandId=audi.Id,Name="100"},
                  new Model(){BrandId=audi.Id,Name="A1"},
                  new Model(){BrandId=audi.Id,Name="A2"},
                  new Model(){BrandId=audi.Id,Name="A3"},
                  new Model(){BrandId=audi.Id,Name="A4"},
                  new Model(){BrandId=audi.Id,Name="A5"},
                  new Model(){BrandId=audi.Id,Name="A6"},
                  new Model(){BrandId=audi.Id,Name="A7"},
                  new Model(){BrandId=audi.Id,Name="A8"},
                  new Model(){BrandId=audi.Id,Name="Q2"},
                  new Model(){BrandId=audi.Id,Name="Q3"},
                  new Model(){BrandId=audi.Id,Name="Q5"},
                  new Model(){BrandId=audi.Id,Name="Q7"},
                  new Model(){BrandId=audi.Id,Name="Q8"},
                  new Model(){BrandId=audi.Id,Name="RS4"},
                  new Model(){BrandId=audi.Id,Name="RS7"},
                  new Model(){BrandId=audi.Id,Name="S5"},
                  new Model(){BrandId=audi.Id,Name="S8"},
                  new Model(){BrandId=audi.Id,Name="TT"},

                new Model(){BrandId=dodge.Id,Name="Caliber"},
                  new Model(){BrandId=dodge.Id,Name="Challenger"},
                  new Model(){BrandId=dodge.Id,Name="Charger"},
                  new Model(){BrandId=dodge.Id,Name="Durango"},
                  new Model(){BrandId=dodge.Id,Name="Intrepid"},
                  new Model(){BrandId=dodge.Id,Name="Journey"},
                  new Model(){BrandId=dodge.Id,Name="Ram"},
                  new Model(){BrandId=dodge.Id,Name="Stratus"},

                new Model(){BrandId=chevrolet.Id,Name="Aveo"},
                  new Model(){BrandId=chevrolet.Id,Name="Camaro"},
                  new Model(){BrandId=chevrolet.Id,Name="Cobalt"},
                  new Model(){BrandId=chevrolet.Id,Name="Cruze"},
                  new Model(){BrandId=chevrolet.Id,Name="Lacetti"},
                  new Model(){BrandId=chevrolet.Id,Name="Nexia"},
                  new Model(){BrandId=chevrolet.Id,Name="Spark"},
                  new Model(){BrandId=chevrolet.Id,Name="Stratus"},

                new Model(){BrandId=jeep.Id,Name="Cherokee"},
                  new Model(){BrandId=jeep.Id,Name="Compass"},
                  new Model(){BrandId=jeep.Id,Name="Grand Cherokee"},
                  new Model(){BrandId=jeep.Id,Name="Liberty"},
                  new Model(){BrandId=jeep.Id,Name="Patriot"},
                  new Model(){BrandId=jeep.Id,Name="Wrangler"},

                new Model(){BrandId=infiniti.Id,Name="EX Series"},
                   new Model(){BrandId=infiniti.Id,Name="FX Series"},
                   new Model(){BrandId=infiniti.Id,Name="G Series"},
                   new Model(){BrandId=infiniti.Id,Name="JX Series"},
                   new Model(){BrandId=infiniti.Id,Name="Q Series"},
                   new Model(){BrandId=infiniti.Id,Name="QX Series"},

                new Model(){BrandId=lamburgumbur.Id,Name="Huracan"},
                   new Model(){BrandId=lamburgumbur.Id,Name="Aventador"},
                   new Model(){BrandId=lamburgumbur.Id,Name="Gallardo"},
                   new Model(){BrandId=lamburgumbur.Id,Name="Urus"},

                new Model(){BrandId=tesla.Id,Name="Model 3"},
                   new Model(){BrandId=tesla.Id,Name="Model S"},
                   new Model(){BrandId=tesla.Id,Name="Model X"},
                   new Model(){BrandId=tesla.Id,Name="Model Y"},

                new Model(){BrandId=vw.Id,Name="Golf"},
                   new Model(){BrandId=vw.Id,Name="Jetta"},
                   new Model(){BrandId=vw.Id,Name="Possat"},
                   new Model(){BrandId=vw.Id,Name="Polo"},
                   new Model(){BrandId=vw.Id,Name="Tiguan"},
                   new Model(){BrandId=vw.Id,Name="Transporter"},
                   new Model(){BrandId=vw.Id,Name="Touareg"},

                new Model(){BrandId=kia.Id,Name="Ssn"},
                   new Model(){BrandId=kia.Id,Name="Carnival"},
                   new Model(){BrandId=kia.Id,Name="K3"},
                   new Model(){BrandId=kia.Id,Name="K4"},
                   new Model(){BrandId=kia.Id,Name="K5"},
                   new Model(){BrandId=kia.Id,Name="K8"},
                   new Model(){BrandId=kia.Id,Name="Optima"},

                new Model(){BrandId=hundai.Id,Name="Sonata"},
                   new Model(){BrandId=hundai.Id,Name="Santafe"},

                new Model(){BrandId=nissan.Id,Name="Juke"},
                   new Model(){BrandId=nissan.Id,Name="X-Trail"},
            });

            dbContext.SaveChanges();

        }
    }
}