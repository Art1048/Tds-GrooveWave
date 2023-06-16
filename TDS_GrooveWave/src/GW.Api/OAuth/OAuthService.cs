using GW.Api.Data.Models;
using GW.Api.Data.Repository;
using Microsoft.AspNetCore.Http;


namespace GW.Api.OAuth;
public class AuthService
{
    public bool RegisterUser(UserModel user , Context context)
    {
        if(user != null && (user.Email != null || user.Email != "") && (user.Password != null || user.Password != "") && (user.FirstName != null || user.FirstName != "") && (user.LastName != null || user.LastName!= "")){
            if(user.Password.Length > 8){
                return true;
            }
            else{
                return false;
            }

        }
        else{
            return false;
        }
        
    }

    public bool Login(string username, string password , Context context)
    {
        // Lógica para autenticar o usuário com as credenciais fornecidas
        return true;
    }
}