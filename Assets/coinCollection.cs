using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinCollection : MonoBehaviour
{
    // Start is called before the first frame update

    public static int count = 0;
    public Text coinCount;
    public AudioSource coinNoise;
    private ParticleSystem coinEffect;

    void Start()
    {
        coinEffect = GameObject.Find("Player").GetComponent<ParticleSystem>();
        coinCount = GameObject.Find("Count").GetComponent<Text>();
        coinCount.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
        count = PlayerPrefs.GetInt("CoinCount", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.layer == 10 && other.tag == "player")
        {
            count = PlayerPrefs.GetInt("CoinCount", 0) + 10;
            PlayerPrefs.SetInt("CoinCount", count);
            coinCount.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
            Debug.Log("Coint Count:" + count);
            coinNoise.Play();
            coinEffect.Play();
            this.GetComponent<Renderer>().enabled = false;

        }
        else if (other.tag == "player")
        { 
            count = PlayerPrefs.GetInt("CoinCount", 0) + 5;
            PlayerPrefs.SetInt("CoinCount", count);
            coinCount.text = PlayerPrefs.GetInt("CoinCount", 0).ToString();
            Debug.Log("Coint Count:" + count);
            coinNoise.Play();
            coinEffect.Play();
            this.GetComponent<Renderer>().enabled = false;
        }
        
    }


}
