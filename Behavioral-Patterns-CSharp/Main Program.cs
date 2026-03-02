using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        RemoteControl remote = new RemoteControl();
        Light light = new Light();
        remote.ExecuteCommand(new LightOnCommand(light));
        remote.Undo();

        Beverage tea = new Tea();
        tea.PrepareRecipe();

        ChatRoom chat = new ChatRoom();
        User u1 = new ChatUser(chat, "User1");
        User u2 = new ChatUser(chat, "User2");
        chat.AddUser(u1);
        chat.AddUser(u2);
        u1.Send("Hello!");

        Console.ReadKey();
    }
}