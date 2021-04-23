using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feedback : MonoBehaviour
{
    // Start is called before the first frame update
    public void feedback()
    {
        #if UNITY_ANDROID
         Application.OpenURL("https://play.google.com/store?hl=en_US");
        #elif UNITY_IPHONE
        #endif
    }
}
