namespace MyVideotheque.Core.Exception
{
    public class InvalidMovieIdException : System.Exception
    {
        public InvalidMovieIdException(string invalidId, string message) : base(message) 
        { 
            this.InvalidId = invalidId;
        }

        public string InvalidId { get; set; }
    }
}
