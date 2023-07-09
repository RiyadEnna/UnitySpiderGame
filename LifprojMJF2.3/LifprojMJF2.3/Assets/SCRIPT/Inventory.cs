using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public int[] slotI;
    public GameObject[] slotG;

    public void initSlot()
    {
        slotI = new int[transform.childCount];
        slotG = new GameObject[transform.childCount];
        for(int i = 0 ; i < transform.childCount ; i++)
        {
            slotG[i] = GameObject.Find("Slot" + i);
        }
        Debug.Log("init slot");
    }

    public void UpdateNumber(int nbSlot, string txt)
    {
        transform.GetChild (nbSlot).GetChild (1).GetComponent<Text> ().text = txt;
    }
}
