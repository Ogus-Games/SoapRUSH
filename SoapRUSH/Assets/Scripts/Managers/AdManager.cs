using GoogleMobileAds.Api;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class AdManager : MonoBehaviour
    {
        public string appID = "ca-app-pub-6734054441405950~2171722172";
        public string interstitialID = "ca-app-pub-6734054441405950/5526829048";

        private BannerView bannerAd;
        private InterstitialAd _interstitial;

        private void Start()
        {
            MobileAds.Initialize(status => {});
            //this.RequestBanner();
        }

        private AdRequest CreateAdRequest()
        {
            return new AdRequest.Builder().Build();
        }

        private void RequestBanner()
        {
            string adUnitID = "ca-app-pub-3940256099942544/6300978111";
            this.bannerAd = new BannerView(adUnitID, AdSize.SmartBanner, AdPosition.Bottom);
            this.bannerAd.LoadAd(this.CreateAdRequest()); 
        }

        public void RequestInterstitial()
        {
            string AdUnitID = "ca-app-pub-3940256099942544/1033173712";
            if (this._interstitial != null)
            {
                this._interstitial.Destroy();
            }
            this._interstitial = new InterstitialAd(AdUnitID);
            this._interstitial.LoadAd(this.CreateAdRequest());
        }

        public void ShowInterstitial()
        {
            if (this._interstitial.IsLoaded())
            {
                _interstitial.Show();
            }
            else
            {
                Debug.Log("Interstitial is not ready yet..");
            }
        }
        
    }
}
