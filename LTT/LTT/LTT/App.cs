using LinqToTwitter;
using LTT.Views;
using System.Linq;
using Xamarin.Forms;

namespace LTT
{
	public class App : Application
	{
		public App ()
		{
            //const string accessToken = "1623197311-OtNsUlADyywRkNfZS7acsoBrCti9Swu1J910R02";
            //const string accessTokenSecret = "BBdHjl6tLfe86U2lYsD8ZlWfMyYlOYyrkAtJyVsRXpxar";
            //const string consumerKey = "klHaCct1qA4U2zKwEazXpRSE7";
            //const string consumerSecret = "wN2DC6CQjIIiTOH97dwSYGc5B5VWpGDVPD1Q7Q4TewgV3jfuKK";
            //const string twitterAccountToDisplay = "ozaksuty";

            //var authorizer = new SingleUserAuthorizer
            //{
            //    CredentialStore = new InMemoryCredentialStore
            //    {
            //        ConsumerKey = consumerKey,
            //        ConsumerSecret = consumerSecret,
            //        OAuthToken = accessToken,
            //        OAuthTokenSecret = accessTokenSecret
            //    }
            //};
            //var twitterContext = new TwitterContext(authorizer);

            //var srch =
            //    (from search in twitterContext.Search
            //     where search.Type == SearchType.Search &&
            //           search.Query == "#emz2016" &&
            //           search.Count == 7
            //     select search)
            //    .SingleOrDefault();

            //var hashtags = from search in twitterContext.Search
            //              where search.Type == SearchType.Search &&
            //              search.Query == "#emz2016"
            //              select search;

            //foreach (var item in hashtags)
            //{
            //    var xx = item;
            //}

            //var statusTweets = from tweet in twitterContext.Status
            //                   where tweet.Type == StatusType.User &&
            //                           tweet.ScreenName == twitterAccountToDisplay &&
            //                           tweet.IncludeContributorDetails == true &&
            //                           tweet.Count == 10 &&
            //                           tweet.IncludeEntities == true
            //                   select tweet;
            //var layout = PrintTweets(statusTweets);

            //MainPage = new ContentPage
            //{
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Entry()
            //        }
            //    }
            //};
            MainPage = new MainPage();
        }

        private static StackLayout PrintTweets(IQueryable<Status> statusTweets)
        {
            StackLayout layout = new StackLayout();
            foreach (var statusTweet in statusTweets)
            {
                Label lbl = new Label();
                lbl.Text = statusTweet.Text;
                layout.Children.Add(lbl);
            }
            return layout;
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
