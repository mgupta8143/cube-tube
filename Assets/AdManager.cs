using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardedAd;
    public Text coins;
    static bool adsNeeded = true;

    public static void setAds(bool x)
    {
        adsNeeded = x;
    }

    private void Start()
    {
        #if UNITY_ANDROID
            string appId = "ca-app-pub-8349023020696050~2632528897";
#elif UNITY_IPHONE
            string appId = "todo";
#else
            string appId = "";
#endif

        MobileAds.Initialize(appId);
        rewardedAd = RewardBasedVideoAd.Instance;
        rewardedAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
        RequestRewardVideo();
    }

    public void ShowRewardVideo()
    {
        if(rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
            coins.text = (PlayerPrefs.GetInt("CoinCount")).ToString();
        }

    }

    private void RequestRewardVideo()
    {
#if UNITY_ANDROID
        string rewardAdId = "ca-app-pub-8349023020696050/7329056768";
#elif UNITY_IPHONE
            string interstitialId = "todo";
#else
            string interstitialId = "";
#endif
        rewardedAd.LoadAd(CreateNewRequest(), rewardAdId);

    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        double amount = args.Amount;
        PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") + (int)amount);
        GameObject.Find("Count").GetComponent<Text>().text = PlayerPrefs.GetInt("CoinCount").ToString();
    }

    public void ShowInterstitial()
    {
        if(adsNeeded == true && restartGame.restartCount % 3 == 0)
             RequestInterstitial();
    }

    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
            string interstitialId = "ca-app-pub-8349023020696050/7118568812";
#elif UNITY_IPHONE
            string interstitialId = "todo";
#else
            string interstitialId = "";
#endif
        if (PlayerPrefs.GetInt("AdPurchased", 0) == 0)
        {
            if (interstitial != null)
                interstitial.Destroy();

            interstitial = new InterstitialAd(interstitialId);
            interstitial.OnAdLoaded += HandleOnAdLoaded;

            interstitial.LoadAd(CreateNewRequest());
        }
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        if (interstitial.IsLoaded())
            interstitial.Show();
    }

    private AdRequest CreateNewRequest()
    {
        return new AdRequest.Builder().Build();
    }

  

    

}
