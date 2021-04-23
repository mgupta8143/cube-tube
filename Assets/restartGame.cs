using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class restartGame : MonoBehaviour
{
    public Transform player;
    public Rigidbody p;
    public GameObject gameScreenPanel;
    public GameObject startScreenPanel;
    public Text randomquote;
    public Text gameOver;
    public GameObject scoregetter;
    public GameObject pipes;
    public GameObject videoAd;
    public GameObject tutorialButton;
    public Text cube, tube, tapToStart;
    public static int restartCount = 0;
    Animator panelanim, gameOverAnim, scoreanim, pipeanim, canim, tanim, startanim, videoAnimator, tutorialAnim;
    public GameObject navButton;
    Animator navButtonanim;
    static bool restarted = true;

    public void Start()
    {
        videoAnimator = videoAd.GetComponent<Animator>();
    }

   
    public void restart()
    {
        restarted = true;
        randomquote.text = "";
        PlayServices.instance.AddScoreToLeaderboard(PlayerPrefs.GetInt("HighScore"));
        if (PlayerPrefs.GetInt("HighScore") >= 0)
        {
            PlayServices.instance.UnlockAchievements(GPGSIds.achievement_thanks_for_playing);
        }
        if (PlayerPrefs.GetInt("HighScore") >= 10000)
        {
            PlayServices.instance.UnlockAchievements(GPGSIds.achievement_10000_points);
        }
        if (PlayerPrefs.GetInt("HighScore") >= 100000)
        {
            PlayServices.instance.UnlockAchievements(GPGSIds.achievement_100000_points);
        }
        if (PlayerPrefs.GetInt("HighScore") >= 1000000)
        {
            PlayServices.instance.UnlockAchievements(GPGSIds.achievement_1000000_points);
        }
        if (PlayerPrefs.GetInt("HighScore") >= 5000000)
        {
            PlayServices.instance.UnlockAchievements(GPGSIds.achievement_5000000_points);
        }
        if (PlayerPrefs.GetInt("HighScore") >= 10000000)
        {
            PlayServices.instance.UnlockAchievements(GPGSIds.achievement_10000000_points);
        }
        restartCount++;
        startScreenPanel.SetActive(true);
        tutorialAnim = tutorialButton.GetComponent<Animator>();
        panelanim = gameScreenPanel.GetComponent<Animator>();
        gameOverAnim = gameOver.GetComponent<Animator>();
        pipeanim = pipes.GetComponent<Animator>();
        canim = cube.GetComponent<Animator>();
        tanim = tube.GetComponent<Animator>();
        startanim = tapToStart.GetComponent<Animator>();
        scoregetter.transform.position = new Vector3(0, -1000, 0);
        scoregetter.GetComponent<Rigidbody>().isKinematic = false;
        player.position = new Vector3(0, 0, 0);
        p.angularVelocity = Vector3.zero;
        player.rotation = new Quaternion(0, 0, 0, 0);
        panelanim.Play("restart");
        gameOverAnim.Play("restarttext");
        pipeanim.Play("pipereturn");
        canim.Play("cubereturn");
        tanim.Play("tubereturn");
        startanim.Play("startreturn");
        videoAnimator.Play("backIn");
        tutorialAnim.Play("tutorialBack");
        navButtonanim = navButton.GetComponent<Animator>();
        navButtonanim.Play("movei");
        PlayerMovement.navbarOut = false;
        PlayerMovement.roundStart = false;

    }

    public static bool getRestarted()
    {
        return restarted;
    }

    public static void setRestarted(bool x)
    {
        restarted = x;
    }

 
}
