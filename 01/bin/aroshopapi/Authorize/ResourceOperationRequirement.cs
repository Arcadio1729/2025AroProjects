using Microsoft.AspNetCore.Authorization;


namespace aroshopapi.Authorize
{
    public enum ResourceOperation
    {
        Create,
        Read,
        Update,
        Delete
    }

    public class ResourceOperationRequirement : IAuthorizationRequirement
    {
        public ResourceOperation ResourceOperation { get; set; }
        public ResourceOperationRequirement(ResourceOperation resourceOperation)
        {
            this.ResourceOperation = resourceOperation;
        }
    }
}
