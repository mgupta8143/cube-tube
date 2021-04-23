using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public Material white, red, blue, yellow, green, purple, gold, silver, bronze, orange, pink, black, gray, cyan, brown;
    public Transform p;
    public Rigidbody player;
    public float turnVelocity;
    public float jumpVelocity;
    public AudioSource audio;
    public AudioSource background;
    bool x = false;
    static bool y = false;
    static bool gameStart = false;
    public Text HighScore;
    public Mesh turtle, cube, sphere, bird, plane, xo, head, batman;
    public GameObject scoreGetter;
    public static GameObject playerObj;
    public static GameObject playerPath;
    public Button navButton;
    Animator navButtonanim;
    Renderer rend, pathRend;
    public static bool navbarOut = false;
    public static bool roundStart = false;
    static bool tiltControls;
    public GameObject leftButton, rightButton;

 
    private void Start()
    {
        navButtonanim = navButton.GetComponent<Animator>();
        playerObj = GameObject.Find("Player");
        playerPath = GameObject.Find("Ground");
        pathRend = playerPath.GetComponent<Renderer>();
        HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        rend = playerObj.GetComponent<Renderer>();
        TrailRenderer trailrend = playerObj.GetComponent<TrailRenderer>();
        string color = PlayerPrefs.GetString("PlayerColor", "White");
        string shape = PlayerPrefs.GetString("PlayerShape", "CubeShape");
        string pathColor = PlayerPrefs.GetString("PathColor", "RedPath");
        string trailColor = PlayerPrefs.GetString("Trail", "RedTrail");

        switch(trailColor)
        {
            case "RedTrail":
                GameObject.Find("RedTrail").GetComponent<TrailRenderer>().enabled = true;
                GameObject.Find("BlackTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("YellowTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("BlueTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("OrangeTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("GreenTrail").GetComponent<TrailRenderer>().enabled = false ;
                GameObject.Find("PurpleTrail").GetComponent<TrailRenderer>().enabled = false ;
                GameObject.Find("PinkTrail").GetComponent<TrailRenderer>().enabled = false ;
                break;
            case "BlackTrail":
                GameObject.Find("RedTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("BlackTrail").GetComponent<TrailRenderer>().enabled = true;
                GameObject.Find("YellowTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("BlueTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("OrangeTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("GreenTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("PurpleTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("PinkTrail").GetComponent<TrailRenderer>().enabled = false;
                break;
            case "BlueTrail":
                GameObject.Find("RedTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("BlackTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("YellowTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("BlueTrail").GetComponent<TrailRenderer>().enabled = true;
                GameObject.Find("OrangeTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("GreenTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("PurpleTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("PinkTrail").GetComponent<TrailRenderer>().enabled = false;
                break;
            case "YellowTrail":
                GameObject.Find("RedTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("BlackTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("YellowTrail").GetComponent<TrailRenderer>().enabled = true;
                GameObject.Find("BlueTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("OrangeTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("GreenTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("PurpleTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("PinkTrail").GetComponent<TrailRenderer>().enabled = false;
                break;
            case "OrangeTrail":
                GameObject.Find("RedTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("BlackTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("YellowTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("BlueTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("OrangeTrail").GetComponent<TrailRenderer>().enabled = true;
                GameObject.Find("GreenTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("PurpleTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("PinkTrail").GetComponent<TrailRenderer>().enabled = false;
                break;
            case "GreenTrail":
                GameObject.Find("RedTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("BlackTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("YellowTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("BlueTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("OrangeTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("GreenTrail").GetComponent<TrailRenderer>().enabled = true;
                GameObject.Find("PurpleTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("PinkTrail").GetComponent<TrailRenderer>().enabled = false;
                break;
            case "PurpleTrail":
                GameObject.Find("RedTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("BlackTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("YellowTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("BlueTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("OrangeTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("GreenTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("PurpleTrail").GetComponent<TrailRenderer>().enabled = true;
                GameObject.Find("PinkTrail").GetComponent<TrailRenderer>().enabled = false;
                break;
            case "PinkTrail":
                GameObject.Find("RedTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("BlackTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("YellowTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("BlueTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("OrangeTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("GreenTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("PurpleTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("PinkTrail").GetComponent<TrailRenderer>().enabled = true;
                break;
            default:
                GameObject.Find("RedTrail").GetComponent<TrailRenderer>().enabled = true;
                GameObject.Find("BlackTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("YellowTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("BlueTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("OrangeTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("GreenTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("PurpleTrail").GetComponent<TrailRenderer>().enabled = false;
                GameObject.Find("PinkTrail").GetComponent<TrailRenderer>().enabled = false;
                break;

        }

        //assiging the meshes
        switch (shape)
        {
            case "CubeShape":
                playerObj.GetComponent<MeshFilter>().mesh = cube;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case "SphereShape":
                playerObj.GetComponent<MeshFilter>().mesh = sphere;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case "BirdShape":
                playerObj.GetComponent<MeshFilter>().mesh = bird;
                transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                break;
            case "PlaneShape":
                playerObj.GetComponent<MeshFilter>().mesh = plane;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case "XShape":
                playerObj.GetComponent<MeshFilter>().mesh = xo;
                transform.localScale = new Vector3(2, 2, 2);
                break;
            case "TurtleShape":
                playerObj.GetComponent<MeshFilter>().mesh = turtle;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case "HeadShape":
                playerObj.GetComponent<MeshFilter>().mesh = head;
                transform.localScale = new Vector3(2, 2, 2);
                break;
            case "BatmanShape":
                playerObj.GetComponent<MeshFilter>().mesh = batman;
                transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            default:
                break;
        }



        //starts the player based on shop configs
        switch(color)
        {
            case "Red":
                rend.material = red;
                break;
            case "White":
                rend.material = white;
                break;
            case "Brown":
                rend.material = brown;
                break;
            case "Bronze":
                rend.material = bronze;
                break;
            case "Silver":
                rend.material = silver;
                break;
            case "Gold":
                rend.material = gold;
                break;
            case "Blue":
                rend.material = blue;
                break;
            case "Yellow":
                rend.material = yellow;
                break;
            case "Green":
                rend.material = green;
                break;
            case "Purple":
                rend.material = purple;
                break;
            case "Orange":
                rend.material = orange;
                break;
            case "Pink":
                rend.material = pink;
                break;
            case "Black":
                rend.material = black;
                break;
            case "Gray":
                rend.material = gray;
                break;
            case "Cyan":
                rend.material = cyan;
                break;

            default:
                rend.material = white;
                break;
        }

      
       

    }





    // Updateis called once per frame
    void FixedUpdate()
    {
        
        if (scoreGetter.name == "Score Getter")
        {
            if ((int)-scoreGetter.transform.position.z >= PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", (int)-scoreGetter.transform.position.z);
                HighScore.text = ((int)-scoreGetter.transform.position.z).ToString();
            }

        }

        

        if (gameStart == true)
            player.AddForce(CrossPlatformInputManager.GetAxis("Horizontal") * turnVelocity * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (Accelerometer.getTiltControls() == false)
        {
            leftButton.SetActive(true);
            rightButton.SetActive(true);
            if (gameStart == true && Input.GetKey("a"))
                player.AddForce(-turnVelocity*0.1f * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            if (gameStart == true && Input.GetKey("d"))
                player.AddForce(turnVelocity * 0.1f* Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        else
        {
            if (gameStart == true)
            {
                player.AddForce(Input.acceleration.x * 1.5f, 0, 0, ForceMode.VelocityChange);
                leftButton.SetActive(false);
                rightButton.SetActive(false);


            }
        }


        if (Input.GetKeyDown("s") || controlmanager.getJumpClicked() == true)
        {
            jump();

        }




        
        Physics.gravity = new Vector3(0, (p.position.y + 10) * -7, 0);
        if (gameStart == true && navbarOut == false && roundStart == true)
        {
            navButtonanim.Play("moveout");
            navbarOut = true;
            roundStart = false;
        }


    }

   




    public void jump()
    {
        player.useGravity = true;
        gameStart = true;
        x = true;
        if (player.useGravity == true)
            player.AddForce(0, jumpVelocity * Time.deltaTime, 0, ForceMode.VelocityChange);
        if (x == true)
            audio.Play();
        if (y == false)
        {
            background.Play();
            y = true;
        }
        x = false;
        controlmanager.setJumpClicked(false);
        roundStart = true;
    }

    public static void setY(bool a)
    {
        y = a;
    }

 
}
