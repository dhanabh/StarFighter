using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject hitVfx;
    [SerializeField]Transform ParticlesContainer;
    [SerializeField] int scorePoints = 15;
    ScoreBoard score_board;
    void Start()
    {
        score_board = FindObjectOfType<ScoreBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnParticleCollision(GameObject other){

        Debug.Log(this.name + " was hit by " + other.gameObject.name);
       
         ReleasePoints();
         Destroy(this.gameObject);

        //HitResult();
    }

    void ReleasePoints(){

        score_board.UpdateScore(scorePoints);

    }
    void HitResult(){

            GameObject vfxObj = Instantiate(hitVfx,transform.position,Quaternion.identity);

       vfxObj.transform.parent = ParticlesContainer;
        
        Destroy(this.gameObject);

    }

}
