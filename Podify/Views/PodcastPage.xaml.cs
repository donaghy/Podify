using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Podify.Views
{
    public partial class PodcastPage : ContentPage
    {
        private ViewModels.PodcastViewModel _viewModel { get => (ViewModels.PodcastViewModel)this.BindingContext; }

        public PodcastPage()
        {
            InitializeComponent();

            this.Appearing += _viewModel.Handle_Appearing;
        }

        public PodcastPage(string newPodcastFeedUrl) : this()
        {
            _viewModel.PodcastFeedUrl = newPodcastFeedUrl;
        }

    }
}
