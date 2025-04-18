// shoot
// using __ imports namespace
// Namespaces are collection of classes, data types
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehavior is the base class from which every Unity Script Derives
public class PlayerMovement : MonoBehaviour
{
    public float speed = 25.0f;
    public float rotationSpeed = 90;
    public float force = 700f;

    public GameObject cannon;
    public GameObject soccer_ball;

    Rigidbody rb;
    Transform t;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime represents the time that passed since the last frame
        //the multiplication below ensures that GameObject moves constant speed every frame
        if (Input.GetKey(KeyCode.W))
            rb.linearVelocity += this.transform.forward * speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.S))
            rb.linearVelocity -= this.transform.forward * speed * Time.deltaTime;

        // Quaternion returns a rotation that rotates x degrees around the x axis and so on
        if (Input.GetKey(KeyCode.D))
            t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.A))
            t.rotation *= Quaternion.Euler(0, - rotationSpeed * Time.deltaTime, 0);
        
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(t.up * force);

        // https://docs.unity3d.com/ScriptReference/Input.html
        if (Input.GetButtonDown("Fire1")){
            GameObject newsoccer_ball = GameObject.Instantiate(soccer_ball, cannon.transform.position, cannon.transform.rotation) as GameObject;
            newsoccer_ball.GetComponent<Rigidbody>().linearVelocity += Vector3.up * 2;
            newsoccer_ball.GetComponent<Rigidbody>().AddForce(newsoccer_ball.transform.forward * 1500);
        }

    }
}