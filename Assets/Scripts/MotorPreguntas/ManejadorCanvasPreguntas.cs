using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManejadorCanvasPreguntas : MonoBehaviour {

	public static ManejadorCanvasPreguntas instanciaActiva;

	public GameObject canvasPuntoRetroalimentacion;
	private Text textoRetroalimentacion;


	public GameObject canvasPuntoPregunta;
	public GameObject canvasPreguntaDual;


	void Awake(){
	



	}


	// Use this for initialization
	void Start () {
	
		instanciaActiva = this;

		textoRetroalimentacion = canvasPuntoRetroalimentacion.transform.GetChild (1).GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void MostrarPuntoInformacion(string texto){

		textoRetroalimentacion.text = texto;
		canvasPuntoRetroalimentacion.SetActive (true);
	}

	public void OcultarPuntoInformacion(){
	
		canvasPuntoRetroalimentacion.SetActive (false);
	}
}
