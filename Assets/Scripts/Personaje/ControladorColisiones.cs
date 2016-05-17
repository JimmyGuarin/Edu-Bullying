using UnityEngine;
using System.Collections;

public class ControladorColisiones : MonoBehaviour {


	public GameObject canvasRetroalimentacion;
    public GameObject[] checkpoints;
    public GameObject[] destructores;
    private int indiceDestructor = -1;
   

	// Use this for initialization
	void Start () {
	
	}
	
	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag.Equals ("PuntoRetro")) {


            collision.GetComponent<PuntoRetroalimentacion>().MostrarPuntoRetro();
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

            if (collision.GetComponent<PuntoPregunta>() != null) {

                collision.GetComponent<PuntoPregunta>().activarPuntoPregunta();
                ManejadorPreguntas.instanciaActiva.PuntoDePregunta = collision.GetComponent<PuntoPregunta>();
            }
           
		}

        if (collision.tag.Equals("Destructor"))
        {
             indiceDestructor = compararObjeto(collision.gameObject);
            if(indiceDestructor!= -1)
            {
                gameObject.SetActive(false);
                ControladorHUD.instance.disminuirVida();
                Invoke("reaparecerPersonaje", 2f);
            } 
        }

	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag.Equals ("PuntoRetro")) {

            collision.GetComponent<PuntoRetroalimentacion>().OcultarPuntoRetro();
        }

		if (collision.tag.Equals ("PuntoPregunta")) {

            if (collision.GetComponent<PuntoPregunta>() != null){

                collision.GetComponent<PuntoPregunta>().desactivarPuntoPregunta();
            }
                
		}
	}

    public int compararObjeto(GameObject obj)
    {
        for(int i=0; i < destructores.Length; i++)
        {
            if(obj == destructores[i])
            {
                return i;
            }
        }
        return -1;
    }

    public void reaparecerPersonaje()
    {
        gameObject.transform.position = checkpoints[indiceDestructor].transform.position;
        gameObject.SetActive(true);
       
    }
}
