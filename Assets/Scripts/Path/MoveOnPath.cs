using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveOnPath : MonoBehaviour {

    public EditorPath pathToFollow;
    public int currentWayPointID = 0;
    public float speed;
    private float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    public string pathName;

    Vector3 last_position;
    Vector3 current_position;


	// Use this for initialization
	void Start () {

        //pathToFollow = GameObject.Find(pathName).GetComponent<EditorPath>();
        last_position = transform.position;
        current_position = last_position;
        
	}
	
	// Update is called once per frame
	void Update () {

        float distance = Vector3.Distance(pathToFollow.path_objs[currentWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, pathToFollow.path_objs[currentWayPointID].position, Time.deltaTime * speed);
        if(distance <= reachDistance)
        {
            currentWayPointID++;
        }
        if(currentWayPointID >= pathToFollow.path_objs.Count)
        {

            GetComponent<Animator>().SetBool("Correr", false);
            currentWayPointID = 0;
            this.enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
        
	}

    public void Reset()
    {
        currentWayPointID = 0;
        transform.position = current_position;
        last_position = transform.position;
        GetComponent<Animator>().SetBool("Correr", false);
        GetComponent<Collider2D>().enabled = true;
        this.enabled = false;
    }
}
