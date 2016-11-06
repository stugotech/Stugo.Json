using System;
using System.Collections.Generic;

namespace Stugo.Json
{
    public interface IJsonSerializer
    {
        T ToObject<T>(string json);
        object ToObject(string json, Type type);
        string ToJson(object obj);
        IDictionary<string, object> ToDictionary(string json);
        string Pretty(string json);
    }
}
