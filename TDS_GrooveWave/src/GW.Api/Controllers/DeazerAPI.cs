using GW.Api.Data.Models;
using Newtonsoft.Json.Linq;
namespace GW.Api.Controllers.MusicServ;
public class MusicService
{
    private readonly HttpClient httpClient;
    public MusicModel Music;


    public MusicService()
    {
        httpClient = new HttpClient();
        Music = new MusicModel();
    }

    public async Task<MusicModel> GetMusic(int id){
        await this.GetMusicFromExternalAPIAsync(id);
        Console.WriteLine($"music title:{this.Music.MusicName}");

        if(this.Music.MusicName != null)
        {
            return this.Music;
        }
        else{
            return null;
        }
        
    }
 
    private async Task GetMusicFromExternalAPIAsync(int id)
    {
        httpClient.BaseAddress = new Uri("https://api.deezer.com/");
        httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        
        HttpResponseMessage response = await httpClient.GetAsync($"track/{id.ToString()}");
        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(jsonResponse);
            dynamic music = json;
            Console.WriteLine($"music title:{json}");
            this.Music.MusicId = id;
            this.Music.MusicName = music.title;
            this.Music.TrackLink = music.preview;
            this.Music.AuthorId = music.artist.id;
            this.Music.AlbumId = music.album.id; 
            this.Music.Photo = music.album.cover;
        }
        else{
            this.Music = null;
        }  
    }
}