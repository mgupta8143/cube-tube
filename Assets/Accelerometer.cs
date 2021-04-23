using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accelerometer : MonoBehaviour
{
    // Start is called before the first frame update
    static bool tiltControls = false;
    public Text text;
    public GameObject leftButton, rightButton;
    public Text text2;

    void Start()
    {
        if(tiltControls)
        {
            text.color = Color.green;
            text2.color = Color.green;
        }
        else
        {
            text.color = Color.red;
            text2.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tilt = Input.acceleration;
        
    }

    public void toTiltControls()
    {
        tiltControls = !tiltControls;
        if (tiltControls == true)
        {
            text.color = Color.green;
            text2.color = Color.green;
            leftButton.SetActive(false);
            rightButton.SetActive(false);

        }
        else
        {
            text.color = Color.red;
            text2.color = Color.red;
            leftButton.SetActive(true);
            rightButton.SetActive(true);
        }
    }

    public static bool getTiltControls()
    {
        return tiltControls;
    }
}
