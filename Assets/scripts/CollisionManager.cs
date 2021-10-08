using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other){

       Debug.Log(this.name + " Collided with " + other.gameObject.name );
    }
    void OnTriggerEnter(Collision other){

        Debug.Log(this.name + " tiggered " + other.gameObject.name );
    }
    
   
}
