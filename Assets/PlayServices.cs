using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayServices : MonoBehaviour
{
    public static PlayServices instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
        SignIn();
        PlayServices.instance.UnlockAchievements(GPGSIds.achievement_thanks_for_playing);


    }

    private void SignIn()
    {
        Social.localUser.Authenticate(success =>
        {
            if(success == true)
            {
                Debug.Log("YAY");
            }

        });
    }

    #region Achievements

    public void UnlockAchievements(string id)
    {
        Social.ReportProgress(id, 100.0f, (bool success) => {
            // handle success or failure
        });
    }

    public void ShowAchievementsUI()
    {
        Social.ShowAchievementsUI();
    }

    #endregion

    #region Leaderboards
    public void AddScoreToLeaderboard(long score)
    {
        Social.ReportScore(score, GPGSIds. leaderboard_score_leaderboard, (bool success) => {
            // handle success or failure
            if(success)
                PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") + 300);
        });
    }

   

    public void ShowLeaderboardUI()
    {
        Social.ShowLeaderboardUI();
    }

    #endregion

}

