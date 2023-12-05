using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform target;
    public GameObject marker;
    public GameObject mapGUI;
    public float height = 10.0f;
    public float distance = 10.0f;
    public bool rotate = true;
    private Vector3 camAngle;
    private Vector3 camPos;
    private Vector3 targetAngle;
    private Vector3 targetPos;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        //Get the Map Camera
        cam = GetComponent<Camera>();
        //Get Map Camera initial Angle
        camAngle = transform.eulerAngles;
        //Get Target initial Angle
        targetAngle = target.transform.eulerAngles;
        //Set rotation about x to 90 (it will face downward?)
        camAngle.x = 90;
        //Set rotation of camera the same as target (to get same facing direction)
        //y rotation is the same, if the camera faces downward.
        camAngle.y = targetAngle.y;
        //Set the initial camera angle (may be z will be 0? automatically)
        transform.eulerAngles = camAngle;
    }

    // Update is called once per frame
    void Update()
    {
        //Get target position
        targetPos = target.transform.position;
        //Set the camera the same position as the target
        camPos = targetPos;
        //Raise the camera by "height" amount
        camPos.y += height;
        //Set the camera position
        transform.position = camPos;
        //Set camera FoV? via distance value
        cam.orthographicSize = distance;
        //Create a new Vector for storing Minimap rotation values TRANSPOSE from target rotation values
        Vector3 compassAngle = new Vector3();
        //Since the minimap is facing the Viewport, it will rotate via the z axis while the target rotate via y axis
        compassAngle.z = target.transform.eulerAngles.y;
        if (rotate)
        {
            //If the compass is set to rotate
            //Rotate the whole MapGUI
            mapGUI.transform.eulerAngles = compassAngle;
            //But the marker must be set to ZeroVector(Otherwise the child would rotate alongside MapGUI)
            marker.transform.eulerAngles = new Vector3();
        }
        else
        {   
            //If the compass is not set to rotate, the marker must rotate
            //The rotation of the marker is opposite of the target rotation
            marker.transform.eulerAngles = -compassAngle;
        }
    }
}
