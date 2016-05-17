using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {


    public GameObject[] obj;
    public float tiempoMinimo = 1f;
    public float tiempoMaximo = 2f;

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
        transform.position = new Vector3(posicionInic.x + Random.Range(0,25), posicionInic.y, 0);
    }

    void GenerarBloques(){

        Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
        Invoke("GenerarBloques", Random.Range(tiempoMinimo, tiempoMaximo));
    }
}
