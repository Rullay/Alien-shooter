using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject character;
    private Vector3 p;
    public float positionX;
    public float positionZ;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        p = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(character.transform.position.x  + positionX,  transform.position.y, character.transform.position.z + positionZ), 0.05f); 
        transform.position = p;
    }
}
