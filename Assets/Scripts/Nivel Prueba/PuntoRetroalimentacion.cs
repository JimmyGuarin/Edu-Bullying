using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PuntoRetroalimentacion : MonoBehaviour
{



	[HideInInspector]
	public string textoPunto;

    public int numeroRetroalimentacion;

    private GameObject canvasHijo;

    // Use this for initialization
    void Start()
    {
        
		PuntosRetro pr=(PuntosRetro)GameObject.Find("ControladorNivel").GetComponent<ManejadorPreguntas>().misPuntosRetro[numeroRetroalimentacion];
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = pr.retroalimentacion;
        canvasHijo = transform.GetChild(0).gameObject;
    }
		

    public void MostrarPuntoRetro(){

        canvasHijo.SetActive(true);
        canvasHijo.GetComponent<Animator>().SetBool("Salida", false);
    }

    public void OcultarPuntoRetro(){

        canvasHijo.GetComponent<Animator>().SetBool("Salida", true);
    }
}
