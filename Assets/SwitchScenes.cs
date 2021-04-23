using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    // Start is called before the first frame updateC
    public Button navButton;
    public GameObject navPanel;
    Animator navAnim;
    Animator navButtonAnim;
    public Camera cam;
    public static int count;



    void Start()
    {
        count = 0;
        navAnim = navPanel.GetComponent<Animator>();
        navButtonAnim = navButton.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        navButton.onClick.AddListener(delegate {openNav(); });
        //Debug.Log(Camera.WorldToScreenPoint(navButton.transform.position, cam));

    }
 
   

    //this method is for the nav bar
    public void openNav()
    {
        if (cam.WorldToViewportPoint(navButton.transform.position).x > 12.3)
        {
            navAnim.Play("navdan");
            navButtonAnim.Play("moveleft");
        }
        else
        {
            navAnim.Play("navpan");
            navButtonAnim.Play("moveright");
        }



    }

   

  
}
