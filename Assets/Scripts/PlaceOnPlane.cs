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
    [SerializeField]
    [Tooltip("Instantiates this prefab on a plane at the touch location.")]
    GameObject[] m_PlacedPrefab;

    public GameObject spawnPrehab;
    int spawnNum = 3;

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
        arManager.planeAdded += spawn;
    }

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        var touch = Input.GetTouch(0);

        if (m_SessionOrigin.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            var hitPose = s_Hits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(m_PlacedPrefab[Random.Range(0, m_PlacedPrefab.Length-1)], hitPose.position, hitPose.rotation);
            }
            else
            {
                spawnedObject.transform.position = hitPose.position;
            }
        }
    
    }

    private void OnPlaneDetected(ARPlaneAddedEventArgs args)
    {
       
        Instantiate(m_PlacedPrefab[Random.Range(0,m_PlacedPrefab.Length-1)], args.plane.boundedPlane.Center, Quaternion.identity);

    }
    
    void spawn(ARPlaneAddedEventArgs args)
    {
        var random = Random.Range(-5.0f, 5.0f);
        for (int i = 0; i < spawnNum; i++)
        {
           //Vector3 birdPos = new Vector3(args.plane.boundedPlane.Center, args.plane.boundedPlane.Pose.y, args.plane.boundedPlane.Pose.z);
            Instantiate(m_PlacedPrefab[Random.Range(0, m_PlacedPrefab.Length - 1)], transform.position + new Vector3(random, transform.position.y, random), Quaternion.identity);

       }

  
    }

}
