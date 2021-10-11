using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    int _level;
    [SerializeField] float _levelReloadDelay = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        _level = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other){

       Debug.Log(this.name + " Collided with " + other.gameObject.name );
    }
    void OnTriggerEnter(Collider other)
    {
        CrashHandler(other);
    }

    private void CrashHandler(Collider other)
    {
        Debug.Log(this.name + " tiggered " + other.gameObject.name + " at " + Time.timeSinceLevelLoad);
        if (Time.timeSinceLevelLoad > 0.5)
        {
            GetComponent<PlayerControls>();

            var ship = this.gameObject.transform.Find("PlayerShip");

            ship.gameObject.GetComponent<PlayerControls>().enabled = false;
            this.GetComponent<PlayerControls>().enabled = false;

            Invoke("ReloadLevel", _levelReloadDelay);

        }
    }

    void ReloadLevel(){

            SceneManager.LoadScene(_level);
    }
   
}
