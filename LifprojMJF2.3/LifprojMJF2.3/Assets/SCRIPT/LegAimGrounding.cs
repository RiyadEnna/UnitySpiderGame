using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegAimGrounding : MonoBehaviour
{
    int layerMask;
    GameObject raycastOrigin;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Ground");
        raycastOrigin = transform.parent.gameObject;
    }                                         

    // Update is called once per frame
    // Attention ne pas ajouter de box collider car provoque des bugs de positionnement
    // 0.12 valeur pour eviter objet traverse objet environement
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin.transform.position, -transform.up, out hit, layerMask))
        {
            Debug.Log(hit.transform.name);
            transform.position = hit.point + new Vector3(0f,0.2f,0f) ; // Attenttion en dessous de 0.3 c'est en dessous de la map que l'objet passe !!
        }
    }
}
