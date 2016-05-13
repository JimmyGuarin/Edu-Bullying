using UnityEngine;
using System.Collections;

public class MovimientoPersonaje : MonoBehaviour {

    public float thrust = 1.0f;

    // Use this for initialization
    void Start () {


        
    }
	
	// Update is called once per frame
	void Update () {

        //Retrieve axis information
        float inputX = Input.GetAxis("Horizontal") * thrust * Time.deltaTime; ;
        float inputY = Input.GetAxis("Vertical") * thrust * Time.deltaTime;
        //print (inputY);
       GetComponent<Rigidbody2D>().AddTorque(-inputX);
       GetComponent<Rigidbody2D>().AddForce(transform.right * inputY);
    }
}
