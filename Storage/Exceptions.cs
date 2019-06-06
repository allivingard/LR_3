namespace Lr1WebApi.Storage
{
    [System.Serializable]
    public class IncorrectPersonModelException : System.Exception
    {
        public IncorrectPersonModelException() { }
        public IncorrectPersonModelException(string message) : base(message) { }
        public IncorrectPersonModelException(string message, System.Exception inner) : base(message, inner) { }
        protected IncorrectPersonModelException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}