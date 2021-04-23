using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Vector3 offset;
    public float smoothSpeed = 0.125f;

    void Start()
    {
        player = GameObject.Find("Player");
        offset = new Vector3(0, 2, -13);
    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.y <= -8)
        { 
            Vector3 intendedPos = new Vector3(0, player.transform.position.y, player.transform.position.z) + offset;
            this.transform.position = Vector3.Slerp(this.transform.position, intendedPos, Time.deltaTime * 2);
        }
       
    }

    private void LateUpdate()
    {
        if (player.transform.position.y > -8)
        {
            Vector3 desiredPosition = player.transform.position + offset;
            Vector3 pos = new Vector3(0, 2, desiredPosition.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, pos, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
