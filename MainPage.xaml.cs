using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.Loaded += OnLoaded;
            this.Unloaded += OnUnloaded;
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            backBtn.Click -= ButtonBase_OnClick;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            backBtn.Click += ButtonBase_OnClick;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var frame = Window.Current.Content as Frame;
            frame.GoBack();
        }

        private async void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog();
            dialog.PrimaryButtonText = "ok";
            dialog.Closed += DialogOnClosed;
            await dialog.ShowAsync();

            GC.Collect(3, GCCollectionMode.Forced);
        }

        private void DialogOnClosed(ContentDialog sender, ContentDialogClosedEventArgs args)
        {
            sender.Closed -= DialogOnClosed;
        }
    }
}
