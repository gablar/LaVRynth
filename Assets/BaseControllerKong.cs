using UnityEngine;
using System.Collections;

public class BaseControllerKong : MonoBehaviour {
    public bool isPaused = true;
    public float rotationSpeed = 40;
    public int platform;
    float x;
    float z;
    Quaternion initialRot;


    void FixedUpdate() {
       
        if (!isPaused)
        {
            switch (platform) {
                case 1:
                    initialRot = transform.rotation;

                    if (Input.GetAxis("Horizontal") != 0)
                    {
                        transform.Rotate(new Vector3(0, 0,Input.GetAxis("Horizontal") * (rotationSpeed)));
                    }

                    if (Input.GetAxis("Vertical") != 0)
                    {
                        transform.Rotate(new Vector3(-Input.GetAxis("Vertical") * (rotationSpeed), 0, 0));

                    }
                    x = transform.rotation.eulerAngles.x;
                    z = transform.rotation.eulerAngles.z;
                    if (x < 340f && x > 20)
                    {
                        x = initialRot.eulerAngles.x;
                    }
                    if (z < 340f && z > 20)
                    {
                        z = initialRot.eulerAngles.z;
                    }
                    transform.rotation = Quaternion.Euler(new Vector3(x, 0, z));
                    transform.localPosition = Vector3.zero;


                    break;

                case 2:
                    initialRot = transform.rotation;

                    if (Input.GetAxis("Horizontal") != 0)
                    {
                        transform.Rotate(new Vector3(Input.GetAxis("Horizontal") * rotationSpeed, 0, 0));
                    }

                    if (Input.GetAxis("Vertical") != 0)
                    {
                        transform.Rotate(new Vector3( 0, 0, Input.GetAxis("Vertical") * rotationSpeed));

                    }
                    x = transform.rotation.eulerAngles.x;
                    z = transform.rotation.eulerAngles.z;
                    if (x < 340f && x > 20)
                    {
                        x = initialRot.eulerAngles.x;
                    }
                    if (z < 340f && z > 20)
                    {
                        z = initialRot.eulerAngles.z;
                    }
                    transform.rotation = Quaternion.Euler(new Vector3(x, 0, z));
                    transform.localPosition = Vector3.zero;

                    break;

                case 3:
                    initialRot = transform.rotation;
                    if (Input.GetAxisRaw("Horizontal") != 0)
                    {
                        transform.Rotate(new Vector3(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed ));
                       
                    }
                    if (Input.GetAxisRaw("Vertical") != 0)
                    {
                        transform.Rotate(new Vector3(Input.GetAxis("Vertical") * rotationSpeed, 0, 0));
                    }
                    x = transform.rotation.eulerAngles.x;
                    z = transform.rotation.eulerAngles.z;
                    if (x < 340f && x > 20) {
                        x = initialRot.eulerAngles.x;
                    }
                    if (z < 340f && z > 20)
                    {
                        z = initialRot.eulerAngles.z;
                    }
                    transform.rotation = Quaternion.Euler(new Vector3(x,0,z));
                    transform.localPosition = Vector3.zero;

                    //float finalRot = transform.rotation.eulerAngles.y;
                    //transform.Rotate(0, initRot - finalRot, 0);
                    break;

                case 4:
                    initialRot = transform.rotation;

                    if (Input.GetAxis("Horizontal") != 0)
                    {
                        transform.Rotate(new Vector3(-Input.GetAxis("Horizontal") * (rotationSpeed), 0, 0));
                    }

                    if (Input.GetAxis("Vertical") != 0)
                    {
                        transform.Rotate(new Vector3(0, 0, -Input.GetAxis("Vertical") * (rotationSpeed)));

                    }

                    x = transform.rotation.eulerAngles.x;
                    z = transform.rotation.eulerAngles.z;
                    if (x < 340f && x > 20)
                    {
                        x = initialRot.eulerAngles.x;
                    }
                    if (z < 340f && z > 20)
                    {
                        z = initialRot.eulerAngles.z;
                    }
                    transform.rotation = Quaternion.Euler(new Vector3(x, 0, z));
                    transform.localPosition = Vector3.zero;


                    break;
            }
        }
    }
    public void Pause()
    {
        isPaused = true;
    }

    public void UnPause()
    {
        isPaused = false;

    }


}
