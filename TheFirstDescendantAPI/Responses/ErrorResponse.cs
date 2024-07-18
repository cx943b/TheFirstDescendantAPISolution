namespace TheFirstDescendantAPI.Responses
{
    public class ErrorResponse : ResponseBase
    {
        public string Name { get; set; }
        public string Message { get; set; }

        public override string ToString() => $"Name: {Name}\r\nMessage: {Message}";
    }
}
