using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject checkPoint;
    public Vector3 pos;
    private Vector3 savePose; 

    public void OnCollisionEnter(Collision collision){
            if(collision.collider.tag=="Checkpoint"){
                Debug.Log("Checkpoint)");
            pos = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
        }
    }

    private void Update(){
        savePose=pos;   
    }

}
