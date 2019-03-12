using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;

public class ObjectsToCollect : MonoBehaviour
{
    //public GameObject objectToPlace2;
    //public GameObject placementIndicator2;
    //private ARSessionOrigin arOrigin;
    //private Pose placementPose;
    //private bool placementPoseIsValid = false;


    //void Start()
    //{
    //    arOrigin = FindObjectOfType<ARSessionOrigin>();
       
    //}

    //void Update()
    //{
    //    UpdatePlacementPose();
    //    UpdatePlacementIndicator();

    //    if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    //    {
    //        PlaceObject();
    //        Vector3 pos = touch.position;
    //    }
    //}


    //private void UpdatePlacementIndicator()
    //{
    //    if (placementPoseIsValid)
    //    {
    //        placementIndicator.SetActive(true);
    //        placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
    //    }
    //    else
    //    {
    //        placementIndicator.SetActive(false);
    //    }
    //}

    //private void UpdatePlacementPose()
    //{
    //    var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(pos));
    //    var hits = new List<ARRaycastHit>();
    //    arOrigin.Raycast(screenCenter, hits, TrackableType.Planes);

    //    placementPoseIsValid = hits.Count > 0;
    //    if (placementPoseIsValid)
    //    {
    //        placementPose = hits[0].pose;

    //        var cameraForward = Camera.current.transform.forward;
    //        var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
    //        placementPose.rotation = Quaternion.LookRotation(cameraBearing);

          
           
    //    }
    //}

    //private void PlaceObject()
    //{
    //    //Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
    //    void OnTriggerEnter(Collider other)
    //    {
    //        if (other == screenCenter)
    //            objectToPlace.SetActive(false);
    //    }
    //    //Destroy(objectToPlace);
    //}
    
}