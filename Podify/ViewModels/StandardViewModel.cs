using System;
using PropertyChanged;
using Xamarin.Forms;

namespace Podify.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class StandardViewModel
    {
        public StandardViewModel()
        {

        }

        public bool IsBusy { get; private set; }

        public void SetIsBusy(bool busy)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                IsBusy = busy;
            });
        }

    }
}
