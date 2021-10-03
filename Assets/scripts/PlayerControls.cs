using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControls : MonoBehaviour
{
    [SerializeField]float xControl = 20f;
    [SerializeField]float yControl = 20f;
    // Start is called before the first frame update
    [SerializeField] float xRange = 14f;
    [SerializeField] float yRange = 8.5f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -4.1f;

    [SerializeField] float positionYawFactor = 1.5f;
    [SerializeField] float controlRollFactor = -30f;
    // [SerializeField] ParticleSystem laserRightParticles;
    // [SerializeField] ParticleSystem laserLeftParticles;

    [SerializeField] GameObject[] lasers;
    float xThrow, yThrow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessLasers();
        

    }

     void ProcessRotation()
    {   float yaw =0 ;
        float roll= 0;
        float pitch =0;


        roll = xThrow * controlRollFactor;

        

        yaw = transform.localPosition.x * positionYawFactor;

        
       
        
        float pitchDueToLocalPosition = transform.localPosition.y * positionPitchFactor ;
        float pitchDueToControlThrow = yThrow*controlPitchFactor;
              pitch = pitchDueToLocalPosition + pitchDueToControlThrow;
        
              
        
        

        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        // Debug.Log("Vertical = " + yThrow);
        // Debug.Log("Horizontal = " + xThrow); 
        float xOffset = xThrow * Time.deltaTime * xControl;
        float yOffset = yThrow * Time.deltaTime * yControl;
        float rawXpos = transform.localPosition.x + xOffset;
        float rawYpos = transform.localPosition.y + yOffset;

        float xClampedPos = Mathf.Clamp(rawXpos, -xRange, xRange);
        float yClampedPos = Mathf.Clamp(rawYpos, -yRange, yRange);
        transform.localPosition = new Vector3(xClampedPos,
                                          yClampedPos,
                                          transform.localPosition.z);
    }
    void ProcessLasers(){

        
        if(Input.GetButton("Fire1")){

            ActivateLasers();
        }

        else{

            DeactivateLasers();
        }

    }

    void ActivateLasers(){

        foreach (GameObject item in lasers){
             
            // item.SetActive(true);
             var emmisionModule =item.GetComponent<ParticleSystem>().emission;
             emmisionModule.enabled = true;
        }

    }

    void DeactivateLasers(){

        foreach(GameObject item in lasers){

            //item.SetActive(false);

            var emissionModule = item.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = false;
        }

    }

}
