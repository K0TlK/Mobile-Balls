using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAlignment : MonoBehaviour
{
    private void FixedUpdate()
    {
        Debug.Log(Quaternion.identity);
        if (transform.rotation != Quaternion.identity)
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
