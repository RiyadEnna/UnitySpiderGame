using UnityEngine;


public class SpiderConstraintController : MonoBehaviour
{
    Vector3 originalPosition; // the original position of this leg to keep the leg fixed to the ground
    public GameObject moveCube; // the move cube of this leg
    public float legMoveSpeed = 7f; // the speed of the leg
    public float moveDistance = 0.7f; 
    public float moveStoppingDistance = 0.7f; 
    public SpiderConstraintController oppositeLeg; //the oppsite leg of this one
    bool isMoving = false; // to tell the oppsite leg if this one is moving or not
    bool moving = false;

    private void Start()
    {
        originalPosition = transform.position; // to fix the leg to the ground when the game first launches 
    }

    private void Update()
    {

        float distanceToMoveCube = Vector3.Distance(transform.position, moveCube.transform.position);
        if ((distanceToMoveCube > moveStoppingDistance && !oppositeLeg.isItMoving()) || moving) ///modif >= a >
        {
            moving = true;
            transform.position = Vector3.Lerp(transform.position, moveCube.transform.position + new Vector3(0.0f,-0.1f,0.0f) , Time.deltaTime * legMoveSpeed);
            originalPosition =transform.position;
            isMoving = true;
            if (distanceToMoveCube < moveStoppingDistance)
            {
                moving = false;
            }

        }
        else
        {
            transform.position = originalPosition;
            isMoving = false;

        }

    }
    
     public bool isItMoving() //to be called by the oppiste leg to check if the leg is moving or not
    {
        return isMoving;
    }
}