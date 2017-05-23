namespace _01.DatabaseFirst
{
    using System;
    using System.Linq;

    class DatabaseFirst
    {
        static void Main()
        {
            var context = new PhotographySystemEntities();
            var listManufacteursModels = context.Cameras.Select(x => x.Manufacturer.Name + " " + x.Model).OrderBy(x => x).ToList();

            foreach (var listManufacteursModel in listManufacteursModels)
            {
                Console.WriteLine(listManufacteursModel);
            }

        }
    }
}
