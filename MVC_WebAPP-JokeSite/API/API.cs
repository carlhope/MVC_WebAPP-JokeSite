using MVC_WebApp.Models;
using Newtonsoft.Json;

namespace MVC_WebAPP_JokeSite.API
{
    public class API
    {
        public static async Task<APIRootModel> CallAPI(int totalJokes)
        //totalJokes must be between 2 and 10. max 10 in single api call.
        //single joke is sent as object rather than array of objects. breaks when ienumerable<JokeModel>Jokes = null
        {
            string Url = "https://v2.jokeapi.dev/joke/Any?amount=" + totalJokes + "&safe-mode";
            APIRootModel randomJokes;
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(Url);
                randomJokes = JsonConvert.DeserializeObject<APIRootModel>(json);
                if (randomJokes != null) { return randomJokes; }
                else
                {
                    APIRootModel errorjoke = new APIRootModel();
                    errorjoke.error = true;
                    errorjoke.amount = 1;
                    errorjoke.jokes = new JokeModel[]
                    {new JokeModel { type = "single", joke = "No jokes found", setup = "No joke found" }};
                    return errorjoke;
                }
            }
        }
    }
}
