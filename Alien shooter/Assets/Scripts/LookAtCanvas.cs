using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCanvas : MonoBehaviour
{

    public GameObject Camera;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.LookAt(Camera.transform);
    }
}
