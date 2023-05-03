using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingMovement : MonoBehaviour
{
    private int wingMove = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        { 
            transform.Translate(new Vector3(1, 0, 0));
        }

        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            transform.Translate(new Vector3(-1, 0, 0));
        }

    }
}
