using UnityEngine;
using System.Collections;

public class Reacomodar : MonoBehaviour {

	// Use this for initialization
	void Start () {

        
    }
	
	// Update is called once per frame
	void Update () {


        
        transform.GetChild(0).transform.position = new Vector3(-384f, transform.GetChild(0).transform.position.y, 0);
        transform.GetChild(1).transform.position = new Vector3(372f, transform.GetChild(1).transform.position.y, 0);
        transform.GetChild(2).transform.position = new Vector3(-384f, transform.GetChild(2).transform.position.y, 0);
        transform.GetChild(3).transform.position = new Vector3(372f, transform.GetChild(3).transform.position.y, 0);

    }
}
