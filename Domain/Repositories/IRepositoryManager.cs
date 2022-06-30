namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IChatRepository ChatRepository { get; }

        IAccountRepository AccountRepository { get; }

        IUnitOfWork UnitOfWork { get; }
    }
}
