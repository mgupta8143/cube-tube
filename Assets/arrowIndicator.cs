using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowIndicator : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
    public Camera camera;
    private Vector3 playerPos;
    private Vector3 pointerPos;
    private Animator arrowAnim;
    private bool played;
    
    void Start()
    {
        played = false;
        arrowAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = camera.WorldToViewportPoint(player.transform.position);
        pointerPos = camera.WorldToViewportPoint(this.transform.position);

       
        if ((playerPos.x > 0 && playerPos.x < 1) && playerPos.y > 1)
        {
            Quaternion target = Quaternion.Euler(0, 0, 270);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 10);
            if (!played)
            {
                arrowAnim.Play("arrow");
                played = true;
            }
            pointerPos.x = playerPos.x;
            pointerPos.y = 0.95f;
            this.transform.position = camera.ViewportToWorldPoint(pointerPos);
        }

        if (playerPos.x > 0 && playerPos.x < 1 && playerPos.y > 0 && playerPos.y < 1)
        {
            if (played)
            {
                arrowAnim.Play("arrowGone");
                played = false;
            }
        }
    }
}
