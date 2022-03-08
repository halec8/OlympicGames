﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace OlympicGames.Models

{
    public static class SessionExtension
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return (string.IsNullOrEmpty(value)) ? default(T) : //error
                JsonConvert.DeserializeObject<T>(value);
        }
    }
}
