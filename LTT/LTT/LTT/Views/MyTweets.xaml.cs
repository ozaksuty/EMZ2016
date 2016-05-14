using LTT.Models;
using LTT.Services;
using System;
using Xamarin.Forms;

namespace LTT.Views
{
    public partial class MyTweets : ContentPage
	{
		public MyTweets ()
		{
			InitializeComponent ();
            lvHashtag.ItemSelected += LvHashtag_ItemSelected;
        }

        private void LvHashtag_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = (Tweets)e.SelectedItem;
            DisplayAlert(selectedItem.Name, selectedItem.Tweet, "OK");
        }

        public void SearchHashtag(object sender, EventArgs e)
        {
            lvHashtag.ItemsSource = Provider.GetTweets(txtHashtag.Text);
            lblHashtag.Text = txtHashtag.Text;
            txtHashtag.Text = "";
        }
    }
}
