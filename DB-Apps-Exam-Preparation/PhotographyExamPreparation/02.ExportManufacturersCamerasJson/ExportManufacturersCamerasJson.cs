namespace _02.ExportManufacturersCamerasJson
{
    using System;
    using System.IO;
    using System.Linq;
    using _01.DatabaseFirst;
    using System.Web.Script.Serialization;

    class ExportManufacturersCamerasJson
    {
        static void Main()
        {
            var context = new PhotographySystemEntities();

            var manufactureresAndCameras = context.Manufacturers
                .OrderBy(m => m.Name)
                .Select(m => new
                {
                    manufacturer = m.Name,
                    cameras = m.Cameras
                        .OrderBy(c => c.Model)
                        .Select(c => new
                        {
                            model = c.Model,
                            price = c.Price
                        })
                }).ToList();
            
            var json = new JavaScriptSerializer().Serialize(manufactureresAndCameras);
            //Console.WriteLine(json);
            File.WriteAllText("../../manufactureres-and-cameras.json", json);
        }
    }


}
