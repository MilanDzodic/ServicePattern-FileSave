using ServicePattern.Factories;
using ServicePattern.Interfaces;
using ServicePattern.Models;

namespace ServicePattern.Services;

public class MenuServices : IMenuServices
{
  private static readonly UserServices _userServices = new();

  public void Show()
  {
    while (true)
    {
      MainMenu();
    }
  }


  public void MainMenu()
  {
    Console.Clear();
    Console.WriteLine($"{"1.",-5} Create user");
    Console.WriteLine($"{"2.",-5} Show users");
    Console.WriteLine($"{"Q.",-5} Quit");
    Console.WriteLine("---------------------------");
    Console.Write("Choose your menu option: ");

    var option = Console.ReadLine()!;

    switch (option.ToLower())
    {
      case "1":
        CreateOption();
        break;

      case "2":
        ShowOption();
        break;

      case "q":
        QuitOption();
        break;

      default:
        InvalidOption();
        break;
    }
  }

  public void CreateOption()
  {
    UserRegistrationForm userRegistrationForm = UserFactory.Create();

    Console.Clear();

    Console.Write("Enter your first name: ");
    userRegistrationForm.FirstName = Console.ReadLine()!;

    Console.Write("Enter your last name: ");
    userRegistrationForm.LastName = Console.ReadLine()!;

    Console.Write("Enter your email: ");
    userRegistrationForm.Email = Console.ReadLine()!;

    Console.Write("Enter your password: ");
    userRegistrationForm.Password = Console.ReadLine()!;

    bool result = _userServices.Create(userRegistrationForm);

    if (result)
      OutputDialog("User was successfully created.");
    else
      OutputDialog("User was not successfully created.");

    Console.ReadKey();
  }

  public void ShowOption()
  {
    var users = _userServices.GetAll();

    Console.Clear();

    foreach (var user in users)
    {
      Console.WriteLine($"{"Id:", -10}{user.Id}");
      Console.WriteLine($"{"Name:",-10}{user.FirstName} {user.LastName}");
      Console.WriteLine($"{"Email:",-10}{user.Email}");
      Console.WriteLine("");
    }

    Console.ReadKey();
  }

  public void QuitOption()
  {
    Console.Clear();
    Console.WriteLine("Press y/n to quit application");

    var option = Console.ReadLine()!;

    if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
    {
      Environment.Exit(0);
    }
    else if (option.Equals("n", StringComparison.CurrentCultureIgnoreCase))
    {
      Console.Clear();
    }
  }

  public void InvalidOption()
  {
    OutputDialog("You must enter a valid option!");
  }

  public void OutputDialog(string message)
  {
    Console.Clear();
    Console.WriteLine(message);
    Console.ReadKey();
  }

}