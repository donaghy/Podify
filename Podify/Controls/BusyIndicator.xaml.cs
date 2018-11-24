using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Podify.Controls
{
    public partial class BusyIndicator : ContentView
    {
        public static readonly BindableProperty IsBusyProperty =
            BindableProperty.Create(propertyName: "IsBusy",
                                    returnType: typeof(bool),
                                    declaringType: typeof(BusyIndicator),
                                    defaultValue: false,
                                    propertyChanged: IsBusyPropertyChanged);


        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { 
                SetValue(IsBusyProperty, value);
            }
        }

        public BusyIndicator()
        {
            InitializeComponent();

            //
            this.IsVisible = this.IsBusy; 
        }

        private static void IsBusyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BusyIndicator)bindable;
            control.IsVisible = control.IsBusy;
        }

    }
}
