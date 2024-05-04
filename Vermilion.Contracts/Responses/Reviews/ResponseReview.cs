namespace Vermilion.Contracts.Responses.Reviews
{
    public sealed record ResponseReview(string UserName, string Comment, 
        int Rating, DateTime CreatedAt);
}
