using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMiniatureController : MonoBehaviour, IRoomMiniatureController
{
    [SerializeField]
    private Transform originOfConstraint;
    [SerializeField]
    private Transform limitOfConstraint;
    public Transform OriginOfConstraint { get => originOfConstraint; set => originOfConstraint = value; }
    public Transform LimitOfConstraint { get => limitOfConstraint; set => limitOfConstraint = value; }
    [SerializeField]
    private ObjectManipulator objectManipulator;
    [SerializeField]
    private BoundsControl boundsControl;
    private bool isOutside = false;



    private void Awake()
    {
        objectManipulator = GetComponent<ObjectManipulator>();
        boundsControl = GetComponent<BoundsControl>();
    }
    private void Start()
    {
        GameObject[] roomConstraints = GameObject.FindGameObjectsWithTag("MiniRoomConstraint");
        originOfConstraint = roomConstraints[0].transform;
        limitOfConstraint = roomConstraints[1].transform;

        boundsControl.ScaleHandlesConfig.ShowScaleHandles = false;
        boundsControl.RotationHandlesConfig.ShowHandleForX = false;
        boundsControl.RotationHandlesConfig.ShowHandleForZ = false;

    }

    private void FixedUpdate()
    {
        if(!isOutside) LimitRoomMovement();
    }
    public void LimitRoomMovement()
    {
        float roomPositionX = transform.position.x;
        float roomPositionY = transform.position.y;
        float roomPositionZ = transform.position.z;
        Vector3 origin = OriginOfConstraint.position;
        Vector3 limit = LimitOfConstraint.position;
        Vector3 correctionTranslation = Vector3.zero;
        correctionTranslation = UpdateCorrectionTranslation(correctionTranslation, new Vector3(0.1f,0,0), roomPositionX, Comparison.LessThan, origin.x);
        correctionTranslation = UpdateCorrectionTranslation(correctionTranslation, new Vector3(-0.1f,0,0), roomPositionX, Comparison.MoreThan, limit.x);
        correctionTranslation = UpdateCorrectionTranslation(correctionTranslation, new Vector3(0,0.1f,0), roomPositionY, Comparison.LessThan, origin.y);
        correctionTranslation = UpdateCorrectionTranslation(correctionTranslation, new Vector3(0,-0.1f,0), roomPositionY, Comparison.MoreThan, limit.y); 
        correctionTranslation = UpdateCorrectionTranslation(correctionTranslation, new Vector3(0,0,0.1f), roomPositionZ, Comparison.LessThan, origin.z);
        correctionTranslation = UpdateCorrectionTranslation(correctionTranslation, new Vector3(0,0,-0.1f), roomPositionZ, Comparison.MoreThan, limit.z);
        isOutside = correctionTranslation != Vector3.zero;
        //Debug.Log("Correction: " + correctionTranslation.ToString() + "\nIs outside: " + isOutside);
        if (isOutside)
        {
            //Debug.Log("Corrutine is going to start.");
            StartCoroutine(ReturnRoomInbound(correctionTranslation));
        }


    }

    private IEnumerator ReturnRoomInbound(Vector3 direction)
    {
        //Debug.Log("Outbounds corrutine.");
        objectManipulator.enabled = false;
        //boundsControl.enabled = false;
        yield return new WaitForEndOfFrame();
        transform.position += direction;
        yield return new WaitForSeconds(3);
        objectManipulator.enabled = true;
        boundsControl.enabled = true;
        isOutside = false;
    }

    private Vector3 UpdateCorrectionTranslation(Vector3 correctionVector, Vector3 correction,
        float currentCoordinate, Comparison lessOrMore, float comparerCoordinate )
    {
        bool isOutsideOnNegativeSide = lessOrMore == Comparison.LessThan && currentCoordinate < comparerCoordinate;
        bool isOutsideOnPositiveSide = lessOrMore == Comparison.MoreThan && currentCoordinate > comparerCoordinate;
        if (isOutsideOnNegativeSide || isOutsideOnPositiveSide)
        {
            correctionVector += correction;
            //Debug.Log("Outbounds: " + correctionVector.ToString());
        }
        return correctionVector;
    }

    private void ReactivateBounds()
    {
        objectManipulator.enabled = true;
    }
}
enum Comparison
{
    LessThan,
    MoreThan
}