using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PuntoRetroalimentacion : MonoBehaviour
{



	[HideInInspector]
	public string textoPunto;

    public int numeroRetroalimentacion;


    // Use this for initialization
    void Start()
    {
        
		PuntosRetro pr=(PuntosRetro)GameObject.Find("ControladorNivel").GetComponent<ManejadorPreguntas>().misPuntosRetro[numeroRetroalimentacion];
        textoPunto = pr.retroalimentacion;
    }
		
}
