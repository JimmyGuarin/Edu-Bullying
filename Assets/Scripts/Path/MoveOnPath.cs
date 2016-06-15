using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveOnPath : MonoBehaviour
{

    private EditorPath pathToFollow;
    public int currentWayPointID;
    public float speed;
    private float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    public string pathName;

    public bool correr;

    Vector3 last_position;
    Vector3 current_position;


    // Use this for initialization
    void Start()
    {

        pathToFollow = GameObject.Find(pathName).GetComponent<EditorPath>();
        last_position = transform.position;
        current_position = last_position;
        currentWayPointID = 0;
        correr = false;
       
    }

    // Update is called once per frame
    void Update()
    {

        if (correr)
        {
          

            float distance = Vector3.Distance(pathToFollow.path_objs[currentWayPointID].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, pathToFollow.path_objs[currentWayPointID].position, Time.deltaTime * speed);
            if (distance <= reachDistance)
            {
                currentWayPointID++;
            }

            if (currentWayPointID >= pathToFollow.path_objs.Count)
            {
              

                GetComponent<Animator>().SetBool("Correr", false);
                correr = false;



            }
        }






    }

    public void Resetear()
    {
        GetComponent<Collider2D>().enabled = true;
        currentWayPointID = 0;
        transform.position = current_position;
        last_position = transform.position;
        GetComponent<Animator>().SetBool("Correr", false);
        correr = false;
    }

}
