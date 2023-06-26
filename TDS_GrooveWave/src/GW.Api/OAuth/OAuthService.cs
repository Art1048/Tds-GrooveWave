using GW.Api.Data.Models;
using GW.Api.Data.Repository;
//using System.Text.RegularExpressions;

namespace GW.Api.OAuth;
public class AuthService
{
    public bool RegisterUser(UserModel user , Context context)
    {
        if(user != null && (user.Email != null || user.Email != "") && (user.Password != null || user.Password != "") && (user.FirstName != null || user.FirstName != "") && (user.LastName != null || user.LastName!= "")){
            if(user.Password!.Length >= 8){
                //Implementar futuramente

                // Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,6})+)||^([\w\.\-]+)@([\w\-]+)((\.(\w){2,6})+)((\.(\w){2,6})+)$");
                // Match match = regex.Match(user.Email!);
                // if(match.Success){
                    return true;
                // }
                // else{
                //     return false;
                // }
                
            }
            else{
                return false;
            }

        }
        else{
            return false;
        }
        
    }

    public UserModel Login(string email, string password , Context context)
    {
        var user = context.UserModel?.FirstOrDefault(u => u.Email == email && u.Password == password);
        if (user != null)
        {
            return user;
        }
        else{
            return null;
        }
        
    }
}