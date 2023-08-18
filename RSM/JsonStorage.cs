using JsonFlatFileDataStore;

namespace RSM;

public class JsonStorage
{
    static JsonStorage()
    {
        var store = new DataStore("data.json");

        Collection = store.GetCollection<Server>();
    }

    public static IDocumentCollection<Server> Collection { get; }
}