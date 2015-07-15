using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Media.SpeechSynthesis;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Talk_It
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void exitAppTap(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void textBoxFocus(object sender, RoutedEventArgs e)
        {
            if(textBox.Text == "Your text goes here!")
            {
                textBox.Text = "";
            }
            
        }

        private async void talkItButtonTap(object sender, RoutedEventArgs e)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            string message = textBox.Text;

            if (message != null)
            {
                var stream = await synth.SynthesizeTextToStreamAsync(message);
                var media = new MediaElement();
                media.SetSource(stream, stream.ContentType);
                media.Play();
            }
            else
            {
                message = "Text box is empty";
                var stream = await synth.SynthesizeTextToStreamAsync(message);
                var media = new MediaElement();
                media.SetSource(stream, stream.ContentType);
                media.Play();
            }
        }

        private void textBoxLostFocus(object sender, RoutedEventArgs e)
        {
               if(textBox.Text == null)
               {
                   textBox.Text = "Your text goes here!";
               }
        }

        private void showPrivacyDoc(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PrivacyShowerPage));
        }

        private void aboutAppClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AboutPage));
        }

        private void refreshFields(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != null)
                textBox.Text = "";
        }

    }
}
