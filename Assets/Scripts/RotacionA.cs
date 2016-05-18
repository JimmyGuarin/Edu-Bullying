using UnityEngine;
using System.Collections;

public class RotacionA : MonoBehaviour {

    public float smooth = 2.0F;
    public float tiltAngle = 30.0F;
    float contador = 1f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float tiltAroundZ = Random.Range(0, 5f) * tiltAngle;
        float tiltAroundX = Random.Range(0, 5f) * tiltAngle;
        Quaternion target = Quaternion.Euler(0,0,5f+contador);
        if(Random.Range(0,130) == 3)
        {
            contador+=Random.Range(15,35);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

    }
}
