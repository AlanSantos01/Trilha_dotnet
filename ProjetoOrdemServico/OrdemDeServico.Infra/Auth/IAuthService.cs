﻿namespace OrdemDeServico.Infra.Auth;

public interface IAuthService
{
    string ComputeSha256Hash(string text);
    bool Login(string nome, string senha);
}
