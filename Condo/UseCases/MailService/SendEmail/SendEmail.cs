using Condo.DTOs;
using Condo.Exceptions;
using Condo.UseCases.Interfaces;
using Newtonsoft.Json;

namespace Condo.UseCases.MailService.SendEmail;

public class SendEmail : ISendEmail
{
    private readonly HttpClient _client;
    public SendEmail(HttpClient client)
    {
        _client = client;
    }
    public async void Execute(MailMessage mailMessage)
    {
        var url = Environment.GetEnvironmentVariable("CONDO_EMAIL_SERVICE_URL");
        var jsonContent = new StringContent(JsonConvert.SerializeObject(mailMessage),System.Text.Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(url, jsonContent);
        if (!response.IsSuccessStatusCode) throw new BadRequestException("Error on sending e-mail");
    }
}