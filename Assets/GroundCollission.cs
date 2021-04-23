using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollission : MonoBehaviour
{

    private void Update()
    {
        Physics.IgnoreLayerCollision(8, 9);
    }


}
