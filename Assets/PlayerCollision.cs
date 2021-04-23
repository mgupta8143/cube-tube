
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{

    public GameObject panel;
    Animator panelanim, gameanim, scoreanim;
    public Text gameOver;
    public Text endScore;
    public Text score;
    public GameObject scoregetter;
    public Rigidbody sg;
    public GameObject startScreenPanel;
    public ObstacleMovement scoregetter2;
    public AudioSource background;
    public Button jumpButton;
    public GameObject PauseButton;
    public Text randomQuote;
    Animator pauseAnimator;

    private void Start()
    {
        panelanim = panel.GetComponent<Animator>();
        gameanim = gameOver.GetComponent<Animator>();
        scoreanim = score.GetComponent<Animator>();
        pauseAnimator = PauseButton.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "obstacle")
        {
            int z = (int)Random.Range(0, 20f);
            if (restartGame.getRestarted())
            {
                switch (z)
                {
                    case 0:
                        randomQuote.text = "I know... it hurts";
                        break;
                    case 1:
                        randomQuote.text = "No pain, well no pain";
                        break;
                    case 2:
                        randomQuote.text = "Tu be determined";
                        break;
                    case 3:
                        randomQuote.text = "LOLOLOLOLOLOL";
                        break;
                    case 4:
                        randomQuote.text = "360 No Scope";
                        break;
                    case 5:
                        randomQuote.text = "Well I'll be... you made it";
                        break;
                    case 6:
                        randomQuote.text = "Frustrating, right? NOPEEE";
                        break;
                    case 7:
                        randomQuote.text = "Tip: Try maintaining a steady altitude";
                        break;
                    case 8:
                        randomQuote.text = "How hard? Over 9000";
                        break;
                    case 9:
                        randomQuote.text = "You mad bro/sis? Nah jk jk cuz i know u are";
                        break;
                    case 10:
                        randomQuote.text = "the cube died...";
                        break;
                    case 11:
                        randomQuote.text = "I AM YOUR FATHER! NOOOOOOOO!";
                        break;
                    case 12:
                        randomQuote.text = "You'll see ... you'll see";
                        break;
                    case 13:
                        randomQuote.text = "I must say... that was interesting";
                        break;
                    case 14:
                        randomQuote.text = "Omae wa mou shinderu! NANI?!?!?!";
                        break;
                    case 15:
                        randomQuote.text = "God's Plan (by you know who)";
                        break;
                    case 16:
                        randomQuote.text = "Oh btw, I'm wally";
                        break;
                    case 17:
                        randomQuote.text = "Wait what? How...? HOW?!?!?!!?";
                        break;
                    case 18:
                        randomQuote.text = "Have i appeared twice yet?";
                        break;
                    case 19:
                        randomQuote.text = "OH NO IT'S A TITANN RUNN";
                        break;
                    case 20:
                        randomQuote.text = "Thanks for playing! SIKEE nah jk";
                        break;
                }
            }
            restartGame.setRestarted(false);

            startScreenPanel.SetActive(false);
            Debug.Log("Game Over");
            panelanim.Play("gamescreen");
            gameanim.Play("gameOver");
            scoreanim.Play("score gone");
            pauseAnimator.Play("pauseOut");
            sg.isKinematic = true ;
            scoregetter2.enabled = false;
            PlayerMovement.setY(false);
            background.Stop();

        }
        if(collision.collider.tag == "coin")
        {
            this.GetComponent<ParticleSystem>().Play();
        }
    }

    

    

}
