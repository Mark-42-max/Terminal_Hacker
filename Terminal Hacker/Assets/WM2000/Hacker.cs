using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game config data
    readonly string[] lev1p = { "mono", "donkey", "leisure", "stop", "awesome" };
    readonly string[] lev2p = { "mayan", "maybelline", "theism", "ecstasy", "condolences" };
    readonly string[] lev3p = { "ironic", "irregardless", "combobulation", "colonel", "enormity" };
    //Game state
    int level;
    string password;
    enum Screen { MainMenu, Password, Win, Lost};
    Screen currentScreen;
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("User");
    }


    private void ShowMainMenu(string greetings)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello" + greetings);
        Terminal.WriteLine("What would you like to hack into");
        Terminal.WriteLine("Press 1 for Local Library");
        Terminal.WriteLine("Press 2 for Police Station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("\n");
        Terminal.WriteLine("Enter your choice:");
    }
    //to decide what to do with user input,not to do the job itself
    void OnUserInput(string input)
    {
        if (input == "menu")//we go directly to main menu
        {
            currentScreen = Screen.MainMenu;
            ShowMainMenu("User");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            RunGame(input);
        }
    }

    private void RunGame(string input)
    {
        if (level == 1)
        {
            CheckPassword(input);
        }
        else if (level == 2)
        {
            CheckPassword(input);
        }
        else if (level == 3)
        {
            CheckPassword(input);
        }
    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            StartGame();
            Terminal.WriteLine("Type menu to return to main menu \n or try again");
        }
    }

    void DisplayWinScreen()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("YOU WIN!!");
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Choose a book you want");
                Terminal.WriteLine(@"
                  ______________
                 /              //
                /              //
               /              //
              /              //
             /_____________ //
            (______________(/
");
                break;
            case 2:
                Terminal.WriteLine("Hers's your prison key");
                Terminal.WriteLine(@"
         _____ 
        /  0  \
       / 0   0 \__________________
       \   0   /        !!!!!!!!!
        \_____/         !!!!  !!!
");
                break;
            case 3:
                Terminal.WriteLine("Welcome to NASA's internal server");
                Terminal.WriteLine(@"
    
     | \ | |   /\    / ____|  /\    
     |  \| |  /  \  | (___   /  \   
     | . ` | / /\ \  \___ \ / /\ \  
     | |\  |/ ____ \ ____) / ____ \ 
     |_| \_/_/    \_\_____/_/    \_\
");
                break;
        }
        Terminal.WriteLine("Type menu to return to main menu ");

    }

    private void RunMainMenu(string input)
    {
        bool isValidlevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidlevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            EasterEggError(input);
        }
    }

    void EasterEggError(string input)
    {
        if (input == "007")
        {
            Terminal.WriteLine("Welcome Mr. Bond!! Select level");
            return;
        }
        else if (input == "047")
        {
            Terminal.WriteLine("Welcome Mr. Hitman!! Select level");
            return;
        }
        else
        {
            Terminal.WriteLine("Please enter a valid input");
        }
    }

    private void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();

        SetRandomPassword();
        Terminal.WriteLine("You chose level " + level);
        Terminal.WriteLine("Enter Password:" + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = lev1p[Random.Range(0, lev1p.Length)];
                break;
            case 2:
                password = lev2p[Random.Range(0, lev2p.Length)];
                break;
            case 3:
                password = lev3p[Random.Range(0, lev3p.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }
}
