using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    private void FixedUpdate()
    {
        // keep upright
        if (!Mathf.Approximately(transform.eulerAngles.x, 0.0f) || !Mathf.Approximately(transform.eulerAngles.z, 0.0f))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0.0f, transform.eulerAngles.y, 0.0f), 0.3f);
        }
    }
}
