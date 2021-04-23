using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animation : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cube;
    Animator cubeanim;
    public GameObject tube;
    Animator tubeanim;
    public GameObject pipes;
    Animator pipeanim;
    public GameObject tapToStart;
    public GameObject videoAd;
    Animator videoAnimator;
    Animator startanim;
    public Score score;
    public ObstacleMovement scoregetter;
    public Text scorex;
    public Button jumpButton;
    Animator scoreanim;
    static bool buttonClicked = false;
    public GameObject pause;
    Animator pauseAnim;
    public GameObject tutorialButton;
    Animator tutorialAnim;

    void Start()
    {
        cubeanim = cube.GetComponent<Animator>();
        tubeanim = tube.GetComponent<Animator>();
        pipeanim = pipes.GetComponent<Animator>();
        startanim = tapToStart.GetComponent<Animator>();
        scoreanim = scorex.GetComponent<Animator>();
        videoAnimator = videoAd.GetComponent<Animator>();
        pauseAnim = pause.GetComponent<Animator>();
        tutorialAnim = tutorialButton.GetComponent<Animator>();

        score.enabled = false;
        scoregetter.enabled = false;
    }

   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s") || buttonClicked == true ||controlmanager.getJumpClicked() == true)
        {
            score.enabled = true;
            scoregetter.enabled = true;
            cubeanim.Play("cubo");
            tubeanim.Play("Animation");
            pipeanim.Play("pipes");
            startanim.Play("TaptoStart");
            scoreanim.Play("score");
            videoAnimator.Play("out");
            pauseAnim.Play("pauseIn");
            tutorialAnim.Play("tutorialAnim");


        }
    }
}
