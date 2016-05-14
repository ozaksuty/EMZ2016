using LinqToTwitter;
using System.Collections.Generic;
using System.Linq;
using LTT.Models;

namespace LTT.Services
{
    public class Provider
    {
        const string accessToken = "1623197311-OtNsUlADyywRkNfZS7acsoBrCti9Swu1J910R02";
        const string accessTokenSecret = "BBdHjl6tLfe86U2lYsD8ZlWfMyYlOYyrkAtJyVsRXpxar";
        const string consumerKey = "klHaCct1qA4U2zKwEazXpRSE7";
        const string consumerSecret = "wN2DC6CQjIIiTOH97dwSYGc5B5VWpGDVPD1Q7Q4TewgV3jfuKK";
        //const string twitterAccountToDisplay = "ozaksuty";

        private static SingleUserAuthorizer GetTwitterAuth()
        {
            return new SingleUserAuthorizer
            {
                CredentialStore = new InMemoryCredentialStore
                {
                    ConsumerKey = consumerKey,
                    ConsumerSecret = consumerSecret,
                    OAuthToken = accessToken,
                    OAuthTokenSecret = accessTokenSecret
                }
            };
        }

        public static List<Tweets> GetHashTagData(string hashtag)
        {
            var list = new List<Tweets>();
            var twitterContext = new TwitterContext(GetTwitterAuth());
            var hashtags = from search in twitterContext.Search
                           where search.Type == SearchType.Search &&
                           search.Query == "#" + hashtag
                           select search;

            foreach (var item in hashtags)
            {
                foreach (var tweet in item.Statuses)
                {
                    list.Add(new Tweets { Name = tweet.User.Name, Tweet = tweet.Text, Time = tweet.CreatedAt, ProfilePicture = tweet.User.ProfileImageUrl });
                }
            }

            return list;
        }

        public static List<Tweets> GetTweets(string twitterAccountToDisplay)
        {
            var list = new List<Tweets>();
            var twitterContext = new TwitterContext(GetTwitterAuth());

            var statusTweets = from tweet in twitterContext.Status
                               where tweet.Type == StatusType.User &&
                                       tweet.ScreenName == twitterAccountToDisplay &&
                                       tweet.IncludeContributorDetails == true &&
                                       tweet.Count == 10 &&
                                       tweet.IncludeEntities == true
                               select tweet;
            foreach (var tweet in statusTweets)
            {
                list.Add(new Tweets { Name = tweet.User.Name, Tweet = tweet.Text, Time = tweet.CreatedAt, ProfilePicture = tweet.User.ProfileImageUrl });
            }
            return list;
        }
    }
}