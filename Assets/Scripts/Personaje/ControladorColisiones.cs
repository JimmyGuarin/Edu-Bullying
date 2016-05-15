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
			collision.GetComponent<PuntoRetroalimentacion> ().textoRetroalimentación.text =
			collision.GetComponent<PuntoRetroalimentacion> ().textoPunto;	
			collision.GetComponent<PuntoRetroalimentacion> ().canvas.SetActive (true);
		}

		if (collision.tag.Equals ("Coins")) {
		
			Destroy (collision.gameObject);
			ControladorHUD.instance.aumentarPuntaje (5,false);
		
		}

		if (collision.tag.Equals ("Corazon")) {

			Destroy (collision.gameObject);
			ControladorHUD.instance.aumentarVida ();

		}

	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag.Equals ("PuntoRetro")) {
			collision.GetComponent<PuntoRetroalimentacion> ().canvas.SetActive (false);
		}
	}
}
