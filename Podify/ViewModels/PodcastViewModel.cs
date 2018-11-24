using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using Podify.Extensions;
using PropertyChanged;

namespace Podify.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class PodcastViewModel : StandardViewModel
    {
        public string PodcastFeedUrl;
        public SyndicationFeed Podcast { get; set; }
        public ObservableCollection<SyndicationItem> Episodes { get; set; }

        public PodcastViewModel()
        {
            Episodes = new ObservableCollection<SyndicationItem>();
        }

        public PodcastViewModel(string newPodcastFeedUrl) : this()
        {
            PodcastFeedUrl = newPodcastFeedUrl;
        }

        public void Handle_Appearing(object sender, EventArgs e)
        {
            Task.Run(() =>
            {

                try
                {
                    SetIsBusy(true);

                    //SyndicationFeed feed = null;
                    string url = PodcastFeedUrl;

                    using (XmlReader reader = XmlReader.Create(url))
                    {
                        Podcast = SyndicationFeed.Load(reader);
                        foreach (SyndicationItem item in Podcast.Items)
                            Episodes.AddSorted(item);
                    }

                    //Episodes = (
                    //from si in feed.Items
                    //orderby si.PublishDate descending
                    //select si).ToList();
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
    }

}
