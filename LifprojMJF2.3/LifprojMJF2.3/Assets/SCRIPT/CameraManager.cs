using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    /*public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;*/

    public Camera CamNormal;
    public Camera CamFPS;
    public Camera CamFace;
    public Camera CamTarget;

    void Fps()
    {
        CamFPS.depth = 0;
        CamNormal.depth = -1;
        CamFace.depth = -1;
        CamTarget.depth = -1;
    }

    void Normal()
    {
        CamFPS.depth = -1;
        CamNormal.depth = 0;
        CamFace.depth = -1;
        CamTarget.depth = -1;
    }

    void Target()
    {
        CamFPS.depth = -1; //permet de faire passer CamFPS par dessus CamNormal
        CamNormal.depth = -1;
        CamFace.depth = -1;
        CamTarget.depth = 0;
    }

    void Face()
    {
        CamFPS.depth = -1;
        CamNormal.depth = -1;
        CamFace.depth = 0;
        CamTarget.depth = -1;
    }

    void Start()
    {
        Normal();

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            Target();
            Debug.Log("cam");
        }
        if(Input.GetKeyDown(KeyCode.Alpha8))
        {
            Normal();
        }
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            Face();
        }
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            Fps();
        }

        //Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        /*Vector3 targetPosition1 = new Vector3(target1.transform.position.x, transform.position.y, target1.transform.position.z);
        Vector3 targetPosition2 = new Vector3(target2.transform.position.x, transform.position.y, target2.transform.position.z);
        Vector3 targetPosition3 = new Vector3(target3.transform.position.x, transform.position.y, target3.transform.position.z);
        Vector3 targetPosition4 = new Vector3(target4.transform.position.x, transform.position.y, target4.transform.position.z);
        if(CamTarget.depth == 0)
        {
            if(target1.activeSelf) {
                transform.LookAt(targetPosition1);
            }
            if(target2.activeSelf) {
                transform.LookAt(targetPosition2);
            }
            if(target3.activeSelf) {
                transform.LookAt(targetPosition3);
            }
            if(target4.activeSelf) {
                transform.LookAt(targetPosition4);
            }
        }*/
    }
}
