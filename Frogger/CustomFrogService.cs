using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public class CustomFrogService
    {
        public List<CustomFrog> listOfCustomFrogs { get; set; }

        public CustomFrogService()
        {
            listOfCustomFrogs = new List<CustomFrog>();

        }

        public int AddNewCustomFrog()
        {
            CustomFrog customFrog = new CustomFrog();

            customFrog.Id = listOfCustomFrogs.Count + 1;
            int id = customFrog.Id;

            Console.WriteLine("Please, enter name for your new Frog");
            var name = Console.ReadLine();
            customFrog.Name = name;

            Console.WriteLine("Please, enter short note for your new Frog");
            var note = Console.ReadLine();
            customFrog.Note = note;

            listOfCustomFrogs.Add(customFrog);

            return id;
        }
        public void ShowListOfCustomFrogs()
        {
            for (int i = 0; i < listOfCustomFrogs.Count; i++)
            {
                Console.WriteLine($"{listOfCustomFrogs[i].Id}.{listOfCustomFrogs[i].Name} ---> {listOfCustomFrogs[i].Note}");
            }
        }
        public int CustomFrogSelection()
        {
            var customFrogSelectionId = Console.ReadKey();
            int id;
            Int32.TryParse(customFrogSelectionId.KeyChar.ToString(), out id);

            return id;
        }
        public void CustomFrogChoice(int customFrogSelectionId)
        {
            CustomFrog chosenFrog = new CustomFrog();
            foreach (var customFrog in listOfCustomFrogs)
            {
                if (customFrog.Id == customFrogSelectionId)
                {
                    chosenFrog = customFrog;
                    break;
                }
            }
            Console.WriteLine($"");
            Console.WriteLine($"Your choice: {chosenFrog.Id}. {chosenFrog.Name}");
        }

        public void ForgetAllCustomFrogs()
        {
            CustomFrog noneFrog = new CustomFrog();

        }

    }
}
