using Newtonsoft.Json;

namespace LN7.WebUI.Models
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static T Get<T>(this ISession session, string key)
        {
            string json = session.GetString(key);
            if (json == null)
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static void Set<T>(this ISession session, string key, T value)
        {
            string json = JsonConvert.SerializeObject(value);
            session.SetString(key, json);
        }
    }
}