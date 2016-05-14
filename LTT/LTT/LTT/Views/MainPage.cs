using Xamarin.Forms;

namespace LTT.Views
{
    public class MainPage : CarouselPage
    {
        public MainPage()
        {
            Children.Add(new Hashtag());
            Children.Add(new MyTweets());
        }
    }
}