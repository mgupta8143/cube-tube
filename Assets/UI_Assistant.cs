using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI_Assistant : MonoBehaviour
{
    private Text messageText;
    private GameObject jumpButton, leftButton, rightButton;
    private AudioSource talkingSound;

    private void Awake()
    {
        messageText = GameObject.Find("WelcomeText").GetComponent<Text>();
        jumpButton = GameObject.Find("Jump Button");
        leftButton = GameObject.Find("Left Button");
        rightButton = GameObject.Find("Right Button");
        talkingSound = GameObject.Find("TalkingSound").GetComponent<AudioSource>();

    }
    private void Start()
    {
        StartCoroutine(TutorialCoroutine());

    }

    IEnumerator TutorialCoroutine()
    {
        jumpButton.SetActive(false);
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        GameObject.Find("Player").GetComponent<Rigidbody>().useGravity = false;
        yield return new WaitForSeconds(1.2f);
        GameObject.Find("Player").GetComponent<Rigidbody>().useGravity = true;
        talkingSound.Play();
        TextWriter.AddWriter_Static(messageText, "Welcome to the Tutorial!", .05f, true, true);
        yield return new WaitForSeconds(.05f * "Welcome to the Tutorial".Length);
        talkingSound.Stop();
        yield return new WaitForSeconds(2f);
        TextWriter.AddWriter_Static(messageText, "Tap the Jump Button to Jump.", .05f, true, true);
        talkingSound.Play();
        yield return new WaitForSeconds(.05f * "Tap the Jump Button to Jump.".Length);
        talkingSound.Stop();
        jumpButton.SetActive(true);
        yield return new WaitUntil(TutorialMovement.getJumpButtonPressed);
        TutorialMovement.setJumpButtonPressed(false);
        TextWriter.AddWriter_Static(messageText, "Great! Keep tapping jump in midair to fly!", .05f, true, true);
        talkingSound.Play();
        yield return new WaitForSeconds(.05f * "Great! Keep tapping jump in midair to fly!".Length);
        talkingSound.Stop();
        yield return new WaitUntil(TutorialMovement.getJumpButtonPressed);
        TutorialMovement.setJumpButtonPressed(false);
        yield return new WaitUntil(TutorialMovement.getJumpButtonPressed);
        TutorialMovement.setJumpButtonPressed(false);
        talkingSound.Play();
        TextWriter.AddWriter_Static(messageText, "Amazing! Now try moving left and right!", .05f, true, true);
        yield return new WaitForSeconds(.05f * "Amazing! Now try moving left and right!".Length);
        talkingSound.Stop();
        rightButton.SetActive(true);
        leftButton.SetActive(true);
        yield return new WaitUntil(TutorialMovement.getLeftRightButtonsPressed);

        talkingSound.Play();
        TextWriter.AddWriter_Static(messageText, "Wow! Pro Tip: You can hold left and right to keep moving", .05f, true, true);
        yield return new WaitForSeconds(.05f * "Wow!Pro Tip: You can hold left and right to keep moving".Length);
        talkingSound.Stop();
        yield return new WaitForSeconds(2f);

        talkingSound.Play();
        TextWriter.AddWriter_Static(messageText, "With these three buttons you have...", .05f, true, true);
        yield return new WaitForSeconds(.05f * "With these three buttons you have...".Length);
        talkingSound.Stop();
        yield return new WaitForSeconds(2f);

        talkingSound.Play();
        TextWriter.AddWriter_Static(messageText, "FULL CONTROL OF THE CUBE.", .05f, true, true);
        yield return new WaitForSeconds(.05f * "FULL CONTROL OF THE CUBE.".Length);
        talkingSound.Stop();
        yield return new WaitForSeconds(2f);

        talkingSound.Play();
        TextWriter.AddWriter_Static(messageText, "Ever since the tubes started coming...", .05f, true, true);
        yield return new WaitForSeconds(.05f * "Ever since the tubes started coming".Length);
        talkingSound.Stop();
        yield return new WaitForSeconds(2f);

        talkingSound.Play();
        TextWriter.AddWriter_Static(messageText, "...all the cubes have been destroyed", .05f, true, true);
        yield return new WaitForSeconds(.05f * "all the cubes have been destroyed".Length);
        talkingSound.Stop();
        yield return new WaitForSeconds(2f);

        talkingSound.Play();
        TextWriter.AddWriter_Static(messageText, "As the last remaining cube...", .05f, true, true);
        yield return new WaitForSeconds(.05f * "As the last remaining cube".Length);
        talkingSound.Stop();
        yield return new WaitForSeconds(2f);

        talkingSound.Play();
        TextWriter.AddWriter_Static(messageText, "SURVIVE AS LONG AS POSSIBLE", .05f, true, true);
        yield return new WaitForSeconds(.05f * "SURVIVE AS LONG AS POSSIBLE".Length);
        talkingSound.Stop();
        yield return new WaitForSeconds(2f);

        talkingSound.Play();
        TextWriter.AddWriter_Static(messageText, "Collect coins to customimze your look", .05f, true, true);
        yield return new WaitForSeconds(.05f * "Collect coins to customimze your look".Length);
        talkingSound.Stop();
        yield return new WaitForSeconds(2f);

        talkingSound.Play();
        TextWriter.AddWriter_Static(messageText, "and compete with friends on the leaderboard", .05f, true, true);
        yield return new WaitForSeconds(.05f * "and compete with friends on the leaderboard".Length);
        talkingSound.Stop();
        yield return new WaitForSeconds(2f);

        talkingSound.Play();
        TextWriter.AddWriter_Static(messageText, "That's really it!", .05f, true, true);
        yield return new WaitForSeconds(.05f * "That's really it!".Length);
        talkingSound.Stop();
        yield return new WaitForSeconds(2f);

        talkingSound.Play();
        TextWriter.AddWriter_Static(messageText, "Now see for yourself in game!", .05f, true, true);
        yield return new WaitForSeconds(.05f * "Now see for yourself in game!".Length);
        talkingSound.Stop();
        yield return new WaitForSeconds(2f);

        GameObject.Find("Panel").GetComponent<Animator>().Play("startCirc");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene");



    }



}

