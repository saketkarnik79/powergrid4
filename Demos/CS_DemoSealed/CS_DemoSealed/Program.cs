namespace CS_DemoSealed
{
    sealed class SealedClass
    {
        public void Display()
        {
            Console.WriteLine("This is a method in a sealed class.");
        }
    }
    //class NonSealedClass: SealedClass
    //{
        
    //}
    class BaseClass
    {
        public virtual void Show()
        {
            Console.WriteLine("BaseClass.Show()");
        }
        public virtual string Message
        {
            //get { return "BaseClass Message"; }
            get => "BaseClass Message";
        }
    }

    class DerivedClass : BaseClass
    {
        public sealed override void Show()
        {
            Console.WriteLine("DerivedClass.Show()");
        }
        public sealed override string Message
        {
            get => "DerivedClass Message";
        }
    }
    //class DerivedClass2 : DerivedClass
    //{
    //    public override void Show()
    //    {
    //        Console.WriteLine("DerivedClass2.Show()");
    //    }
    //    public override string Message
    //    {
    //        get => "DerivedClass2 Message";
    //    }
    //}
    internal class Program
    {
        static void Main(string[] args)
        {
            SealedClass sealedObj = new SealedClass();
            sealedObj.Display();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
