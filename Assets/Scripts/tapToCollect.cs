﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;

public class tapToCollect : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject objectToPlace;
    //public GameObject placementIndicator;

    private ARSessionOrigin arOrigin;
    private Pose placementPose;
    private PlaceOnPlane placeOnPlane;
    private ARPlaneManager arManager;




    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
        placeOnPlane = GetComponent<PlaceOnPlane>();
        arManager = GetComponent<ARPlaneManager>();
        //arManager.planeAdded += Respawn;

        InvokeRepeating("Respawn", 1, 1);
    }

    void Update()
    {
   
        RegisterModelTouch();
    }


    //private void UpdatePlacementPose()
    //{
    //    //var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
    //    var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(touchPos.x, touchPos.y));
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

    public void RegisterModelTouch()
    {
    
        Touch touch = Input.touches[0];
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if (Physics.Raycast(ray, out hit))
        {
            var noHit = hit.collider.GetComponent<BoxCollider>();
            if (noHit !=null)
           
            {
                noHit.GetComponent<MeshRenderer>().enabled = false;
                noHit.GetComponent<BoxCollider>().enabled = false;
                //gameObject.name 
                Respawn();
                Destroy(this.gameObject);
                
            }
        }
    }


    // void Respawn(ARPlaneAddedEventArgs args)

    void Respawn()
    {
        float random = Random.Range(-5.0f, 5.0f);

        this.GetComponent<MeshRenderer>().enabled = true;
        this.GetComponent<BoxCollider>().enabled = true;

        // Instantiate(placeOnPlane.placedPrefab, transform.position + new Vector3(random, transform.position.y, random), Quaternion.identity);
       //Instantiate(m_PlacedPrefab[Random.Range(0, m_PlacedPrefab.Length - 1)], transform.position + new Vector3(random, transform.position.y, random), Quaternion.identity);

    }
}


