using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public float speed = 1;
    public float horizontal_speed = 1;
    public float vertical_speed = 1;

    float xrot = 0;
    float yrot = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoving();
        Rotation();
    }

    void PlayerMoving()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));

        }
    }

    void Rotation()
    {
        xrot -= Input.GetAxis("Mouse Y") * horizontal_speed;
        yrot += Input.GetAxis("Mouse X") * horizontal_speed;
        transform.eulerAngles = new Vector3(xrot, yrot, 0);
    }
}
