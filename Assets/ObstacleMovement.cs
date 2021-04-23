using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class ObstacleMovement : MonoBehaviour
{

    public Rigidbody obstacle;
    public float playerVelocity = 1f;
    private Vector3 screenBounds;
    bool gameStart = false;
    public Button restart;
    public GameObject player;

    

    // Update is called once per frame

    private void Start()
    {
        obstacle = this.GetComponent<Rigidbody>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        gameStart = false;
    }

    void FixedUpdate()
    {
        if (Input.GetKey("s"))
            gameStart = true;


        if(Score2.getCurrentScore() < 100000)
            obstacle.AddForce(0, 0, -(playerVelocity) * Time.deltaTime, ForceMode.VelocityChange);
        else if(Score2.getCurrentScore() < 200000)
            obstacle.AddForce(0, 0, -(playerVelocity + 0.25f) * Time.deltaTime, ForceMode.VelocityChange);
        else if (Score2.getCurrentScore() < 500000)
            obstacle.AddForce(0, 0, -(playerVelocity + 0.5f) * Time.deltaTime, ForceMode.VelocityChange);
        else if (Score2.getCurrentScore() < 700000)
            obstacle.AddForce(0, 0, -(playerVelocity + 0.75f) * Time.deltaTime, ForceMode.VelocityChange);
        else if (Score2.getCurrentScore() < 1200000)
            obstacle.AddForce(0, 0, -(playerVelocity + 1f) * Time.deltaTime, ForceMode.VelocityChange);
        else if (Score2.getCurrentScore() < 1800000)
            obstacle.AddForce(0, 0, -(playerVelocity + 1.5f) * Time.deltaTime, ForceMode.VelocityChange);
        else if (Score2.getCurrentScore() < 2500000)
            obstacle.AddForce(0, 0, -(playerVelocity + 2f) * Time.deltaTime, ForceMode.VelocityChange);
        else if (Score2.getCurrentScore() < 4000000)
            obstacle.AddForce(0, 0, -(playerVelocity + 2.5f) * Time.deltaTime, ForceMode.VelocityChange);
        else if (Score2.getCurrentScore() < 5000000)
            obstacle.AddForce(0, 0, -(playerVelocity + 3f) * Time.deltaTime, ForceMode.VelocityChange);


        if (this.name != "Score Getter" && transform.position.z < -50)
            Destroy(this.gameObject);

       
    }

    
}
