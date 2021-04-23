using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class TutorialMovement : MonoBehaviour
{
    public Rigidbody player;
    public float turnVelocity;
    public float jumpVelocity;
    private static bool jumpButtonPressed = false;
    private static bool leftRightButtonsPressed = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player.AddForce(CrossPlatformInputManager.GetAxis("Horizontal") * turnVelocity * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        if (Input.GetKey("a"))
            player.AddForce(-turnVelocity * 0.1f * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        if (Input.GetKey("d"))
            player.AddForce(turnVelocity * 0.1f * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        if (Input.GetKey("s"))
            jump();
    }

    public void move()
    {
        leftRightButtonsPressed = true;
    }


    public void jump()
    {
        player.AddForce(0, jumpVelocity * Time.deltaTime, 0, ForceMode.VelocityChange);
        jumpButtonPressed = true;
    }

    public static bool getLeftRightButtonsPressed()
    {
        return leftRightButtonsPressed;
    }

    public static void setLeftRightButtonsPressed(bool a)
    {
        leftRightButtonsPressed = a;
    }

    public static bool getJumpButtonPressed()
    {
        return jumpButtonPressed;
    }

    public static void setJumpButtonPressed(bool a)
    {
        jumpButtonPressed = a;
    }
}
