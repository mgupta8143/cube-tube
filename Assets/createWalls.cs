using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createWalls : MonoBehaviour
{

    public GameObject LowLeftPrefab, LowMiddlePrefab, LowRightPrefab, HighLeftPrefab, HighRightPrefab, HighMiddlePrefab, RightVertWall, LeftVertWall, MiddleVertWall,
        LowLeftWallHorz, LowMiddleWallHorz, LowRightWallHorz, HighLeftWallHorz, HighMiddleWallHorz, HighRightWallHorz;
    public GameObject FullPipe;
    public GameObject gameOver, gameOverScreen;
    public AudioSource background;
    public GameObject pauseUI;
    public GameObject score;
    public Button pause;
    public ObstacleMovement scoregetter2;
    public GameObject Ground;
    public GameObject endScore;
    public GameObject endScoreLabel;
    public Text Tube;
    public Text Cube;
    public Text HighScore, Score;
    public Text TapToStart;
    public Button leftButton, rightButton, jumpButton;
    public GameObject scoreGetter;
    public Button navButton, videoButton;
    public GameObject arrow;
    public GameObject Pipes;
    public Camera cameraa;
    public Button restart;
    public Button restartButton;
    public float respawnTime = 40.0f;
    private Vector3 screenBounds;
    bool gameStart = false;
    bool hasHappened = false;
    static bool restartClicked = false;
    public Transform player;
    public Rigidbody p;
    public Material tubeMat;
    ColorBlock cb;



    public int getCurrentScore()
    {
        return int.Parse(Score.text);
    }


    // Start is called before the first frame update
    void Start()
    {
        Tube.color = Color.white;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        gameStart = false;
        hasHappened = false;
        MeshRenderer rend = FullPipe.GetComponent<MeshRenderer>();
        string pathColor = PlayerPrefs.GetString("PathColor", "RedPath");
        Renderer groundRend = Ground.GetComponent<Renderer>();
        switch (PlayerPrefs.GetString("Theme", "WhiteBlackColor"))
        {
            case "WhiteBlackColor":
                rend.sharedMaterial.color = new Color((float)(41.0 / 255.0), (float)(24.0 / 255.0), (float)(24.0 / 255.0));
                cameraa.backgroundColor = Color.white;
                groundRend.material.color = Color.red;
                Cube.color = new Color((float)(231.0 / 255.0), (float)(16.0 / 255.0), (float)(16.0 / 255.0));
                Tube.color = new Color((float)(77.0 / 255.0), (float)(72.0 / 255.0), (float)(72.0 / 255.0));
                HighScore.color = Color.black;
                Score.color = Color.gray;
                TapToStart.color = Color.black;
                RenderSettings.fogColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                ColorBlock cb = leftButton.colors;
                cb.normalColor = new Color((float)(0.0 / 255.0), (float)(0.0 / 255.0), (float)(0.0 / 255.0), 120.0f / 255.0f);
                leftButton.colors = cb;
                rightButton.colors = cb;  //default button color
                jumpButton.colors = cb;
                ColorBlock cb2 = restart.colors;
                cb2.normalColor = Color.red;
                restart.colors = cb2;
                ColorBlock cb3 = navButton.colors;
                cb3.normalColor = new Color((float)(130.0 / 255.0), (float)(117.0 / 255.0), (float)(96.0 / 255.0), 255.0f / 255.0f);
                navButton.colors = cb3;
                videoButton.colors = cb3;


                leftButton.GetComponent<Image>().color = new Color((float)(0.0 / 255.0), (float)(0.0 / 255.0), (float)(0.0 / 255.0), 140.0f / 255.0f); //clicked Button color
                rightButton.GetComponent<Image>().color = new Color((float)(0.0 / 255.0), (float)(0.0 / 255.0), (float)(0.0 / 255.0), 140.0f / 255.0f);
                jumpButton.GetComponent<Image>().color = new Color((float)(0.0 / 255.0), (float)(0.0 / 255.0), (float)(0.0 / 255.0), 140.0f / 255.0f);
                restart.GetComponent<Image>().color = Color.red;
                arrow.GetComponent<RawImage>().color = Color.red; //arrowIndicatorColor
                gameOver.GetComponent<Text>().color = Color.black; //gameOver Text
                gameOverScreen.GetComponent<Image>().color = Color.white; //background of GameoVerScreen
                endScore.GetComponent<Text>().color = Color.black;
                endScoreLabel.GetComponent<Text>().color = Color.black;
                break;
            case "BlackWhiteColor":
                rend.sharedMaterial.color = Color.white; //TubeColor
                cameraa.backgroundColor = Color.black; //backgroundCOlor
                groundRend.material.color = Color.blue; //groundCoolor
                Cube.color = Color.blue;
                Tube.color = Color.white;
                HighScore.color = Color.white;
                Score.color = Color.white;
                TapToStart.color = Color.black;
                RenderSettings.fogColor = Color.black;
                cb = leftButton.colors;
                cb.normalColor = new Color((float)(255.0 / 255.0), (float)(255.0 / 255.0), (float)(255.0 / 255.0), 0.6f);
                leftButton.colors = cb;
                rightButton.colors = cb;  //default button color
                jumpButton.colors = cb;
                cb2 = restart.colors;
                cb2.normalColor = new Color((float)(255.0 / 255.0), (float)(255.0 / 255.0), (float)(255.0 / 255.0));
                cb2.highlightedColor = new Color((float)(255.0 / 255.0), (float)(255.0 / 255.0), (float)(255.0 / 255.0), 1f);
                cb2.pressedColor = new Color((float)(255.0 / 255.0), (float)(255.0 / 255.0), (float)(255.0 / 255.0), 1f); 
                cb2.selectedColor = new Color((float)(255.0 / 255.0), (float)(255.0 / 255.0), (float)(255.0 / 255.0), 1f);
                restart.colors = cb2;
                navButton.colors = cb2;
                videoButton.colors = cb2;

                leftButton.GetComponent<Image>().color = new Color((float)(240.0 / 255.0), (float)(127.0 / 255.0), (float)(136.0 / 255.0));
                rightButton.GetComponent<Image>().color = new Color((float)(240.0 / 255.0), (float)(127.0 / 255.0), (float)(136.0 / 255.0));
                jumpButton.GetComponent<Image>().color = new Color((float)(240.0 / 255.0), (float)(127.0 / 255.0), (float)(136.0 / 255.0));
                restart.GetComponent<Image>().color = Color.cyan;
                arrow.GetComponent<RawImage>().color = Color.white; //arrowIndicatorColor
                gameOver.GetComponent<Text>().color = Color.white; //gameOver Text
                gameOverScreen.GetComponent<Image>().color = Color.black;
                endScore.GetComponent<Text>().color = Color.white;
                endScoreLabel.GetComponent<Text>().color = Color.white;
                break;
            case "BlueYellowColor":
                rend.sharedMaterial.color = new Color((float)(202.0 / 255.0), (float)(224.0 / 255.0), (float)(119.0 / 255.0)); //TubeColor
                cameraa.backgroundColor = new Color((float)(119.0 / 255.0), (float)(144.0 / 255.0), (float)(224.0 / 255.0), 0.5f); //backgroundCOlor
                groundRend.material.color = new Color((float)(247.0 / 255.0), (float)(184.0 / 255.0), (float)(25.0 / 255.0)); //groundCoolor
                Cube.color = Color.yellow;
                Tube.color = Color.yellow;
                HighScore.color = Color.yellow;
                Score.color = Color.yellow;
                TapToStart.color = Color.yellow;
                RenderSettings.fogColor = new Color((float)(119.0 / 255.0), (float)(144.0 / 255.0), (float)(224.0 / 255.0), 1.0f);
                cb = leftButton.colors;
                cb.normalColor = new Color((float)(0.0 / 255.0), (float)(72.0 / 255.0), (float)(217.0 / 255.0), 0.4f);
                leftButton.colors = cb;
                rightButton.colors = cb;  //default button color
                jumpButton.colors = cb;
                cb2 = restart.colors;
                cb2.normalColor = Color.yellow;
                cb2.highlightedColor = Color.yellow;
                cb2.normalColor = Color.yellow;
                cb2.selectedColor = Color.yellow;
                restart.colors = cb2;
                navButton.colors = cb2;
                videoButton.colors = cb2;

                leftButton.GetComponent<Image>().color = new Color((float)(119.0 / 255.0), (float)(144.0 / 255.0), (float)(224.0 / 255.0));
                rightButton.GetComponent<Image>().color = new Color((float)(119.0 / 255.0), (float)(144.0 / 255.0), (float)(224.0 / 255.0));
                jumpButton.GetComponent<Image>().color = new Color((float)(119.0 / 255.0), (float)(144.0 / 255.0), (float)(224.0 / 255.0));
                restart.GetComponent<Image>().color = Color.yellow;
                arrow.GetComponent<RawImage>().color = Color.yellow; //arrowIndicatorColor
                gameOver.GetComponent<Text>().color = Color.white; //gameOver Text
                gameOverScreen.GetComponent<Image>().color = new Color((float)(119.0 / 255.0), (float)(144.0 / 255.0), (float)(224.0 / 255.0)); //background of GameoVerScreen
                endScore.GetComponent<Text>().color = Color.white;
                endScoreLabel.GetComponent<Text>().color = Color.white;
                break;
            case "GreenRedColor":
                rend.sharedMaterial.color = new Color((float)(127.0 / 255.0), (float)(153.0 / 255.0), (float)(240.0 / 255.0)); //TubeColor
                cameraa.backgroundColor = new Color((float)(240.0 / 255.0), (float)(127.0 / 255.0), (float)(127.0 / 255.0)); //backgroundCOlor
                groundRend.material.color = new Color((float)(20.0 / 255.0), (float)(163.0 / 255.0), (float)(70.0 / 255.0)); //groundCoolor
                Cube.color = Color.white;
                Tube.color = Color.white;
                HighScore.color = Color.white;
                Score.color = Color.white;
                TapToStart.color = Color.black;
                RenderSettings.fogColor = new Color((float)(240.0 / 255.0), (float)(127.0 / 255.0), (float)(127.0 / 255.0));
                cb = leftButton.colors;
                cb.normalColor = new Color((float)(0.0 / 255.0), (float)(72.0 / 255.0), (float)(217.0 / 255.0), 0.4f);
                leftButton.colors = cb;
                rightButton.colors = cb;  //default button color
                jumpButton.colors = cb;
                cb2 = restart.colors;
                cb2.normalColor = new Color((float)(20.0 / 255.0), (float)(163.0 / 255.0), (float)(70.0 / 255.0));
                cb2.pressedColor = new Color((float)(20.0 / 255.0), (float)(163.0 / 255.0), (float)(70.0 / 255.0)); ;
                cb2.highlightedColor = new Color((float)(20.0 / 255.0), (float)(163.0 / 255.0), (float)(70.0 / 255.0));
                cb2.selectedColor = cb2.normalColor;
                restart.colors = cb2;
                navButton.colors = cb2;
                videoButton.colors = cb2;

                leftButton.GetComponent<Image>().color = new Color((float)(240.0 / 255.0), (float)(127.0 / 255.0), (float)(136.0 / 255.0));
                rightButton.GetComponent<Image>().color = new Color((float)(240.0 / 255.0), (float)(127.0 / 255.0), (float)(136.0 / 255.0));
                jumpButton.GetComponent<Image>().color = new Color((float)(240.0 / 255.0), (float)(127.0 / 255.0), (float)(136.0 / 255.0));
                restart.GetComponent<Image>().color = Color.cyan;
                arrow.GetComponent<RawImage>().color = Color.cyan; //arrowIndicatorColor
                gameOver.GetComponent<Text>().color = Color.white; //gameOver Text
                gameOverScreen.GetComponent<Image>().color = new Color((float)(240.0 / 255.0), (float)(127.0 / 255.0), (float)(127.0 / 255.0));
                endScore.GetComponent<Text>().color = Color.white;
                endScoreLabel.GetComponent<Text>().color = Color.white;
                break;
            case "PinkPurpleColor":
                rend.sharedMaterial.color = new Color((float)(153.0 / 255.0), (float)(8.0 / 255.0), (float)(148.0 / 255.0)); //tube
                cameraa.backgroundColor = new Color((float)(240.0 / 255.0), (float)(139.0 / 255.0), (float)(236.0 / 255.0));//bg
                groundRend.material.color = new Color((float)(247.0 / 255.0), (float)(200.0 / 255.0), (float)(246.0 / 255.0)); //ground
                Cube.color = Color.red;
                Tube.color = Color.white;
                HighScore.color = Color.white;
                Score.color = Color.white;
                TapToStart.color = Color.black;
                RenderSettings.fogColor = new Color((float)(240.0 / 255.0), (float)(139.0 / 255.0), (float)(236.0 / 255.0));
                cb = leftButton.colors;
                cb.normalColor = new Color((float)(255.0 / 255.0), (float)(255.0 / 255.0), (float)(255.0 / 255.0), 0.6f);
                leftButton.colors = cb;
                rightButton.colors = cb;  //default button color
                jumpButton.colors = cb;
                cb2 = restart.colors;
                cb2.normalColor = new Color((float)(179.0 / 255.0), (float)(20.0 / 255.0), (float)(38.0 / 255.0));
                cb2.highlightedColor = new Color((float)(179.0 / 255.0), (float)(20.0 / 255.0), (float)(38.0 / 255.0));
                cb2.normalColor = new Color((float)(179.0 / 255.0), (float)(20.0 / 255.0), (float)(38.0 / 255.0));
                cb2.selectedColor = cb2.normalColor;
                restart.colors = cb2;
                navButton.colors = cb2;
                videoButton.colors = cb2;

                leftButton.GetComponent<Image>().color = new Color((float)(240.0 / 255.0), (float)(127.0 / 255.0), (float)(136.0 / 255.0));
                rightButton.GetComponent<Image>().color = new Color((float)(240.0 / 255.0), (float)(127.0 / 255.0), (float)(136.0 / 255.0));
                jumpButton.GetComponent<Image>().color = new Color((float)(240.0 / 255.0), (float)(127.0 / 255.0), (float)(136.0 / 255.0));
                restart.GetComponent<Image>().color = Color.red;
                arrow.GetComponent<RawImage>().color = Color.red; //arrowIndicatorColor
                gameOver.GetComponent<Text>().color = Color.white; //gameOver Text
                gameOverScreen.GetComponent<Image>().color =  new Color((float)(240.0 / 255.0), (float)(139.0 / 255.0), (float)(236.0 / 255.0));
                endScore.GetComponent<Text>().color = Color.white;
                endScoreLabel.GetComponent<Text>().color = Color.white;
                break;
            case "GreenGreenColor":
                rend.sharedMaterial.color = new Color((float)(194.0 / 255.0), (float)(117.0 / 255.0), (float)(12.0 / 255.0)); //TubeColor
                cameraa.backgroundColor = new Color((float)(0.0 / 255.0), (float)(77.0 / 255.0), (float)(0.0 / 255.0)); //backgroundCOlor
                groundRend.material.color = new Color((float)(0.0 / 255.0), (float)(72.0 / 255.0), (float)(0.0 / 255.0)); //groundCoolor
                Cube.color = Color.green;
                Tube.color = Color.green;
                HighScore.color = Color.white;
                Score.color = Color.white;
                TapToStart.color = Color.black;
                RenderSettings.fogColor = new Color(0, 0.5f, 0.5f, 0.5f);
                cb = leftButton.colors;
                cb.normalColor = new Color((float)(194.0 / 255.0), (float)(117.0 / 255.0), (float)(12.0 / 255.0));
                leftButton.colors = cb;
                rightButton.colors = cb;  //default button color
                jumpButton.colors = cb;
                restart.colors = cb;
                cb2 = restart.colors;
                cb2.normalColor = new Color((float)(194.0 / 255.0), (float)(117.0 / 255.0), (float)(12.0 / 255.0)); 
                cb2.highlightedColor = new Color((float)(194.0 / 255.0), (float)(117.0 / 255.0), (float)(12.0 / 255.0));
                cb2.pressedColor = new Color((float)(194.0 / 255.0), (float)(117.0 / 255.0), (float)(12.0 / 255.0));
                cb2.selectedColor = cb2.normalColor;
                navButton.colors = cb2;
                videoButton.colors = cb2;

                leftButton.GetComponent<Image>().color = Color.red; //clicked Button color
                rightButton.GetComponent<Image>().color = Color.red;
                jumpButton.GetComponent<Image>().color = Color.red;
                restart.GetComponent<Image>().color = Color.red;
                arrow.GetComponent<RawImage>().color = new Color((float)(194.0 / 255.0), (float)(117.0 / 255.0), (float)(12.0 / 255.0), 1.0f); //arrowIndicatorColor
                gameOver.GetComponent<Text>().color = Color.white; //gameOver Text
                gameOverScreen.GetComponent<Image>().color = new Color((float)(0.0 / 255.0), (float)(77.0 / 255.0), (float)(0.0 / 255.0)); //background of GameoVerScreen
                endScore.GetComponent<Text>().color = Color.white;
                endScoreLabel.GetComponent<Text>().color = Color.white;
                break;
            case "YellowYellowColor":
                rend.sharedMaterial.color = new Color((float)(76.0 / 255.0), (float)(70.0 / 255.0), (float)(50.0 / 255.0), 0.5f); //TubeColor
                cameraa.backgroundColor = new Color((float)(204.0 / 255.0), (float)(186.0 / 255.0), (float)(137.0 / 255.0)); //backgroundCOlor
                groundRend.material.color = new Color((float)(140.0 / 255.0), (float)(128.0 / 255.0), (float)(93.0 / 255.0)); //groundCoolor
                Cube.color = new Color((float)(235.0 / 255.0), (float)(220.0 / 255.0), (float)(178.0 / 255.0));
                Tube.color = new Color((float)(61.0 / 255.0), (float)(55.0 / 255.0), (float)(37.0 / 255.0));
                HighScore.color = Color.white;
                Score.color = Color.white;
                TapToStart.color = Color.black;
                RenderSettings.fogColor = new Color((float)(204.0 / 255.0), (float)(186.0 / 255.0), (float)(137.0 / 255.0), 0.5f);
                cb = leftButton.colors;
                cb.normalColor = new Color((float)(140.0 / 255.0), (float)(128.0 / 255.0), (float)(93.0 / 255.0), 0.4f);
                leftButton.colors = cb;
                rightButton.colors = cb;  //default button color
                jumpButton.colors = cb;
                cb2 = restart.colors;
                cb2.normalColor = new Color((float)(140.0 / 255.0), (float)(128.0 / 255.0), (float)(93.0 / 255.0));
                cb2.highlightedColor= new Color((float)(140.0 / 255.0), (float)(128.0 / 255.0), (float)(93.0 / 255.0));
                cb2.pressedColor = new Color((float)(140.0 / 255.0), (float)(128.0 / 255.0), (float)(93.0 / 255.0));
                cb2.selectedColor = cb2.normalColor;
                restart.colors = cb2;
                navButton.colors = cb2;
                videoButton.colors = cb2;

                leftButton.GetComponent<Image>().color = new Color((float)(61.0 / 255.0), (float)(55.0 / 255.0), (float)(37.0 / 255.0));
                rightButton.GetComponent<Image>().color = new Color((float)(61.0 / 255.0), (float)(55.0 / 255.0), (float)(37.0 / 255.0));
                jumpButton.GetComponent<Image>().color = new Color((float)(61.0 / 255.0), (float)(55.0 / 255.0), (float)(37.0 / 255.0));
                restart.GetComponent<Image>().color = new Color((float)(61.0 / 255.0), (float)(55.0 / 255.0), (float)(37.0 / 255.0));
                arrow.GetComponent<RawImage>().color = new Color((float)(76.0 / 255.0), (float)(70.0 / 255.0), (float)(50.0 / 255.0), 0.5f); ; //arrowIndicatorColor
                gameOver.GetComponent<Text>().color = Color.white; //gameOver Text
                gameOverScreen.GetComponent<Image>().color = new Color((float)(204.0 / 255.0), (float)(186.0 / 255.0), (float)(137.0 / 255.0));  //background of GameoVerScreen
                endScore.GetComponent<Text>().color = Color.white;
                endScoreLabel.GetComponent<Text>().color = Color.white;
                break;
            case "OrangeRedColor":
                rend.sharedMaterial.color = Color.red; //TubeColor
                cameraa.backgroundColor = new Color((float)(245.0 / 255.0), (float)(163.0 / 255.0), (float)(10.0 / 255.0), 0.5f); //backgroundCOlor
                groundRend.material.color = Color.yellow; //groundCoolor
                Cube.color = Color.yellow;
                Tube.color = Color.yellow;
                HighScore.color = Color.yellow;
                Score.color = Color.yellow;
                TapToStart.color = Color.yellow;
                RenderSettings.fogColor = new Color((float)(245.0 / 255.0), (float)(163.0 / 255.0), (float)(10.0 / 255.0), 0.5f);
                cb = leftButton.colors;
                cb.normalColor = new Color((float)(0.0 / 255.0), (float)(72.0 / 255.0), (float)(217.0 / 255.0), 0.4f);
                leftButton.colors = cb;
                rightButton.colors = cb;  //default button color
                jumpButton.colors = cb;
                cb2 = restart.colors;
                cb2.normalColor = Color.yellow;
                cb2.highlightedColor = Color.yellow;
                cb2.pressedColor = Color.yellow;
                cb2.selectedColor = Color.yellow; 
                restart.colors = cb2;
                navButton.colors = cb2;
                videoButton.colors = cb2;

                leftButton.GetComponent<Image>().color = new Color((float)(119.0 / 255.0), (float)(144.0 / 255.0), (float)(224.0 / 255.0));
                rightButton.GetComponent<Image>().color = new Color((float)(119.0 / 255.0), (float)(144.0 / 255.0), (float)(224.0 / 255.0));
                jumpButton.GetComponent<Image>().color = new Color((float)(119.0 / 255.0), (float)(144.0 / 255.0), (float)(224.0 / 255.0));
                restart.GetComponent<Image>().color = Color.yellow;
                arrow.GetComponent<RawImage>().color = Color.yellow; //arrowIndicatorColor
                gameOver.GetComponent<Text>().color = Color.white; //gameOver Text
                gameOverScreen.GetComponent<Image>().color = Color.red; //background of GameoVerScreen
                endScore.GetComponent<Text>().color = Color.white;
                endScoreLabel.GetComponent<Text>().color = Color.white;
                break;
            default:
                rend.sharedMaterial.color = new Color((float)(41.0 / 255.0), (float)(24.0 / 255.0), (float)(24.0 / 255.0));
                rend.material.color = Color.black;
                cameraa.backgroundColor = Color.white;
                groundRend.material.color = Color.red;
                Cube.color = new Color((float)(231.0 / 255.0), (float)(16.0 / 255.0), (float)(16.0 / 255.0));
                Tube.color = new Color((float)(77.0 / 255.0), (float)(72.0 / 255.0), (float)(72.0 / 255.0));
                HighScore.color = Color.black;
                Score.color = Color.gray;
                TapToStart.color = Color.black;
                RenderSettings.fogColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                cb = leftButton.colors;
                cb.normalColor = new Color((float)(0.0 / 255.0), (float)(0.0 / 255.0), (float)(0.0 / 255.0), 120.0f / 255.0f);
                leftButton.colors = cb;
                rightButton.colors = cb;  //default button color
                jumpButton.colors = cb;
                cb2 = restart.colors;
                cb2.normalColor = Color.red;
                restart.colors = cb2;
                cb3 = navButton.colors;
                cb3.normalColor = new Color((float)(130.0 / 255.0), (float)(117.0 / 255.0), (float)(96.0 / 255.0), 255.0f / 255.0f);
                navButton.colors = cb3;
                videoButton.colors = cb3;

                leftButton.GetComponent<Image>().color = new Color((float)(0.0 / 255.0), (float)(0.0 / 255.0), (float)(0.0 / 255.0), 140.0f / 255.0f); //clicked Button color
                rightButton.GetComponent<Image>().color = new Color((float)(0.0 / 255.0), (float)(0.0 / 255.0), (float)(0.0 / 255.0), 140.0f / 255.0f);
                jumpButton.GetComponent<Image>().color = new Color((float)(0.0 / 255.0), (float)(0.0 / 255.0), (float)(0.0 / 255.0), 140.0f / 255.0f);
                restart.GetComponent<Image>().color = Color.red;
                arrow.GetComponent<RawImage>().color = Color.red; //arrowIndicatorColor
                gameOver.GetComponent<Text>().color = Color.black; //gameOver Text
                gameOverScreen.GetComponent<Image>().color = Color.white; //background of GameoVerScreen
                endScore.GetComponent<Text>().color = Color.black;
                endScoreLabel.GetComponent<Text>().color = Color.black;
                break;

        }
        switch (pathColor)
        {
            case "RedPath":
                groundRend.material.color = Color.red;
                break;
            case "WhitePath":
                groundRend.material.color = Color.white;
                break;
            case "BluePath":
                groundRend.material.color = Color.blue;
                break;
            case "YellowPath":
                groundRend.material.color = Color.yellow;
                break;
            case "GreenPath":
                groundRend.material.color = Color.green;
                break;
            case "PurplePath":
                groundRend.material.color = new Color((float)(153.0 / 255.0), (float)(8.0 / 255.0), (float)(148.0 / 255.0));
                break;
            case "OrangePath":
                groundRend.material.color = new Color((float)(245.0 / 255.0), (float)(163.0 / 255.0), (float)(10.0 / 255.0));
                break;
            case "PinkPath":
                groundRend.material.color = new Color((float)(240.0 / 255.0), (float)(139.0 / 255.0), (float)(236.0 / 255.0));
                break;
            default:
                groundRend.material.color = Color.red;
                break;
        }
    }

    GameObject decide()
    {
        //this is a systm that gives you harder tubes as you progress in the game based on your score
        int z = (int)Random.Range(1, 15.99999999f);
        z = z - 9;
        int y = int.Parse(Score.text);
        y = y / 40000;
        z = z + y;
        if (z > 24)
            z = (int)Random.Range(1, 15.99999999f);

        if (z == 1)
            return LowLeftPrefab;
        else if (z == 2)
            return LowMiddlePrefab;
        else if (z == 3)
            return LowRightPrefab;
        else if (z == 4)
            return HighRightPrefab;
        else if (z == 5)
            return HighMiddlePrefab;
        else if (z == 6)
            return HighLeftPrefab;
        else if (z == 7)
            return RightVertWall;
        else if (z == 8)
            return MiddleVertWall;
        else if (z == 9)
            return LeftVertWall;
        else if (z == 10)
            return LowLeftWallHorz;
        else if (z == 11)
            return LowMiddleWallHorz;
        else if (z == 12)
            return LowRightWallHorz;
        else if (z == 13)
            return HighRightWallHorz;
        else if (z == 14)
            return HighLeftWallHorz;
        else if (z == 15)
            return HighMiddleWallHorz;
        else
        {
            z = (int)Random.Range(1, 6.9999999f);
            if (z == 1)
                return LowLeftPrefab;
            else if (z == 2)
                return LowMiddlePrefab;
            else if (z == 3)
                return LowRightPrefab;
            else if (z == 4)
                return HighRightPrefab;
            else if (z == 5)
                return HighMiddlePrefab;
            else if (z == 6)
                return HighLeftPrefab;
            else
                return LowLeftPrefab;
        }


    }
    private void spawnObstacle()
    {
        GameObject lol = decide();
        GameObject a = Instantiate(lol) as GameObject;
        if (lol == LowLeftPrefab || lol == LowLeftWallHorz)
            a.transform.position = new Vector3(-5.2f, 38.14545f, 170);
        else if (lol == LowMiddlePrefab || lol == LowMiddleWallHorz)
            a.transform.position = new Vector3(-4.61f, 38.14545f, 170);
        else if (lol == LowRightPrefab || lol == LowRightWallHorz)
            a.transform.position = new Vector3(5.4f, 38.14545f, 170);
        else if (lol == HighLeftPrefab || lol == HighLeftWallHorz)
            a.transform.position = new Vector3(-5, 43, 170);
        else if (lol == HighRightPrefab || lol == HighRightWallHorz)
            a.transform.position = new Vector3(-5, 43, 170);
        else if(lol == HighMiddlePrefab || lol == HighMiddleWallHorz )
            a.transform.position = new Vector3(-5, 43, 170);
        else if(lol == RightVertWall)
            a.transform.position = new Vector3(-5, 43, 170);
        else if (lol == MiddleVertWall)
            a.transform.position = new Vector3(-5, 43, 170);
        else if (lol == LeftVertWall)
            a.transform.position = new Vector3(-5, 43, 170);
        





    }

    IEnumerator wallWave()
    {
        while (true) //boolean ready to start
        {
            yield return new WaitForSeconds(respawnTime);
            spawnObstacle();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s") || controlmanager.getJumpClicked() == true)
        {
            gameStart = true;
        }
        if (gameStart == true && hasHappened == false)
        {
            StartCoroutine(wallWave());
            hasHappened = true;
         }
    }


    void OnEnable()
    {
        restartButton.onClick.AddListener(MyFunction2);
        restart.onClick.AddListener(MyFunction);//adds a listener for when you click the button

    }

    void MyFunction2()  //for the restart pause button (VERY IMPORTANT for handling)
    {
        StopAllCoroutines();
        gameStart = false;
        hasHappened = false;
        DestroyAllOther();
        p.velocity = Vector3.zero;
        p.rotation = new Quaternion(0, 0, 0, 0);
        p.useGravity = false;
        player.position = Vector3.zero;
        scoreGetter.GetComponent<Rigidbody>().isKinematic = true;
        scoregetter2.enabled = false;
        pause.GetComponent<Pause>().switchPauseState();
        pause.GetComponent<Animator>().Play("pauseOut");
        score.GetComponent<Animator>().Play("score gone");
        scoreGetter.GetComponent<Rigidbody>().isKinematic = false;
        background.Stop();
        PlayerMovement.setY(false);


    }



    void MyFunction()// your listener calls this function
    {
        StopAllCoroutines();
        gameStart = false;
        hasHappened = false;
        DestroyAllOther();
        p.velocity = Vector3.zero;
        p.rotation = new Quaternion(0, 0, 0, 0);
        p.useGravity = false;
        player.position = Vector3.zero;
      


    }

    public void DestroyAllOther()
    {
        GameObject[] others = GameObject.FindGameObjectsWithTag("obstacle"); //Get array of 
                                                                                //all possible objects with a given tag.
        foreach (GameObject go in others)
        { //Get all of those objects so we can check them..
          //As long as the gameObject we're checking isn't ours..
           
         
                Destroy(go);
           
        }
    }




}




