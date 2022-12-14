using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaMove : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float maxSpeed;
    public GameObject referencia;
    bool floorDetected = false;
    bool isJump = false;
    public float jumpForce = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isJump = Input.GetButtonDown("Jump");

        if (isJump && floorDetected)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
        Vector3 floor = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, floor, 1f))
        {
            floorDetected = true;
            print("Contacto con el suelo");
        }
        else
        {
            floorDetected = false;
            print("No hay contacto con el suelo");
        }
    }
    void FixedUpdate()
    {
        float moverHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        rb.AddForce(moverVertical * referencia.transform.forward * speed);
        rb.AddForce(moverHorizontal * referencia.transform.forward * speed);

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down), Color.black);




    }
}