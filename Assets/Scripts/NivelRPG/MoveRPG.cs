using UnityEngine;
using System.Collections;

public class MoveRPG : MonoBehaviour {


    // Normal Movements Variables
    private float walkSpeed;
    private float curSpeed;
    private float maxSpeed;

  //  private CharacterStat plStat;

    void Start()
    {
    //    plStat = GetComponent<CharacterStat>();

        walkSpeed = (float)(2);
        //sprintSpeed = walkSpeed + (walkSpeed / 2);

    }

    void FixedUpdate()
    {
        curSpeed = walkSpeed;
        maxSpeed = curSpeed;

        // Move senteces
      


        if (Input.GetAxis("Horizontal") != 0&& Input.GetAxis("Vertical") == 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 1), 0);
        }
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") != 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 1));
        }

        if ( (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)|| (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if ((Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) || (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        }

    }
}