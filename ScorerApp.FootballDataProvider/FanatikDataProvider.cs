using HtmlAgilityPack;
using ScorerApp.FootballDataProvider.Interfaces;
using ScorerApp.FootballDataProvider.Items;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ScorerApp.FootballDataProvider
{
    public class FanatikDataProvider : IFootballDataProvider
    {
        public List<Match> GetMatches(DateTime date)
        {
            List<Match> matchList = new List<Match>();
            Uri url = new Uri($"https://www.fanatik.com.tr/canli-skor/{date.ToString("dd-MM-yyy")}-maclari");
            WebClient client = new WebClient();
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
            dokuman.LoadHtml(html);
            HtmlNodeCollection basliklar = dokuman.DocumentNode.SelectNodes("/html/body/main/section[4]/div/div/div[2]/div[3]/div");

            foreach (var item in basliklar)
            {
                try
                {
                    string leagueName = item.SelectSingleNode("div[1]/span[1]/span").InnerText;

                    HtmlNodeCollection matches = item.SelectNodes("div[2]/div/div");


                    foreach (var match in matches)
                    {
                        if (match.Id.Contains("match"))
                        {
                            Match mm = new Match
                            {
                                LeagueName = leagueName,
                                MatchId = Convert.ToInt32(match.Attributes["Id"].Value.Replace("match_", "")),
                                HomeTeamName = match.SelectSingleNode($"div/div[1]/a[1]/span").InnerText,
                                AwayTeamName = match.SelectSingleNode($"div/div[3]/a[2]/span").InnerText,
                                Status = match.SelectSingleNode($"div/div[2]/a/span[1]").InnerText,
                                Score = match.SelectSingleNode($"div/div[2]/a/span[2]").InnerText

                            };

                            matchList.Add(mm);
                        }
                    }
                }
                catch (Exception)
                {
                    return new List<Match>();
                }
            }

            return matchList;
        }
    }
}
