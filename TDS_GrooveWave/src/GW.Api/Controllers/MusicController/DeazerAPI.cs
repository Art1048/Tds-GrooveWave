using System.Text;
using GW.Api.Data.Models;
using GW.Api.Data.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace GW.Api.Controllers.MusicServ;
public class MusicService
{
    private readonly HttpClient httpClient; // Requisição
    public MusicModel Music; // Musica a ser tratada


    public MusicService()
    {
        httpClient = new HttpClient();
        Music = new MusicModel();
    }

    public async Task<MusicModel?> GetMusic(int id){ //Recupera musica da api do deezer
        await this.GetMusicFromExternalAPIAsync(id);

        if(this.Music.MusicName != null)
        {
            return this.Music;
        }
        else{
            return null;
        }
        
    }

    public async Task<MusicModel?> GetMusicFromData(Context context ,int id){ //Verifica se a musica existe no banco, caso não recupera musica da api do deezer, e a retorna
            MusicModel? Music = context.MusicModel?.FirstOrDefault(x => x.MusicId == id);
            if(Music != null){
                return Music;
            }
            else{
                MusicModel? MusicDeazer = await GetMusic(id);

                if(MusicDeazer != null)
                {
                    return MusicDeazer;
                }
                else{
                    return null;
                }  
            }
        
    }
 
    private async Task GetMusicFromExternalAPIAsync(int id) // Get Music by id Deezer
    {
        httpClient.BaseAddress = new Uri("https://api.deezer.com/");
        httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        
        HttpResponseMessage response = await httpClient.GetAsync($"track/{id.ToString()}");
        string jsonResponse = await response.Content.ReadAsStringAsync();
        JObject json = JObject.Parse(jsonResponse);
        dynamic music = json;
        Console.WriteLine($"json:{music}");
        Console.WriteLine($"response:{response}");

        if (music.error == null)
        {
            this.Music.MusicId = id;
            this.Music.MusicName = music.title;
            this.Music.TrackLink = music.preview;
            this.Music.AuthorId = music.artist.id;
            this.Music.AlbumId = music.album.id; 
            this.Music.Photo = music.album.cover;
            this.Music.AuthorName = music.artist.name;
        }
        else{
            this.Music.MusicName = null;
        }  
    }
}