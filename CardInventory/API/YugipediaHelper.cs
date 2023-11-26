using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardInventory.Entity;
using CardInventory.Utils;
using HtmlAgilityPack;

namespace CardInventory.API
{
    public static class YugipediaHelper
    {
        public static string LINK_WIKI = @"https://yugipedia.com/wiki/";
        public static string PREFIX_CARDLIST = @"Set_Card_Lists:";

        public static string SanitizeUrl(string _source)
        {
            if (string.IsNullOrWhiteSpace(_source))
                throw new Exception($"{ nameof(YugipediaHelper) } - Invalid URL, Blank or null.");

            string main_list = _source.Substring(LINK_WIKI.Length);
            if (main_list.StartsWith(PREFIX_CARDLIST) == false)
                return $"{ LINK_WIKI }{ PREFIX_CARDLIST }{ main_list }_(OCG-JP)";

            return _source;
        }
        public static async Task<List<Card>> FetchList(string _url)
        {
            int INDEX_SETCODE = 0;
            int INDEX_NAME = 1;
            int INDEX_JAP_NAME = 2;
            int INDEX_RARITY = 3;
            int INDEX_CATEGORY = 4;
            //Index if no JAP name on table.
            int INDEX_RARITY_NOJP = 2;
            int INDEX_CATEGORY_NOJP = 3;
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
                            Logger.PrintDebug("New node.");
                            var nodeCardBodies = nodeCard.ChildNodes;
                            if (nodeCardBodies != null)
                            {
                                var nodeCardBody = nodeCardBodies.Where(x => x.Name.Equals("td")).ToArray();
                                if (nodeCardBody != null && nodeCardBody.Any())
                                {
                                    count++;
                                    string cardUrl = "";
                                    string cardSetcode = "";
                                    string cardName = "";
                                    string cardJapName = "";
                                    string cardCategory = "";
                                    List<HtmlNode> nodeRarities = null;

                                    if (nodeCardBody.Length >= 5)
                                    {
                                        //Has both ENG and JAP name
                                        cardUrl = nodeCardBody[INDEX_SETCODE].ChildNodes.Where(x => x.Name.Equals("a")).FirstOrDefault()?.GetAttributeValue("href", "") ?? "";
                                        cardSetcode = nodeCardBody[INDEX_SETCODE].InnerText;
                                        cardName = nodeCardBody[INDEX_NAME].InnerText.TrimOnce("\"").DecodedHtml();
                                        cardJapName = nodeCardBody[INDEX_JAP_NAME].InnerText;
                                        cardCategory = nodeCardBody[INDEX_CATEGORY].InnerText;
                                        nodeRarities = nodeCardBody[INDEX_RARITY].ChildNodes.Where(x => x.Name.Equals("a")).ToList();
                                    }
                                    else
                                    {
                                        cardUrl = nodeCardBody[INDEX_SETCODE].ChildNodes.Where(x => x.Name.Equals("a")).FirstOrDefault()?.GetAttributeValue("href", "") ?? "";
                                        cardSetcode = nodeCardBody[INDEX_SETCODE].InnerText;
                                        cardName = nodeCardBody[INDEX_NAME].InnerText.TrimOnce("\"").DecodedHtml();
                                        cardCategory = nodeCardBody[INDEX_CATEGORY_NOJP].InnerText;
                                        nodeRarities = nodeCardBody[INDEX_RARITY_NOJP].ChildNodes.Where(x => x.Name.Equals("a")).ToList();
                                    }
                                    
                                    if (nodeRarities.IsNotEmpty())
                                    {
                                        foreach (var nodeCardRarity in nodeRarities)
                                        {
                                            string cardRarity = nodeCardRarity.InnerText;
                                            var newCardItem = new Card(cardSetcode, cardName, cardJapName, cardRarity, cardCategory);
                                            results.Add(newCardItem);
                                        }
                                    }
                                    Logger.PrintDebug($@"
                                        Card URL : { cardUrl }
                                        Card Set : { cardSetcode }
                                        Card Rarities : { string.Join(", ", nodeRarities.Select(x => x.InnerText)) }
                                    ");
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
