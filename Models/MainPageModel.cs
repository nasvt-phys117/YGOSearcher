using System.Text.Json;
using YGOSearcher.Helpers;
using YGOSearcher.View;

namespace YGOSearcher.Models;

public class MainPageModel
{

    public static List<string> SearchCard(string filterText)
    {
        if (filterText is null)
        {
            return [];
        }
        string jsonString = File.ReadAllText(GlobalsDB.database_path);

        Card? card = JsonSerializer.Deserialize<Card>(jsonString);

        if (card is null)
        {
            Shell.Current.DisplayAlert("Error", "Could not open card database. Check internet connection and press \"Refresh Database\" in the About page", "OK");
            return [];
        }

        //Search
        var cardResults = card.data?.Where(x => x.name is not null && (x.name.Equals(filterText, StringComparison.OrdinalIgnoreCase)
                        || x.name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)
                        || x.name.Contains(filterText, StringComparison.OrdinalIgnoreCase))).ToList();


        if (cardResults is null || cardResults.Count <= 5)
        {
            cardResults = card.data?.Where(x => x.desc is not null && x.desc.Contains(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
        }


        List<string> searchResultsOUT = [];

        if (cardResults is null)
            return searchResultsOUT;

        for (int i = 0; i < cardResults.Count; i++)
        {
            if (cardResults[i].name is not null)
                searchResultsOUT.Add(cardResults[i].name);
        }
        return searchResultsOUT;
    }

    public static Datum GetCard(string cardName)
    {
        string jsonString = File.ReadAllText(GlobalsDB.database_path);

        Card? card = JsonSerializer.Deserialize<Card>(jsonString);

        var resultCardQuery = card?.data?.Where(x => x.name is not null && x.name.Equals(cardName));

        if (resultCardQuery != null)
            return resultCardQuery.ElementAt(0);
        else
            return new Datum();
    }
}