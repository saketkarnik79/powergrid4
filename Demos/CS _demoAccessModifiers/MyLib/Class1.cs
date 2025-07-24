namespace MyLib
{
    public class BaseClass
    {
        internal string internalField = "This is an internal field";
        protected internal string protectedInternalField = "This is a protected internal field";
        private protected string privateProtectedField = "This is a private protected field";

        public void ShowAcccess()
        {
            Console.WriteLine(internalField);
            Console.WriteLine(protectedInternalField);
            Console.WriteLine(privateProtectedField);
        }
    }
    public class DerivedClass : BaseClass
    {
        public void ShowDerivedAccess()
        {
            Console.WriteLine(internalField); // Accessible
            Console.WriteLine(protectedInternalField); // Accessible
            Console.WriteLine(privateProtectedField); // Accessible
        }
    }
    public class AnotherClass
    {
        public void ShowAnotherAccess(BaseClass baseClass)
        {
            Console.WriteLine(baseClass.internalField); // Accessible
            Console.WriteLine(baseClass.protectedInternalField); // Accessible
            //Console.WriteLine(baseClass.privateProtectedField); // Not accessible, will cause a compile error
        }
    }
}
