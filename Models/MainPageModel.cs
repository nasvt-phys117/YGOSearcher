using System.Text.Json;
using YGOSearcher.Helpers;

namespace YGOSearcher.Models;

public class MainPageModel
{

    public static List<string> SearchCard(string filterText)
    {
        string jsonString = File.ReadAllText(GlobalsDB.mainDir + GlobalsDB.fileName);

        Card? card = JsonSerializer.Deserialize<Card>(jsonString);

        if (card is null)
        {
            Console.WriteLine("File is empty!");
            System.Environment.Exit(1);
        }

        if (card.data is null)
        {
            System.Environment.Exit(1);
        }

        var cardResults = card.data.Where(x => x.name is not null && (x.name.Equals(filterText, StringComparison.OrdinalIgnoreCase)
        || x.name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase) 
        || x.name.Contains(filterText, StringComparison.OrdinalIgnoreCase)) ).ToList();


        if (cardResults is null || cardResults.Count <= 5)
        {
            cardResults = card.data.Where(x => x.desc is not null && x.desc.Contains(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        List<string> searchResultsOUT = [];

        for (int i = 0; i < cardResults.Count; i++)
        {
            searchResultsOUT.Add(cardResults[i].name);
        }

        return searchResultsOUT;
    }

    public static Datum GetCard(string cardName)
    {

        string jsonString = File.ReadAllText(GlobalsDB.mainDir + GlobalsDB.fileName);

        Card? card = JsonSerializer.Deserialize<Card>(jsonString);

        if (card is null)
        {
            Console.WriteLine("File is empty!");
            System.Environment.Exit(1);
        }

        var resultCardQuery = card.data?.Where(x => x.name is not null && x.name.Equals(cardName));

        return resultCardQuery.ElementAt(0);
    }
}