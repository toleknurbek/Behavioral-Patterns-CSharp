public interface IMediator {
    void Send(string msg, User user);
    void AddUser(User user);
}

public class ChatRoom : IMediator {
    private List<User> _users = new List<User>();
    public void AddUser(User user) => _users.Add(user);
    public void Send(string msg, User sender) {
        foreach (var u in _users) {
            if (u != sender) u.Receive(msg, sender.Name);
        }
    }
}

public abstract class User {
    protected IMediator mediator;
    public string Name { get; }
    public User(IMediator m, string n) { mediator = m; Name = n; }
    public abstract void Send(string msg);
    public abstract void Receive(string msg, string from);
}

public class ChatUser : User {
    public ChatUser(IMediator m, string n) : base(m, n) { }
    public override void Send(string msg) => mediator.Send(msg, this);
    public override void Receive(string msg, string from) => 
        Console.WriteLine($"{Name} received from {from}: {msg}");
}