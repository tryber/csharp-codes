namespace Condo.DTOs;
public class MailMessage
{
    public string? Title { get; set; }
    public string? Text { get; set; }
    public string? MailTo { get; set; }

    public MailMessage(string Title, string Text, string MailTo)
    {
        this.Title = Title;
        this.Text = Text;
        this.MailTo = MailTo;
    }
}