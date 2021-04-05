using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace SportsStore.Infrastructure
{
    public static class SessionExtensions
    {
        public static void SetJSON(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetJSON<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData != null ? JsonSerializer.Deserialize<T>(sessionData) : default(T);
        }
    }
}