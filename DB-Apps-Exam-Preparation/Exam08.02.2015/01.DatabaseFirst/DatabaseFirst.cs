namespace _01.DatabaseFirst
{
    using System;
    using System.Linq;

    class DatabaseFirst
    {
        static void Main()
        {
            var context = new DiabloEntities();

            var allCharacterNames = context.Characters.Select(ch => ch.Name);
            foreach (var name in allCharacterNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
