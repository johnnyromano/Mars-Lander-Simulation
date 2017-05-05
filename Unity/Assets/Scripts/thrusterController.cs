using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrusterController : MonoBehaviour {
    public float maxSpeed;
    public float rotSpeed;

    Rigidbody2D myRB;
    Animator myAnim;

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    /*private void FixedUpdate()
    {
        float movey = Input.GetAxis("Vertical");
        myAnim.SetFloat("speed", movey);
        myRB.velocity = new Vector2(myRB.velocity.x, movey * maxSpeed);

        float movex = Input.GetAxis("Horizontal");

        myRB.velocity = new Vector2(movex * maxSpeed, myRB.velocity.y);*/
    
    void Update()
    {

        // ROTATE the ship.
        // Grab our rotation quaternion
        Quaternion rot = transform.rotation;

        // Grab the Z euler angle
        float z = rot.eulerAngles.z;

        // Change the Z angle based on input
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        // Recreate the quaternion
        rot = Quaternion.Euler(0, 0, z);

        // Feed the quaternion into our rotation
        transform.rotation = rot;

        // MOVE the ship.
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;

        float direction = Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;
        myAnim.SetFloat("speed", direction);
        myRB.velocity = new Vector2(myRB.velocity.x, direction * maxSpeed);

        // Finally, update our position!!
        transform.position = pos;
    }

}
