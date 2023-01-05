using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public bool dragging = false;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void OnMouseDrag()
    {
        //dragging = true;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        /*if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }*/
    }
    void FixedUpdate()
    {
        /*if (dragging)
        {
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            rigidbody.AddTorque(Vector3.down * x);
            rigidbody.AddTorque(Vector3.right * y);

        }*/
    }
}
