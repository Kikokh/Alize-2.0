using Alize.Platform.Api.Responses.Applications;
using Alize.Platform.Api.Responses.Modules;

namespace Alize.Platform.Api.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public string RoleName { get; set; }

        public IEnumerable<ModuleResponse> Modules { get; set; }

        public IEnumerable<ApplicationResponse> Applications { get; set; }

        public string CompanyName { get; set; }

        public string CompanyId { get; set; }

        public Guid? RoleId { get; set; }

        public long? ZendeskUserId { get; set; }
    }
}
