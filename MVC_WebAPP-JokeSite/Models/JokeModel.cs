using MVC_WebAPP_JokeSite.Areas.Identity.Data;
using Newtonsoft.Json;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace MVC_WebApp.Models
{
    public class APIRootModel
    {
        [Key]
        public int Id { get; set; }
        public bool error;
        public int amount;
        public JokeModel[] jokes { get; set; }
    }
    public class RootModel:IEnumerable
        {
        [Key]
        public int id { get; set; }
        public List<JokeModel> JokesList { get; set; }

            public IEnumerator GetEnumerator()
            {
                // Return the array object's IEnumerator.
                return JokesList.GetEnumerator();
            }
        }

 
        public class JokeModel
        {
            public string type { get; set; }
            public string? joke { get; set; }
            public string? setup { get; set; }
            public string? delivery { get; set; }
        [Key]
            public int id { get; set; }
        public bool UserJoke { get; set; } = false;
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
            public FlagsModel? flags { get; set; }
         
}


    public class FlagsModel
    {
        [Key]
            public int Id { get; set; }    
            public bool nsfw { get; set; }
            public bool religious { get; set; }
            public bool political { get; set; }
            public bool racist { get; set; }
            public bool sexist { get; set; }
            public bool @explicit { get; set; }
        }
    
}
