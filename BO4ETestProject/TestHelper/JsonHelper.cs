using Newtonsoft.Json.Linq;

// copy pasted from https://stackoverflow.com/a/33028482
public static class JsonHelper
{
    public static JToken RemoveEmptyChildren(JToken token)
    {
        if (token.Type == JTokenType.Object)
        {
            var copy = new JObject();
            foreach (var prop in token.Children<JProperty>())
            {
                var child = prop.Value;
                if (child.HasValues)
                {
                    child = RemoveEmptyChildren(child);
                }
                if (!IsEmpty(child))
                {
                    copy.Add(prop.Name, child);
                }
            }
            return copy;
        }
        else if (token.Type == JTokenType.Array)
        {
            var copy = new JArray();
            foreach (var item in token.Children())
            {
                var child = item;
                if (child.HasValues)
                {
                    child = RemoveEmptyChildren(child);
                }
                if (!IsEmpty(child))
                {
                    copy.Add(child);
                }
            }
            return copy;
        }
        return token;
    }

    public static bool IsEmpty(JToken token)
    {
        return (token.Type == JTokenType.Null);
    }
}