using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float AxisX;
    float AxisY;

    public float distance = 25f;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        SetCamreraPosiition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
            SetCamreraPosiition();
    }
    void SetCamreraPosiition()
    {
        float deltaX = Input.GetAxis("Mouse X");
        float deltaY = Input.GetAxis("Mouse Y");

        AxisX += deltaY * speed;
        AxisY += deltaX * speed;

        

        AxisX = Mathf.Clamp(AxisX, -85f, 0f);

        var rotation = Quaternion.Euler(AxisX, AxisY, 0);
        transform.position = rotation * Vector3.forward * distance;

        transform.LookAt(Vector3.up * 5f);
    }
}
