using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {


    public GameObject[] obj;
    public float tiempoMinimo = 1f;
    public float tiempoMaximo = 3f;


	// Use this for initialization
	void Start () {
        GenerarBloques();
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void GenerarBloques(){

        Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
        Invoke("GenerarBloques", Random.Range(tiempoMinimo, tiempoMaximo));
    }
}
