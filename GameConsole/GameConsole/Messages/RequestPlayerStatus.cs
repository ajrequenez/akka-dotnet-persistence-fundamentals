namespace GameConsole.Messages 
{
    public sealed class RequestPlayerStatus
    {
        public long RequestId { get; }

        public RequestPlayerStatus(int requestId)
        {
            RequestId = requestId;
        }
    }
}