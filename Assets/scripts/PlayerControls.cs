using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControls : MonoBehaviour
{
    [SerializeField]float xControl = 20f;
    [SerializeField]float yControl = 20f;
    // Start is called before the first frame update
    [SerializeField] float xRange = 7f;
    [SerializeField] float yRange =10f;

    [SerializeField] float positionPitchFactor = -20f;
    [SerializeField] float controlPitchFactor = -40f;
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
    {
        float pitchDueToLocalPosition = transform.localPosition.y * positionPitchFactor ;
        float pitchDueToControlThrow = yThrow*controlPitchFactor;
        float pitch = pitchDueToLocalPosition + pitchDueToControlThrow;
        float yaw =0;
        float roll= 0;

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
