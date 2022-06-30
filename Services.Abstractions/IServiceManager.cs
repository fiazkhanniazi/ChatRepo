namespace Services.Abstractions
{
    public interface IServiceManager
    {
        IChatService ChatService { get; }

        IAccountService AccountService { get; }
    }
}
