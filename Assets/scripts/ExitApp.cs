using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > 20)
         {
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         }

        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Cancel")){
            

            Application.Quit();

        }
    }
}
