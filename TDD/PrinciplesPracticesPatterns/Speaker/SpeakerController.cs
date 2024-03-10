namespace PrinciplesPracticesPatterns.Speaker;

public class SpeakerController
{
    private readonly ISpeakerService speakerService;

    public SpeakerController(ISpeakerService speakerService)
    {
        this.speakerService = speakerService;
    }

    public List<string> GetALl()
    {
        return new List<string>() { "a" };
    }
}
