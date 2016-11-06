using System;
using System.Collections.Generic;

namespace Stugo.Json
{
    public class JsonSerializer : IJsonSerializer
    {
        public static JsonSerializer Default { get; } = new JsonSerializer();


        private readonly fastJSON.SerializationManager manager;
        private readonly fastJSON.JSONParameters parameters;
        private readonly bool pretty;


        public JsonSerializer(bool pretty = false, bool preserveCase = false)
        {
            manager = new fastJSON.SerializationManager();

            parameters = new fastJSON.JSONParameters
            {
                UseExtensions = false,
                UseFastGuid = false,
                NamingConvention = preserveCase ?
                    fastJSON.NamingConvention.Default : fastJSON.NamingConvention.CamelCase
            };

            this.pretty = pretty;
        }


        public T ToObject<T>(string json)
        {
            return fastJSON.JSON.ToObject<T>(json, parameters, manager);
        }


        public object ToObject(string json, Type type)
        {
            return fastJSON.JSON.ToObject(json, type, parameters, manager);
        }


        public string ToJson(object obj)
        {
            var json = fastJSON.JSON.ToJSON(obj, parameters, manager);

            if (pretty)
                json = fastJSON.JSON.Beautify(json);

            return json;
        }


        public IDictionary<string, object> ToDictionary(string json)
        {
            return (IDictionary<string, object>)fastJSON.JSON.Parse(json);
        }


        public string Pretty(string json)
        {
            return fastJSON.JSON.Beautify(json);
        }
    }
}
