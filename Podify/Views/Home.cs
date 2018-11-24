using System;

using Xamarin.Forms;

namespace Podify.Views
{
    public class Home : ContentPage
    {
        public Home()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

