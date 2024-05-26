namespace LibruaryManagementSys;

public class User
{
    private int _userId;
    private string _name;
    private string _email;
    private string _contact;
    
    public User(int userId, string name, string email, string contact)
    {
        this._userId = userId;
        this._name = name;
        this._email = email;
        this._contact = contact;
    }
    
    public int UserId
    {
        get => _userId;
        set => _userId = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Email
    {
        get => _email;
        set => _email = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Contact
    {
        get => _contact;
        set => _contact = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public override string ToString()
    {
        return$"User Id : {UserId}\n" +
              $"Name : {Name}\n" +
              $"Email : {Email}\n" +
              $"Contact : {Contact}\n";
    }
}