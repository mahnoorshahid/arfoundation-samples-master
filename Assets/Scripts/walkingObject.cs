using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingObject : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = -1.5f;
    public Vector3 resetPosition;

    void Start()
    {
        resetPosition = new Vector3(50, transform.position.y, transform.position.z);
        transform.position = resetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -50)
        {
            transform.position = resetPosition;
            print(transform.position);
        }

        transform.Translate(Time.deltaTime * speed, 0, 0);
    }
}
