using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    //public Transform target;
    public GameObject TextEventItem;

    public Inventory Invent;

    void Start()
    {
        Invent.initSlot();
        //TextEventItem.SetActive(false);
        Debug.Log("init script");
        Invent = GameObject.Find("Inventory").GetComponent<Inventory> ();
    }

    /*void Update()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, 0, target.transform.position.x);
        transform.LookAt(targetPosition);
    }*/

    void OnTriggerStay(Collider collider)
    {
        //Debug.Log("Object is within trigger" + collider.gameObject.tag);
        if(Input.GetKeyDown(KeyCode.Z) /*&& collider.gameObject.tag == "Player"*/)
        {
            switch(gameObject.tag)
            {
                case "slot0":
                    Invent.slotI[0]++;
                    Invent.UpdateNumber(0, Invent.slotI[0].ToString());
                    Destroy(gameObject);
                break;
                case "slot1":
                    Invent.slotI[1]++;
                    Invent.UpdateNumber(1, Invent.slotI[1].ToString());
                    Destroy(gameObject);
                break;
                case "slot2":
                    Invent.slotI[2]++;
                    Invent.UpdateNumber(2, Invent.slotI[2].ToString());
                    Destroy(gameObject);
                break;
                case "slot3":
                    Invent.slotI[3]++;
                    Invent.UpdateNumber(3, Invent.slotI[3].ToString());
                    Destroy(gameObject);
                break;
                case "slot4":
                    Invent.slotI[4]++;
                    Invent.UpdateNumber(4, Invent.slotI[4].ToString());
                    Destroy(gameObject);
                break;
            }
            /*for(int i = 0 ; i < Invent.transform.childCount ; i++)
            {
                switch(gameObject.tag)
                {
                    case "slot"+i:
                    Invent.slotI[i]++;
                    Invent.UpdateNumber(i, Invent.slotI[i].ToString());
                    Destroy(gameObject);
                    break;
                }
            }*/
        }
        //TextEventItem.SetActive(true);
    }

    void OnTriggerExit(Collider collider)
    {
        //TextEventItem.SetActive(false);  
    }
}