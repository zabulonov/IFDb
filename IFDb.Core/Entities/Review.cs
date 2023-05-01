namespace Core;

public class Review
{
    public long Id { get; private set; }
    
    public User Creator { get; private set; }
    
    public int Grade { get; private set; }
    
    public string Text { get; private set; }
}