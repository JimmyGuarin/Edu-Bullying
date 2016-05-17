using UnityEngine;
using System.Collections;

public class CamaraRPG : MonoBehaviour {

    public Vector3 posicionJugador;

	// Use this for initialization
	void Start () {

        posicionJugador = GameObject.FindGameObjectWithTag("Player").transform.position;
	}
	
	// Update is called once per frame
	void Update () {

       float posicionJugador = GameObject.FindGameObjectWithTag("Player").transform.position.y;
        if (posicionJugador < 0)
            posicionJugador = 0;
        transform.position=new Vector3(0, posicionJugador, -10);

    }
}
