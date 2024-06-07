using Mail.API.Models;

namespace Mail.API.UseCase;

public interface ISendMail
{
    void Execute(Message message);
}