using MailKit.Net.Smtp;
using MimeKit;

EMailMan emailMan = new(
    new EMailConfig()
    {
        From = "chanos.dev@gmail.com",
        PassWord = "",  // https://support.google.com/accounts/answer/6010255
        Port = 465,  // https://developers.google.com/gmail/imap/imap-smtp?hl=ko
        UserName = "chanos",
        SmtpServer = "smtp.gmail.com",  // https://developers.google.com/gmail/imap/imap-smtp?hl=ko
    }
);

Console.WriteLine(await emailMan.SendAsync("test", "test content", "abc@gmail.com"));
Console.WriteLine("Done!");

class EMailMan
{
    private readonly EMailConfig _config;

    public EMailMan(EMailConfig config)
    {
        _config = config;
    } 
    public async Task<string> SendAsync(string subject, string message, string to)
    {
        MimeMessage emailMessage = new();
        emailMessage.From.Add(new MailboxAddress(_config.UserName, _config.From));
        emailMessage.To.Add(new MailboxAddress(to, to));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
        {
            Text = message
        };

        using SmtpClient client = new();
        try
        {
            await client.ConnectAsync(_config.SmtpServer, _config.Port, true);
            await client.AuthenticateAsync(_config.From, _config.PassWord);
            return await client.SendAsync(emailMessage);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"exception : {ex.Message}");
            throw;
        }
        finally
        {
            client.Disconnect(true);
            client.Dispose();
        }
    }
}

class EMailConfig
{
    public string SmtpServer {get; set;} = string.Empty;
    public int Port {get; set;}
    public string From {get; set;} = string.Empty;
    public string UserName {get; set;} = string.Empty;
    public string PassWord {get; set;} = string.Empty;

}