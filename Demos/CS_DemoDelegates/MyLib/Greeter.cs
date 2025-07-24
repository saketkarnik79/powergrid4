namespace MyLib
{
    public delegate void GreetHandler(string name);

    public class Greeter
    {
        public void Greet(string name, GreetHandler handler)
        {
            handler?.Invoke(name);
        }

        public void SendOff(string name, GreetHandler handler)
        {
            handler?.Invoke(name);
        }
    }
}
