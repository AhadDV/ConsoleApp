
using static DelegateMethods;

public class Company
{
    public string Name { get; set; }

    List<User> Users { get; set; }
    public Company(string name)
    {
        Users = new List<User>();
        Name = name;
    }

    public string Register(string name, string surname, string password)
    {
        UsernameCheckDelegate usernameCheckDelegate = new UsernameCheckDelegate(UsernameCreate);
        string username = usernameCheckDelegate.Invoke(name, surname);
        usernameCheckDelegate += CrateEmail;
        string email = usernameCheckDelegate.Invoke(name, surname);
        User result = Users.FirstOrDefault(x => x.Username == username);
        if (result != null)
            return "User alrady exsist";


        User user = new User(name, surname, username, email, password);
        Users.Add(user);
        return $"{user.Id} ";



    }
    public bool Login(string username, string password)
    {
        return Users.Exists(x => x.Username == username && x.Password == password);
    }
    public List<User> GetAll(Predicate<User> filter = null)
    {
        if (filter != null)
            return Users.Where(x => filter(x)).ToList();
        else
            return Users;
    }

    public User GetUser(int id)
    {
        return Users.FirstOrDefault(x => x.Id == id);
    }

}

