public class UserLoginRequest
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}

public class UserRegisterRequest
{
    public string? Username_register { get; set; }
    public string? Password_register { get; set; }
}



public class ResponseMessage
{
    public string? Message { get; set; }
}
