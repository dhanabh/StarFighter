using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > 20.0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        float horizontalThrow = Input.GetAxis("Horizontal");
        float verticalThrow = Input.GetAxis("Vertical");

        Debug.Log("Vertical = " + verticalThrow);
        Debug.Log("Horizontal = " + horizontalThrow); 
        
    }
}
