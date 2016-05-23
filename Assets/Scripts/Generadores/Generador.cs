using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {


    public GameObject[] obj;
    public float tiempoMinimo = 1f;
    public float tiempoMaximo = 2f;
    public float maxDistance = 25f;

    private Vector3 posicionInic;

	// Use this for initialization
	void Start () {
        GenerarBloques();
        posicionInic = transform.position;

    }
	
	// Update is called once per frame
	void Update () {


        transformarPosicion();
        
	}

    void transformarPosicion()
    {


        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(posicionInic.x + Random.Range(0, 15), posicionInic.y, 0), 0.2f);
        transform.position = new Vector3(posicionInic.x + Random.Range(0,maxDistance), posicionInic.y, 0);
    }

    void GenerarBloques(){

        Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.AngleAxis(Random.Range(0,360), Vector3.back));
        Invoke("GenerarBloques", Random.Range(tiempoMinimo, tiempoMaximo));
    }
}
