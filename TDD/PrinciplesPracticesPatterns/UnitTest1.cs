using Microsoft.AspNetCore.Mvc;
using Moq;
using PrinciplesPracticesPatterns.Speaker;

namespace PrinciplesPracticesPatterns;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //Arrange

        var speakers = new List<string> { "bb" };

        var spearkerServiceMock = new Mock<ISpeakerService>();
        var controller = new SpeakerController(spearkerServiceMock.Object);
        spearkerServiceMock.Setup(i => i.GetALl()).Returns(speakers);


        // Act

        var result = controller.GetALl();
        var _speakers = result.ToList();


        // Assert

        //spearkerServiceMock.Verify(mock => mock.GetALl(), Times.Once());
        Assert.Equal(_speakers, speakers);
    }
}