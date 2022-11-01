using UnityEngine;
using System;
using GoogleMobileAds.Api;
using System.Collections;
using UnityEngine.UI;

public enum AdType
{
    INTERSTITIAL,
    REWARDEDFREEZÝNG,
    REWARDEDBOMB,
}

public class Ads : MonoBehaviour
{
    [HideInInspector]
    public string interstitialId, rewardedAdIdBomb, rewardedAdIdFreezing;


    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAdBomb;
    private RewardedAd rewardedAdFreezing;

    public static Ads instance;



    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null) instance = this;
        else Destroy(gameObject);

        // ctrl + k + c
        //if (Application.platform == RuntimePlatform.Android)
        //{
        //    interstitialId = "ca-app-pub-1131363594533119/9369877922";

        //    rewardedAdIdChange = "ca-app-pub-1131363594533119/5430632913";

        //    rewardedAdIdLetter = "ca-app-pub-1131363594533119/5430632913";
        //}
        //else
        //{
        //    interstitialId = "ca-app-pub-1131363594533119/3379184647";

        //    rewardedAdIdChange = "ca-app-pub-1131363594533119/2233909348";

        //    rewardedAdIdLetter = "ca-app-pub-1131363594533119/2233909348";
        //}

        #region TestId

        interstitialId = "ca-app-pub-3940256099942544/1033173712";

        rewardedAdIdFreezing = "ca-app-pub-3940256099942544/5224354917";

        rewardedAdIdBomb = "ca-app-pub-3940256099942544/5224354917";

        #endregion
    }

    void Start()
    {
        MobileAds.Initialize(reklamDurumu => { });

        requestAds(AdType.INTERSTITIAL);
        requestAds(AdType.REWARDEDFREEZÝNG);
        requestAds(AdType.REWARDEDBOMB);


        this.rewardedAdFreezing.OnUserEarnedReward += RewardFreezing;
        this.rewardedAdBomb.OnUserEarnedReward += RewardBomb;

        this.rewardedAdFreezing.OnAdClosed += RequestRewardedFreezing;
        this.rewardedAdBomb.OnAdClosed += RequestRewardedBomb;
        this.interstitialAd.OnAdClosed += RequestInterstitial;

    }

    #region CallBacks

    #region Load & Show

    void RewardFreezing(object sender, Reward args)
    {
        Debug.Log("Letter Ödülü");

        //oyunyoneticisi yonetici = FindObjectOfType<oyunyoneticisi>();

        //yonetici.OyuncuyaOdulVer();
        //AbilityManager.instance.Freezing();
        Time.timeScale = 0;
    }
    void RewardBomb(object sender, Reward args)
    {
        Debug.Log("Change Ödülü");

        //oyunyoneticisi yonetici = FindObjectOfType<oyunyoneticisi>();

        //yonetici.OyuncuyaOdulVer2();
        //AbilityManager.instance.Bomb();
        Time.timeScale = 0;
    }
    #endregion

    private void RequestRewardedFreezing(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDEDFREEZÝNG);
    }
    private void RequestRewardedBomb(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDEDBOMB);
    }
    private void RequestInterstitial(object sender, EventArgs args)
    {
        requestAds(AdType.INTERSTITIAL);
    }


    //Show
    public void ShowRewardedFreezing()
    {
        this.rewardedAdFreezing.OnUserEarnedReward -= RewardFreezing;
        this.rewardedAdFreezing.OnUserEarnedReward += RewardFreezing;

        this.rewardedAdFreezing.OnAdClosed -= RequestRewardedFreezing;
        this.rewardedAdFreezing.OnAdClosed += RequestRewardedFreezing;


        if (rewardedAdFreezing.IsLoaded())
            rewardedAdFreezing.Show();
    }
    public void ShowRewardedBomb()
    {
        this.rewardedAdBomb.OnUserEarnedReward -= RewardBomb;
        this.rewardedAdBomb.OnUserEarnedReward += RewardBomb;

        this.rewardedAdBomb.OnAdClosed -= RequestRewardedBomb;
        this.rewardedAdBomb.OnAdClosed += RequestRewardedBomb;

        if (rewardedAdBomb.IsLoaded())
            rewardedAdBomb.Show();
    }
    public void ShowInter()
    {

        this.interstitialAd.OnAdClosed -= RequestInterstitial;
        this.interstitialAd.OnAdClosed += RequestInterstitial;

        if (interstitialAd.IsLoaded())
            interstitialAd.Show();
    }


    #endregion

    #region  Request&Load
    public void requestAds(AdType type)
    {
        switch (type)
        {
            case AdType.INTERSTITIAL:
                {
                    if (interstitialAd != null) interstitialAd.Destroy();
                    interstitialAd = new InterstitialAd(interstitialId);
                    interstitialAd.LoadAd(new AdRequest.Builder().Build());
                    break;

                }

            case AdType.REWARDEDBOMB:
                {
                    if (rewardedAdBomb != null) rewardedAdBomb.Destroy();
                    rewardedAdBomb = new RewardedAd(rewardedAdIdBomb);
                    rewardedAdBomb.LoadAd(new AdRequest.Builder().Build());
                    break;
                }
            case AdType.REWARDEDFREEZÝNG:
                {
                    if (rewardedAdFreezing != null) rewardedAdFreezing.Destroy();
                    rewardedAdFreezing = new RewardedAd(rewardedAdIdFreezing);
                    rewardedAdFreezing.LoadAd(new AdRequest.Builder().Build());
                    break;
                }

        }
    }
    #endregion
  
}