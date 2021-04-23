using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadCoins : MonoBehaviour
{
    // Start is called before the first frame update
    private Text coinCount;

    void Start()
    {
        coinCount = GameObject.Find("Count").GetComponent<Text>();
        coinCount.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
