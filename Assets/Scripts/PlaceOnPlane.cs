using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;


/// <summary>
/// Listens for touch events and performs an AR raycast from the screen touch point.
/// AR raycasts will only hit detected trackables like feature points and planes.
/// 
/// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
/// and moved to the hit position.
/// </summary>
[RequireComponent(typeof(ARSessionOrigin))]
public class PlaceOnPlane : MonoBehaviour
{

    [Tooltip("Instantiates this prefab on a plane at the touch location.")]
    public GameObject[] m_PlacedPrefab;

    public GameObject spawnPrehab;
    int spawnNum = 1;
    int planeCounter;
    public int instanceCounter;
    private tapToCollect tapScript;
    private ARPlaneManager arManager;
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    ARSessionOrigin m_SessionOrigin;

    /// <summary>
    /// The prefab to instantiate on touch.
    /// </summary>

   


    /// <summary>
    /// The object instantiated as a result of a successful raycast intersection with a plane.
    /// </summary>
    public GameObject spawnedObject { get; private set; } 

    void Awake()
    {
        m_SessionOrigin = GetComponent<ARSessionOrigin>();
        arManager = GetComponent<ARPlaneManager>();
        arManager.planeAdded += OnPlaneDetected;
        tapScript = GetComponent<tapToCollect>();
        InvokeRepeating("TimeDelay", 0, 2);
       

    }

    void Update()
    {

        RegisterModelTouch();
        //tapScript.RegisterModelTouch();
        //sRegisterModelTouch();
        //if (Input.touchCount == 0)
        //    return;

        //var touch = Input.GetTouch(0);

        //if (m_SessionOrigin.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
        //{
        //    // Raycast hits are sorted by distance, so the first one
        //    // will be the closest hit.
        //    var hitPose = s_Hits[0].pose;

        //    if (spawnedObject == null)
        //    {
        //        spawnedObject = Instantiate(m_PlacedPrefab[Random.Range(0, m_PlacedPrefab.Length-1)], hitPose.position, hitPose.rotation);
        //    }
        //    else
        //    {
        //        spawnedObject.transform.position = hitPose.position;
        //    }
        //}



    }

    public void RegisterModelTouch()
    {
        
        Touch touch = Input.touches[0];
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if (Physics.Raycast(ray, out hit))
        {
    //        //var collectScript = GetComponent<tapToCollect>();
             tapScript = hit.collider.gameObject.GetComponent<tapToCollect>();
            var noHit = hit.collider.gameObject.GetComponent<GameObject>();
            var objHit = hit.collider.gameObject.GetComponent<GameObject>();
            if (noHit != null)

            {
               // tapScript.RegisterModelTouch();
                tapScript.registerTouch();

                //Destroy(objHit);

                //TimeDelay();
                //gameObject.name 

                //noHit.GetComponent<MeshRenderer>().enabled = false;
                //noHit.GetComponent<BoxCollider>().enabled = false;

                //Destroy(this.gameObject);

            }
        }
    }

    void TimeDelay()
    {

        if (planeCounter > 1 && instanceCounter <= 100 )
        {
            spawn();
     
        }
        else if (planeCounter > 10)
        {
            CancelInvoke();
        }

    }

    private void OnPlaneDetected(ARPlaneAddedEventArgs args)
    {
        planeCounter++;
        Instantiate(m_PlacedPrefab[Random.Range(0,m_PlacedPrefab.Length-1)], args.plane.boundedPlane.Center, Quaternion.identity);

    }
    
    void spawn()
    {
        var random = Random.Range(-2.0f, 2.0f);
        for (int i = 0; i < spawnNum; i++)
        {
           //Vector3 birdPos = new Vector3(args.plane.boundedPlane.Center, args.plane.boundedPlane.Pose.y, args.plane.boundedPlane.Pose.z);
            Instantiate(m_PlacedPrefab[Random.Range(0, m_PlacedPrefab.Length - 1)], transform.position + new Vector3(random, random, random), Quaternion.identity);
            instanceCounter++;
       }
       
    }


}
