using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using Xamarin.Forms;

namespace Podify.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class PodcastSearchViewModel : StandardViewModel
    {
        #region Public Members

        public List<Models.iTunesResult> Podcasts { get; set; }
        public string SearchString { get; set; }
        public ICommand SearchCommand { get; set; }

        #endregion

        public PodcastSearchViewModel()
        {
            SearchCommand = new Command(DoSearchCommand);
        }

        public void Handle_Appearing(object sender, EventArgs e)
        {
            try
            {
                SearchString = "Football Ramble";
            }
            catch (Exception ex)
            {
                Models.Logger.LogException(ex, MethodBase.GetCurrentMethod().Name);
            }
        }

        void DoSearchCommand(object obj)
        {
            Task.Run(() =>
            {

                try
                {
                    SetIsBusy(true);

                    Podcasts = GetPodcasts();

                    //System.Threading.Thread.Sleep(10000);
                }
                catch (Exception ex)
                {
                    Models.Logger.LogException(ex, MethodBase.GetCurrentMethod().Name);
                }
                finally
                {
                    SetIsBusy(false);
                }

            });
        }

        #region Subs & Functions

        private List<Models.iTunesResult> GetPodcasts()
        {
            var term = SearchString?.Replace(" ", "+");

            var data = ReadUrl(term);
            if (data != null)
            {
                var wrapper = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.iTunesWrapper>(data);
                Console.WriteLine(wrapper?.resultCount);

                //Order data
                var results = wrapper.results.OrderBy(i => i.collectionName).ToList();

                return results;
            }

            return null;
        }

        private string ReadUrl(string term)
        {
            string data = null;

            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(
                $"https://itunes.apple.com/search?term={term}&media=podcast&entity=podcast");

            // If required by the server, set the credentials.  
            //request.Credentials = CredentialCache.DefaultCredentials;

            using (var response = request.GetResponse())
            {
                using (var ds = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(ds))
                    {
                        data = sr.ReadToEnd();
                    }
                }
            }

            return data;
        }

        #endregion
    }
    
}
