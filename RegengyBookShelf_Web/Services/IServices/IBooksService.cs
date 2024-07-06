namespace RegengyBookShelf_Web.Services.IServices
{
    public interface IBooksService
    {
        Task<T> GetAllAsync<T>();
    }
}
