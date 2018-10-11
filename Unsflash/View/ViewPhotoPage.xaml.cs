using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Unsflash.Model;
using Unsflash.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Unsflash.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewPhotoPage : Page
    {
        public ViewPhotoPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            RootObject item = (RootObject)e.Parameter;

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.UriSource = new Uri(item.user.profile_image.medium);
            imbAuthor.ImageSource = bitmapImage;

            tblAuthorName.Text = item.user.name;
            tblUserName.Text = item.user.username;
            tblLike.Text = item.likes.ToString();

            BitmapImage bitmapImageShow = new BitmapImage();
            bitmapImageShow.UriSource = new Uri(item.urls.regular);
            imgShow.Source = bitmapImageShow;

            HttpClient httpClient = new HttpClient();
            string requestUri = RequestParameters.defaulUri + item.id + "/?client_id=" + RequestParameters.client_id;
            string reponseData = await httpClient.GetStringAsync(requestUri);
            DetailPhotoModel.RootObject rootObject = JsonConvert.DeserializeObject<DetailPhotoModel.RootObject>(reponseData);

        }
    }
}
