namespace RegengyBookShelf_Web.Services.IServices
{
    public interface IBooksService
    {
        Task<T> GetAllAsync<T>();
		Task<T> GetAsync<T>(int bookId);
	}
}
