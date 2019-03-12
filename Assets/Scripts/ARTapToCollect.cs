using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;

public class ARTapToCollect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterModelTouch()
    {
        Touch touch = Input.touches[0];
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("YourModelTag"))
            {
                // Do something (open an URL in your case).
            }
        }
    }
}
