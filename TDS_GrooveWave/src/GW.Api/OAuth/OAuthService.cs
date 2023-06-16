using GW.Api.Data.Models;
using Microsoft.AspNetCore.Http;


namespace GW.Api.OAuth;
public class AuthService
{
    public bool RegisterUser(UserModel user)
    {
        return true;
        
    }

    public bool Login(string username, string password)
    {
        // Lógica para autenticar o usuário com as credenciais fornecidas
        return true;
    }
}