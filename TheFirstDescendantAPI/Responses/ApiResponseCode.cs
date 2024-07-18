namespace TheFirstDescendantAPI.Responses
{
    public enum ApiResponseCode
    {
        Success = 200,
        BadRequest = 400,
        forbidden = 403,
        TooManyRequests = 429,
        InternalServerError = 500
    }
}
