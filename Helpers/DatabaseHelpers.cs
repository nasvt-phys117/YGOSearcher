namespace YGOSearcher.Helpers;

public static class GlobalsDB
{
    internal static string cacheDir = FileSystem.Current.CacheDirectory;
    internal static string mainDir = FileSystem.Current.AppDataDirectory;
    //download
    public const string fileName = "ygo_card_list.json";

}

class DatabaseHelpers
{
    private static readonly HttpClient sharedClient = new()
    {
        BaseAddress = new Uri("https://db.ygoprodeck.com/api/v7/cardinfo.php"),
    };
    
    public static async Task RetrieveDatabase()
    {
        //check if the file is already here
        try
        {
            
            using HttpResponseMessage response = await sharedClient.GetAsync(sharedClient.BaseAddress);
            response.EnsureSuccessStatusCode();

            string jsonContent = await response.Content.ReadAsStringAsync();

            //File.WriteAllText(GlobalsDB.fileName, jsonContent);
            File.WriteAllText(GlobalsDB.mainDir + GlobalsDB.fileName, jsonContent);

        }
        catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
    }


}
