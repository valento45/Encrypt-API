﻿using Encrypt_API.Enums;
using Encrypt_API.Request;
using Encrypt_API.Response;

namespace Encrypt_API.Repository.Interfaces
{
    public interface IEncryptRepository
    {
        Task<KeyEncryptResponse> GetEncryptKey(Sistema keySistema);

        Task<RegisterLoginResponse> InsertLogin(LoginRequest request);
    }
}
