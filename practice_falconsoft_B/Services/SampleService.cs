using practice_falconsoft_B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_falconsoft_B.Services
{
    public class SampleService : ISampleService
    {
        public SampleService()
        {
            listaUno = new List<Sample>();
            listaDos = new List<Sample>();


            Random myObject = new Random();
            int ranNum = myObject.Next(100, 500000);
            int cantidadRegistros = 500000;

            
            for (int i = 0; i < cantidadRegistros; i++)
            {
                string guid = "";

                if (i == ranNum)
                {
                    guid = Guid.NewGuid().ToString();
                }                

                listaUno.Add(
                    new Sample
                    {
                        Id = String.IsNullOrEmpty(guid) ? Guid.NewGuid().ToString() : guid,
                        Content = "",
                        Qty = 1
                    }
                    );

                listaDos.Add(
                    new Sample
                    {
                        Id = String.IsNullOrEmpty(guid) ? Guid.NewGuid().ToString() : guid,
                        Content = "",
                        Qty = 2
                    }
                    );
            }
        }

        public List<Sample> listaUno { get; set; }
        public List<Sample> listaDos { get; set; }

        public List<Sample> ObtenerListaAmbasListas()
        {
            List<Sample> listaElementosEnAmbas = new List<Sample>();


            //var query = (from uno in listaUno
            //                join dos in listaDos on uno.Id equals dos.Id
            //                select new Sample { Id = uno.Id, Content = uno.Content, Qty = uno.Qty  });

            //listaUno.Select(l => new Sample
            //{
            //    Id = uno.Id,
            //    Content = uno.Content,
            //    Qty = uno.Qty,
            //    selected = listaDos.Any(ml => ml == l.id)
            //})

            listaElementosEnAmbas = (from uno in listaUno
                         join dos in listaDos
                            on uno.Id equals dos.Id
                         select new Sample
                         {
                             Id = uno.Id,
                             Content = uno.Content,
                             Qty = uno.Qty
                             //address = loc.address,
                             //selected = myloc.Any()
                         }).ToList();



            return listaElementosEnAmbas;
        }

    }
}
