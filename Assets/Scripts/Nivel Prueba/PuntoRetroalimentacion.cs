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
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = pr.retroalimentacion;
    }
		

    public void MostrarPuntoRetro(){

        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OcultarPuntoRetro(){

        transform.GetChild(0).gameObject.SetActive(false);
    }
}
