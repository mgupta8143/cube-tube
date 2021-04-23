using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score2 : MonoBehaviour
{
    // Start is called before the first frame update


    public static Text sco; 



    void Start()
    {
        sco = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static int getCurrentScore()
    {
        return int.Parse(sco.text);
    }   

}
