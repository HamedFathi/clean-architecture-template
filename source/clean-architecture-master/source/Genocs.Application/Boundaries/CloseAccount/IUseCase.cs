namespace Genocs.Application.Boundaries.CloseAccount
{
    using System.Threading.Tasks;

    public interface IUseCase
    {
        Task Execute(CloseAccountInput closeAccountInput);
    }
}