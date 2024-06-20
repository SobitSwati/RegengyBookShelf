﻿using RegengyBookShelf_Web.Models;

namespace RegengyBookShelf_Web.Services.IServices
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
