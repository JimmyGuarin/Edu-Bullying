using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour
{
    private Transform posJugador;

    public void Start()
    {
         posJugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void OnEnable()
    {
        GetComponent<CameraFollow>().enabled = false;
    }

    void Update()
    {
        if (posJugador.transform.position.x >= transform.position.x)
        {

            GetComponent<CameraFollow>().enabled = true;
        }
    }
}