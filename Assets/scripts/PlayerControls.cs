using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerControls : MonoBehaviour
{
    [SerializeField]float xControl = 20f;
    [SerializeField]float yControl = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > 20.0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        // Debug.Log("Vertical = " + yThrow);
        // Debug.Log("Horizontal = " + xThrow); 
        float xOffset = xThrow * Time.deltaTime * xControl;
        float yOffset = yThrow * Time.deltaTime * yControl;
        float newXpos = transform.localPosition.x + xOffset;
        float newYpos = transform.localPosition.y +yOffset;

        transform.localPosition = new Vector3(newXpos,
                                          newYpos,
                                          transform.localPosition.z);

        
    }
}
