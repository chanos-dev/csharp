using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;

List<User> users = new()
{
    new User
    {
        Seq = 1,
        ID = string.Empty,
        PW = string.Empty,
    },
    new User
    {
        Seq = 2,
        ID = "chanos",
        PW = string.Empty,
    },
    new User
    {
        Seq = 3,
        ID = "chanos@google.com",
        PW = "012345678909123456678",
    },
    new User
    {
        Seq = 4,
        ID = "chanos1@google.com",
        PW = "12345678",
    }
};

UserValidator validator = new();

foreach (var user in users)
{
    ValidationResult result = validator.Validate(user);

    Console.WriteLine($"User : {user.Seq}");
    if (!result.IsValid)
        Console.WriteLine(string.Join(Environment.NewLine, result.Errors));        
    else
        Console.WriteLine("Pass ~");

    Console.WriteLine("----------------------------------------------");
}

Console.WriteLine("DONE");

class User
{
    public int Seq { get; set; }
    public string? ID { get; set; }
    public string? PW { get; set; }
}

class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.ID)
            .Cascade(CascadeMode.Stop)
            .Length(1, 255)
            .Must(ValidateID).WithMessage("'{PropertyName}'은(는) 이메일 형식이어야 합니다.")
            .NotEmpty();

        RuleFor(u => u.PW)
            .Cascade(CascadeMode.Stop)
            .Length(8, 20)
            .NotEmpty();
    }

    private bool ValidateID(string id)
    {
        var re = new Regex(@"^[0-9a-zA-Z]([-_\.]?[0-9a-zA-Z])*@[0-9a-zA-Z]([-_\.]?[0-9a-zA-Z])*\.[a-zA-Z]{2,3}$");
        return re.IsMatch(id);
    }
}