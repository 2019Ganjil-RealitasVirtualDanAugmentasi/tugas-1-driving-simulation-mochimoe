using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Shift Down"))
        {
            Debug.Log("Shift Down");
        }
        if (Input.GetButtonDown("Shift Up"))
        {
            Debug.Log("Shift Up");
        }
    }
}
