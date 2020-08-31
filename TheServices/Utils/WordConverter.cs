using Newtonsoft.Json;
using TheData;
using TheServices.Models;

namespace TheServices.Utils
{
    public static class WordConverter
    {   
        public static WordEntity ToEntity(this Word model)
        {
            return new WordEntity
            {
                Base = model.Base,
                Data = JsonConvert.SerializeObject(model)
            };
        }

        public static Word ToModel(this WordEntity entity)
        {
            return JsonConvert.DeserializeObject<Word>(entity.Data);
        }
    }
}