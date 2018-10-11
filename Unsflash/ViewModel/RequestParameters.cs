using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unsflash.ViewModel
{
    class RequestParameters
    {
        public static string redirect_uri = "https://www.facebook.com/nasa1992";
        public static string client_id = "3d2984268b6ddb60817f538fd89760421fd522048de87620e456c00cf867a260";
        public static string client_secret = "dd616a0006659294d84d723dfcaa6d0fd8f3dbced6e4e23da7a2290b4cb5c774";
        public static string code = "";
        public static string api_url = "https://unsplash.com/oauth/authorize?"
            + "client_id=" + client_id
            + "&redirect_uri=" + redirect_uri
            + "&response_type=code"
            + "&scope=public+read_user";

        public static string token_uri = "https://unsplash.com/oauth/token?"
                + "client_id=" + client_id
                + "&client_secret=" + client_secret
                + "&redirect_uri=" + redirect_uri
                + "&code=" + code
                + "&grant_type=authorization_code";
        public static string defaulUri = "https://api.unsplash.com/photos/";
        public static string publicAuUri = defaulUri + "?client_id=" + client_id + "&per_page=30";
        public static string publicPopularUri = "https://api.unsplash.com/photos/?client_id=" + client_id + "&per_page=30&order_by=popular";

        //Collection
        public static string featuredCollectionUri = "https://api.unsplash.com/collections/featured?client_id=" + client_id + "&page=1&per_page=30";
        public static string curatedCollectionUri = "https://api.unsplash.com/collections/curated?client_id=" + client_id + "&page=1&per_page=30";

        //public static string photoInfoUri = defaulUri + ;
    }
}
