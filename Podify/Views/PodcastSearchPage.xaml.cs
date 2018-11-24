using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using Xamarin.Forms;

namespace Podify.Views
{
    public partial class PodcastSearchPage : ContentPage
    {
        private ViewModels.PodcastSearchViewModel _viewModel { get => (ViewModels.PodcastSearchViewModel)this.BindingContext; }

        public PodcastSearchPage()
        {
            InitializeComponent();

            this.Appearing += _viewModel.Handle_Appearing;
            this.lstPodcasts.ItemSelected += LstPodcasts_ItemSelected;
        }

        void LstPodcasts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (e.SelectedItem == null)
                    return;

                var podcast = (Models.iTunesResult)e.SelectedItem;
                App.NavigationManager.PushAsync(new PodcastPage(podcast.feedUrl));
            }
            catch (Exception ex)
            {
                Models.Logger.LogException(ex, MethodBase.GetCurrentMethod().Name);
            }
        }

    }
}
