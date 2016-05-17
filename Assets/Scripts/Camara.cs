using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour
{
    private Transform posJugador;
    public GameObject paredIzquierda;

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
        if (posJugador.transform.position.x >= -15)
        {
            posJugador.transform.position.Set(-15, posJugador.transform.position.y, posJugador.transform.position.z);
            GetComponent<CameraFollow>().enabled = true;
        }
    }

    
}