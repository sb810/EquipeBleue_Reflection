using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    private bool isPunching = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isPunching = true;
            Debug.Log("punched");
            isPunching = false;
        }
        
    }





}