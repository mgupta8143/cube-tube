using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlmanager : MonoBehaviour
{

    public static bool leftClicked = false, rightClicked = false, jumpClicked = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void wrapperJump()
    {
        clickJump();
    }

    public void wrapperLeft()
    {
        clickLeft();
    }

    public void wrapperRight()
    {
        clickRight();
    }

    public static void clickLeft()
    {
        leftClicked = true;
    }

    public static void clickRight()
    {
        rightClicked = true;
    }

    public static void clickJump()
    {
        jumpClicked = true;
    }

    public static bool getLeftClicked()
    {
        return leftClicked;
    }

    public static bool getRightClicked()
    {
        return rightClicked;
    }

    public static bool getJumpClicked()
    {
        return jumpClicked;
    }

    public static void setLeftClicked(bool a)
    {
        leftClicked = a;
    }

    public static void setRightClicked(bool a)
    {
        rightClicked = a;
    }

    public static void setJumpClicked(bool a)
    {
        jumpClicked = a;
    }
}
