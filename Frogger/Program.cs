using System;

namespace Frogger
{
    class Program
    {
        static void Main(string[] args)
        {
            //WELCOME TO THE FROGGER
            //CHOOSE THE ACTION
            //
            ////1.START GAME
            ////2.OPTIONS
            ////3.HIGH SCORES
            ////4.EXIT
            //
            //////1.1.QUICK START
            //////1.2.CHOOSE YOUR FROG
            //////1.2.1.STANDARD FROGS -> SHOW THE LIST OF FROGS
            //////1.2.2.CUSTOM FROGS -> SHOW THE LIST OF FROGS
            //////1.2.2.1.ADD NEW FROG
            //////1.2.2.2.FORGET THE FROG
            //////1.2.2.3.BACK
            //
            //////2.1.FROG LIFES -> TO CHOOSE 1-5
            //////2.2.GAME TIME -> TO CHOOSE 30s/20s

            //
            //////3.1.SHOW THE LIST
            //////3.2.CLEAR ALL
            //////3.3.BACK

            MenuActionService actionService = new MenuActionService();
            actionService = Initialize(actionService);

            CustomFrogService customService = new CustomFrogService();

            Console.WriteLine("Welcome to the Frogger game!");
            Console.WriteLine("");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Choose:");

                var mainMenu = actionService.GetMenuActionsByMenuName("Main"); 
                for(int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}.{mainMenu[i].Name}");
                }

                var operation = Console.ReadKey();
                Console.WriteLine("");
                Console.WriteLine("");

                switch (operation.KeyChar)//main menu
                {
                    case '1'://game menu
                        var gameMenu = actionService.GetMenuActionsByMenuName("GameMenu");
                        for (int i = 0; i < gameMenu.Count; i++)
                        {
                            Console.WriteLine($"{gameMenu[i].Id}.{gameMenu[i].Name}");
                        }

                        var gameMenuOperation = Console.ReadKey();
                        Console.WriteLine("");
                        Console.WriteLine("");

                        switch (gameMenuOperation.KeyChar)
                        {
                            case '1':
                                RunTheGame();
                                break;

                            case '2':
                                var frogMenu = actionService.GetMenuActionsByMenuName("FrogMenu");
                                for (int i = 0; i < frogMenu.Count; i++)
                                {
                                    Console.WriteLine($"{frogMenu[i].Id}.{frogMenu[i].Name}");
                                }

                                var frogMenuOperation = Console.ReadKey();
                                Console.WriteLine("");
                                Console.WriteLine("");

                                switch(frogMenuOperation.KeyChar)
                                {
                                    case '1':
                                        Console.WriteLine("Which frog would you like to play?");

                                        StandardFrogService frogService = new StandardFrogService();
                                        frogService.ShowListOfStandardFrogs();

                                       var standardFrogSelectionId = frogService.StandardFrogSelection();
                                        frogService.StandardFrogChoice(standardFrogSelectionId);

                                        break;

                                    case '2':
                                        var customFrogMenu = actionService.GetMenuActionsByMenuName("CustomFrogMenu");
                                        for (int i = 0; i < customFrogMenu.Count; i++)
                                        {
                                            Console.WriteLine($"{customFrogMenu[i].Id}.{customFrogMenu[i].Name}");
                                        }

                                        var customFrogMenuOperation = Console.ReadKey();
                                        Console.WriteLine("");
                                        Console.WriteLine("");

                                        switch (customFrogMenuOperation.KeyChar)
                                        {
                                            case '1':
                                                
                                                if (customService.listOfCustomFrogs.Count == 0)
                                                {
                                                    Console.WriteLine("First you have to add the Frog");

                                                    var id= customService.AddNewCustomFrog();

                                                    Console.WriteLine($"You,ve added Frog:  {customService.listOfCustomFrogs[id-1].Id}.{customService.listOfCustomFrogs[id-1].Name} ---> {customService.listOfCustomFrogs[id-1].Note}");
                                                }
                                                else
                                                {
                                                    customService.ShowListOfCustomFrogs();

                                                    var customFrogSelectionId = customService.CustomFrogSelection();
                                                    customService.CustomFrogChoice(customFrogSelectionId);
                                                }

                                                break;

                                            case '2':

                                                var addId = customService.AddNewCustomFrog();

                                                    Console.WriteLine($"You,ve added Frog:  {customService.listOfCustomFrogs[addId - 1].Id}.{customService.listOfCustomFrogs[addId - 1].Name} ---> {customService.listOfCustomFrogs[addId - 1].Note}");

                                                break;

                                            case '3':

                                                Console.WriteLine("You will clear all frogs, are you sure?");
                                                Console.WriteLine("Press y for yes, n for no");

                                                var clearCommand=Console.ReadKey();
                                                if(clearCommand.KeyChar == 'y')
                                                {
                                                    customService.listOfCustomFrogs.Clear();
                                                }
                                                Console.WriteLine("");

                                                break;

                                            default:
                                                Console.WriteLine("Wrong action. Try again.");
                                                Console.WriteLine("");
                                                break;
                                        }

                                                break;
                                    default:
                                        Console.WriteLine("Wrong action. Try again.");
                                        Console.WriteLine("");
                                        break;
                                }

                                break;

                            default:
                                Console.WriteLine("Wrong action. Try again.");
                                Console.WriteLine("");
                                break;
                        }

                        break;
                    case '2'://option menu
                        var optionsMenu = actionService.GetMenuActionsByMenuName("OptionsMenu");
                        for (int i = 0; i < optionsMenu.Count; i++)
                        {
                            Console.WriteLine($"{optionsMenu[i].Id}.{optionsMenu[i].Name}");
                        }

                        var optionsMenuOperation = Console.ReadKey();
                        Console.WriteLine("");
                        Console.WriteLine("");

                        switch(optionsMenuOperation.KeyChar)
                        {
                            case '1':
                                Console.WriteLine("How many lifes would you like to have?");
                                for(int i = 1; i < 6; i++)
                                {
                                    Console.WriteLine(i);
                                    Console.WriteLine("");
                                }
                                var frogLifeChoice = Console.ReadKey();
                                int frogLifeChosen;
                                Int32.TryParse(frogLifeChoice.KeyChar.ToString(), out frogLifeChosen);
                                if (frogLifeChosen > 0 && frogLifeChosen < 6)
                                {
                                    int frogLife = frogLifeChosen;
                                    Console.WriteLine($"Frog lifes: {frogLife}");
                                    Console.WriteLine("");
                                }
                                else
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Wrong number.");
                                }
                                break;
                              
                            case '2':
                                Console.WriteLine("Choose time for one race.");
                                int[] gameTime= new int[2] { 20, 30};

                                Console.WriteLine($"Game time: {gameTime[0]} or {gameTime[1]}");
                                var gameTimeChoice = Console.ReadLine();
                                int gameTimeChosen;
                                Int32.TryParse(gameTimeChoice.ToString(), out gameTimeChosen);

                                switch (gameTimeChosen)
                                {
                                    case 20 or 30:
                                        Console.WriteLine($"Game time: {gameTimeChosen}");
                                        break;
                                    default:
                                        Console.WriteLine("Wrong time.");
                                        break;
                                }
                             
                                Console.WriteLine("");
                                break;

                            default:
                                Console.WriteLine("Wrong action. Try again.");
                                Console.WriteLine("");
                                break;
                        }

                        break;
                    case '3'://high score menu - to do
                        Console.WriteLine("Doesn't work yet.");
                        Console.WriteLine("");
                        break;
                    case '4': exit = true;
                        break;
                    default: Console.WriteLine("Wrong action. Try again.");
                        Console.WriteLine("");
                        break;
                }

            }

        }
        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Start Game", "Main");
            actionService.AddNewAction(2, "Options", "Main");
            actionService.AddNewAction(3, "High Scores", "Main");
            actionService.AddNewAction(4, "Exit", "Main");

            actionService.AddNewAction(1, "Quick Start", "GameMenu");
            actionService.AddNewAction(2, "Choose Your Frog", "GameMenu");

            actionService.AddNewAction(1, "Standard Frog", "FrogMenu");
            actionService.AddNewAction(2, "Custom Frog", "FrogMenu");

            actionService.AddNewAction(1, "Choose Frog", "CustomFrogMenu");
            actionService.AddNewAction(2, "Add Frog", "CustomFrogMenu");
            actionService.AddNewAction(3, "Forget Frog", "CustomFrogMenu");

            actionService.AddNewAction(1, "Frog Lifes", "OptionsMenu");
            actionService.AddNewAction(2, "Game Time", "OptionsMenu");


            //actionService.AddNewAction(1, "Show The List", "ScoresMenu");
            //actionService.AddNewAction(2, "Clear All", "ScoresMenu");
            //actionService.AddNewAction(3, "Back", "ScoresMenu");

            return actionService;
        }
        public static void RunTheGame()
        {
            Console.Clear();
            Console.WriteLine("START");
            Console.WriteLine("");

        }
    }
}