using System;
using Register.Broker.Storeage;
using Register.Models;
using Register.Service;

IUserService userService = new UserService();
bool isContinue = true;
do
{
    Console.WriteLine("1. Sign up user");
    Console.WriteLine("2. Log In user");
    Console.Write("Enter command ");
    string command = Console.ReadLine();
    if(command.Contains("1") is true)
    {
        Users users = new Users();
        Console.WriteLine("Enter your Email ");
        users.Email = Console.ReadLine();
        Console.WriteLine("Enter the user password ");
        users.Password = Console.ReadLine();
        userService.SignUp(users);
    }
    if(command.Contains("2") is true)
    {
        Users users1 = new Users();
        Console.WriteLine("Enter your Email ");
        users1.Email = Console.ReadLine();
        Console.WriteLine("Enter the user password ");
        users1.Password = Console.ReadLine();
        userService.LogIn(users1);
    }
    Console.Write("Is Continue ");
    string isCommand = Console.ReadLine();
    if(isCommand.ToLower().Contains("no") is true)
    {
        isContinue = false;
    }
} while (isContinue is true);