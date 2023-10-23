using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardInventory.Entity;
using HtmlAgilityPack;

namespace CardInventory.API
{
    public static class YugipediaHelper
    {
        public static async Task<List<Card>> FetchList(string _url)
        {
            int INDEX_SETCODE = 0;
            int INDEX_NAME = 1;
            int INDEX_JAP_NAME = 2;
            int INDEX_RARITY = 3;
            int INDEX_CATEGORY = 4;
            try
            {
                return await Task.Run( () =>
                {
                    int count = 0;//Count unique cards, disregarding rarity variations.
                    var results = new List<Card>();
                    HtmlWeb web = new HtmlWeb();
                    var htmlDoc = web.Load(_url);
                    var docNode = htmlDoc.DocumentNode;
                    var nodeCardListMain = docNode.SelectNodes("//div").Where(x => x.HasClass("set-list")).FirstOrDefault();
                    var nodeCardList = nodeCardListMain.SelectNodes("//tr");
                    foreach (HtmlNode nodeCard in nodeCardList)
                    {
                        if (nodeCard.HasChildNodes)
                        {
                            Console.WriteLine("New node.");
                            var nodeCardBodies = nodeCard.ChildNodes;
                            if (nodeCardBodies != null)
                            {
                                var nodeCardBody = nodeCardBodies.Where(x => x.Name.Equals("td")).ToArray();
                                if (nodeCardBody != null && nodeCardBody.Any())
                                {
                                    count++;
                                    string cardSetcode = nodeCardBody[INDEX_SETCODE].InnerText;
                                    string cardName = nodeCardBody[INDEX_NAME].InnerText;
                                    string cardJapName = nodeCardBody[INDEX_JAP_NAME].InnerText;
                                    string cardCategory = nodeCardBody[INDEX_CATEGORY].InnerText;
                                    var nodeRarities = nodeCardBody[INDEX_RARITY].ChildNodes.Where(x => x.Name.Equals("a"));
                                    foreach (var nodeCardRarity in nodeRarities)
                                    {
                                        string cardRarity = nodeCardRarity.InnerText;
                                        var newCardItem = new Card(cardSetcode, cardName, cardJapName, cardRarity, cardCategory);
                                        results.Add(newCardItem);
                                    }
                                    Console.WriteLine($@"
                                        Card Set : { cardSetcode }
                                        Card Rarities : { string.Join(", ", nodeRarities.Select(x => x.InnerText)) }
                                    ".Replace("                                    ", ""));
                                }
                            }
                        }
                    }

                    return results;
                });
            }
            catch (Exception ex)
            {
                //TODO: Error handler
            }
            return null;
        }
    }
}
