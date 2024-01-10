using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public class StandardFrogService
    {
       public List<StandardFrog> listOfStandardFrogs {get;set;}

       public StandardFrogService()
        {
            listOfStandardFrogs=new List<StandardFrog>();

            listOfStandardFrogs.Add(new StandardFrog() { Id = 1, Name = "Frog", Note = "Regular, green frog." });
            listOfStandardFrogs.Add(new StandardFrog() { Id = 2, Name = "Frogy", Note = "Cool, chill, frogy." });
            listOfStandardFrogs.Add(new StandardFrog() { Id = 3, Name = "Toad", Note = "Enormous, slimy frog, simply the toad." });
            listOfStandardFrogs.Add(new StandardFrog() { Id = 4, Name = "Ninja", Note = "If you don't like frogs..." });
        }

        public void ShowListOfStandardFrogs()
        {
            for(int i=0;i<listOfStandardFrogs.Count;i++)
            {
              Console.WriteLine($"{listOfStandardFrogs[i].Id}.{listOfStandardFrogs[i].Name} ---> {listOfStandardFrogs[i].Note}");
            }
        }
        public int StandardFrogSelection()
        {
            var standardFrogSelectionId = Console.ReadKey();
            int id;
            Int32.TryParse(standardFrogSelectionId.KeyChar.ToString(), out id);

            return id;
        }
        
        public void StandardFrogChoice(int standardFrogSelectionId)
        {
            StandardFrog chosenFrog = new StandardFrog();
                foreach (var standardFrog in  listOfStandardFrogs)
            {
                if (standardFrog.Id == standardFrogSelectionId)
                {
                    chosenFrog = standardFrog;
                    break;
                }
            }
            Console.WriteLine($"");
            Console.WriteLine($"Your choice: {chosenFrog.Id}. {chosenFrog.Name}");
        }
 
    }
}
