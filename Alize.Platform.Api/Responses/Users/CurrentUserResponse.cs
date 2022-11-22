namespace Alize.Platform.Api.Responses
{
    public class CurrentUserResponse : UserResponse
    {
        public string? CompanyLogo { get; set; }

        public string? CompanyBackgroundImage { get; set; }
    }
}
