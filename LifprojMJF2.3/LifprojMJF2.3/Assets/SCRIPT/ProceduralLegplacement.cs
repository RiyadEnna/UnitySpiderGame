using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//proceduralLegplacement

public class ProceduralLegplacement : MonoBehaviour
{
    public Vector3 optimalRestingPosition = Vector3.forward;
    public Vector3 restingPosition {
        get {
            return transform.TransformPoint(optimalRestingPosition);
        }
    }
    
    public Vector3 worldVelocity = Vector3.right;

    public Vector3 desiredPosition {
        get {
            return restingPosition + worldVelocity + (Random.insideUnitSphere * placementRandomization);
        }
    }

    public Vector3 worldTarget = Vector3.zero;
    public Transform ikTarget;
    public Transform ikPoleTarget;

    public float placementRandomization = 0;

    public bool autoStep = true;

    public AnimationCurve stepHeightCurve;
    public float stepHeightMultiplier = 0.25f;
    public float stepCooldown = 1f;
    public float stepDuration = 0.5f;
    public float stepOffset;
    public float lastStep = 0;
    // Start is called before the first frame update
    void Start()
    {
        worldVelocity = Vector3.zero;
        lastStep = Time.time + stepCooldown * stepOffset;
        Step(); 
    }

    void Update() {
        UpdateIkTarget();
        if (Time.time > lastStep + stepCooldown && autoStep) {
            Step();
        }
    }

        public void UpdateIkTarget() 
        {
            float percent = Mathf.Clamp01((Time.time -lastStep)/stepDuration);
            ikTarget.position = Vector3.Lerp (ikTarget.position,worldTarget,percent)+Vector3.up * stepHeightCurve.Evaluate(percent)*stepHeightMultiplier;
        }

    public void Step()
    {
        Vector3 direction = desiredPosition - ikPoleTarget.position;
        RaycastHit hit;
        if (Physics.Raycast(ikPoleTarget.position, direction, out hit, direction.magnitude * 2f))
        {
            worldTarget = hit.point;
        }
        else
        {
            worldTarget = restingPosition;
        }
        lastStep = Time.time;
    }

    public void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(restingPosition, worldTarget);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(restingPosition, 0.1f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(desiredPosition,0.1f);    
    }

}
