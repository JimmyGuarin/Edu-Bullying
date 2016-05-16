using UnityEngine;
using System.Collections;

public class ControladorColisiones : MonoBehaviour {


	public GameObject canvasRetroalimentacion;

	// Use this for initialization
	void Start () {
	
	}
	
	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag.Equals ("PuntoRetro")) {
			
			ManejadorCanvasPreguntas.instanciaActiva.MostrarPuntoInformacion(
				collision.GetComponent<PuntoRetroalimentacion> ().textoPunto);
		}


		if (collision.tag.Equals ("Coins")) {
		
			Destroy (collision.gameObject);
			ControladorHUD.instance.aumentarPuntaje (5,false);
		
		}

		if (collision.tag.Equals ("Corazon")) {

			Destroy (collision.gameObject);
			ControladorHUD.instance.aumentarVida ();

		}

		if (collision.tag.Equals ("PuntoPregunta")) {

			collision.GetComponent<PuntoPregunta> ().activarPuntoPregunta ();
			ManejadorPreguntas.instanciaActiva.PuntoDePregunta = collision.GetComponent<PuntoPregunta>();
		}

	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag.Equals ("PuntoRetro")) {

			ManejadorCanvasPreguntas.instanciaActiva.OcultarPuntoInformacion ();
		}

		if (collision.tag.Equals ("PuntoPregunta")) {

			collision.GetComponent<PuntoPregunta> ().desactivarPuntoPregunta();
		}
	}
}
