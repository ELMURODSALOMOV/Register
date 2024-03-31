using Register.Service;

IUserService userService = new UserService();
var user = userService.GetUser("Elmurod", "Password");
Console.WriteLine($"{user.Name}. {user.Password}");