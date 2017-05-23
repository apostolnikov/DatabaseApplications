using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.DatabaseFirst;
using System.Xml.Linq;

namespace _03.ExportPhotographsXml
{
    class ExportPhotographsXml
    {
        static void Main()
        {
            var context = new PhotographySystemEntities();

            var photographs = context.Photographs
                .OrderBy(x => x.Title)
                .Select(x => new
                {
                    PhotographTitle = x.Title,
                    PhotographLink = x.Link,
                    Category = x.Category.Name,
                    Equipment = new
                    {
                        Camera = new
                        {
                            Name = x.Equipment.Camera.Manufacturer.Name + " " + x.Equipment.Camera.Model,
                            Megapixels = x.Equipment.Camera.Megapixels
                        },
                        Lens = new
                        {
                            Name = x.Equipment.Lens.Manufacturer.Name + " " + x.Equipment.Lens.Model,
                            Price = x.Equipment.Lens.Price
                        }
                    },

                }).ToList();

            XElement photos = new XElement("photographs");

            foreach (var photo in photographs)
            {
                var photograph = new XElement("photograph", new XAttribute("title", photo.PhotographTitle));
                photograph.Add(new XElement("category", photo.Category));
                photograph.Add(new XElement("link", photo.PhotographLink));

                var equipment = new XElement("equipment");

                equipment.Add(new XElement("camera", new XAttribute("megapixels", photo.Equipment.Camera.Megapixels), photo.Equipment.Camera.Name));

                var lens = new XElement("lens", photo.Equipment.Lens.Name);
                if (photo.Equipment.Lens.Price != null)
                {
                    lens.Add(new XAttribute("price", photo.Equipment.Lens.Price));
                }

                equipment.Add(lens);
                photograph.Add(equipment);
                photos.Add(photograph);
            }

            //Console.WriteLine(photos);
            photos.Save("../../photographs.xml");
        }
    }
}
