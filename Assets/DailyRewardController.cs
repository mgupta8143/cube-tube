using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;

public class DailyRewardController : MonoBehaviour
{
    private readonly string baseURL = "http://worldclockapi.com/api/json/est/now";
    private Text coinText;
    private GameObject dailyRewardButton;

    private void Awake()
    {
        coinText = GameObject.Find("Count").GetComponent<Text>();
        dailyRewardButton = GameObject.Find("DailyReward");
    }

    private void Start()
    {
        StartCoroutine(CheckReward());
    }

    // Start is called before the first frame update
    public void getReward()
    {
        PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") + 100);
        coinText.text = PlayerPrefs.GetInt("CoinCount").ToString();
        dailyRewardButton.SetActive(false);
    }

    IEnumerator CheckReward()
    {
        UnityWebRequest request = UnityWebRequest.Get(baseURL);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError(request.error);
            yield break;
        }

        JSONNode requestInfo = JSON.Parse(request.downloadHandler.text);
        string currentDateTime = requestInfo["currentDateTime"];

        if (PlayerPrefs.GetString("PreviousRewardTime", "") == "" || int.Parse(PlayerPrefs.GetString("PreviousRewardTime").Substring(8, 2)) < int.Parse(currentDateTime.Substring(8, 2)) || int.Parse(PlayerPrefs.GetString("PreviousRewardTime").Substring(5, 2)) < int.Parse(currentDateTime.Substring(5, 2)) ||
            (int.Parse(PlayerPrefs.GetString("PreviousRewardTime").Substring(5, 2)) == 12 && int.Parse(currentDateTime.Substring(5, 2)) == 1))
        {
            PlayerPrefs.SetString("PreviousRewardTime", currentDateTime);
            dailyRewardButton.SetActive(true);
        }
        else
        {
            dailyRewardButton.SetActive(false);
        }
    }
}
