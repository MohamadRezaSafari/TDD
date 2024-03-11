using Moq;

namespace PrinciplesPracticesPatterns;

public class Mock
{
    [Fact]
    public void Ping_Invokes_DoSomething()
    {
        // Arrange

        var mockIFoo = new Mock<IFoo>();
        mockIFoo.Setup(i => i.DoSomething(It.IsAny<string>())).Returns(true);
        var service = new Service(mockIFoo.Object);

        // Act

        service.Ping();


        // Assert

        mockIFoo.Verify(i => i.DoSomething("PING"), Times.Once());
    }
}




public class Service
{
    private readonly IFoo _foo;

    public Service(IFoo foo)
    {
        _foo = foo ?? throw new ArgumentNullException(nameof(foo));
    }

    public void Ping()
    {
        _foo.DoSomething("PING");
    }
}

public interface IFoo
{
    bool DoSomething(string command);
}