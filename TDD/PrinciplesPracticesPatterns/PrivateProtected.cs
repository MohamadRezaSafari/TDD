
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PrinciplesPracticesPatterns")]
namespace PrinciplesPracticesPatterns;

public class PrivateProtected : Cls
{
    [Fact]
    public void MyPrivateTest()
    {
        Type type = typeof(Cls);
        var cls = Activator.CreateInstance(type);
        MethodInfo method = type.GetMethod("Print2", BindingFlags.NonPublic | BindingFlags.Instance);

        object[] parameters = { "101112"  };

        method.Invoke(cls, parameters);
    }

    [Fact]
    public void MyProtectedTest()
    {
        Print("a");
    }
}



public class Cls
{
    protected void Print(string txt)
    {
        Console.WriteLine(txt);
    }

    private void Print2(string number)
    {
        Console.WriteLine(number);
    }
}