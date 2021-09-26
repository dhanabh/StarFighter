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

    [SerializeField] float positionPitchFactor = -3f;
    [SerializeField] float controlPitchFactor = -4.1f;

    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -30f;
    float xThrow, yThrow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        

    }

    private void ProcessRotation()
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

    private void ProcessTranslation()
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
}
