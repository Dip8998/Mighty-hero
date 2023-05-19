using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerinput : MonoBehaviour
{
    public float Horizontalinput;

    public float Verticalinput; 
    void Update()
    {
        Horizontalinput = Input.GetAxisRaw("Horizontal");
        Verticalinput = Input.GetAxisRaw("Vertical");
    }

    private void OnDisable()
    {
        Horizontalinput = 0;
        Verticalinput = 0;


    }
}
