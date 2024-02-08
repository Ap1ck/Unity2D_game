using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CursorController : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetButtonDown(GlobalStringVariors.Cancel))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
