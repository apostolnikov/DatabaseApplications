namespace _04.ImportUsersAndGamesfromXml
{
    using System;
    using System.Xml;
    using _01.DatabaseFirst;

    class ImportUsersAndGamesfromXml
    {
        static void Main(string[] args)
        {
            var context = new DiabloEntities();
            XmlDocument doc = new XmlDocument();
            doc.Load("../../users-and-games.xml");

            var root = doc.DocumentElement;

            foreach (XmlNode xmlUsersGames in root.ChildNodes)
            {
                Console.WriteLine(xmlUsersGames);
            }
        }
    }
}
