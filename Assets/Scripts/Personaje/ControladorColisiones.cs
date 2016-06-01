using UnityEngine;
using System.Collections;

public class ControladorColisiones : MonoBehaviour
{

    public GameObject profesora;
    public GameObject enemigo;
    public GameObject[] checkpoints;
    public GameObject[] destructores;
    public AudioSource[] sonidosPersonaje;
    private int indiceDestructor = -1;
    private bool enDaño;

    // Use this for initialization
    void Start()
    {
        enDaño = false;
        sonidosPersonaje = GetComponents<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("PuntoRetro"))
        {
            sonidosPersonaje[5].Stop();
            sonidosPersonaje[4].Play();
            collision.GetComponent<PuntoRetroalimentacion>().MostrarPuntoRetro();
            return;
        }

        

        if (collision.tag.Equals("Coins"))
        {

            Destroy(collision.gameObject);
            //Reproduce Audio Source de Recoleccion de Monedas
            sonidosPersonaje[0].Play();
            ControladorHUD.instance.aumentarPuntaje(5, false);
            return;

        }


        if (collision.tag.Equals("Corazon"))
        {

            Destroy(collision.gameObject);
            //Reproduce Audio Source de Recoleccion de Corazones
            sonidosPersonaje[1].Play();
            ControladorHUD.instance.aumentarVida();
            return;

        }


        if (collision.tag.Equals("PuntoPregunta"))
        {

            if (collision.GetComponent<PuntoPregunta>() != null)
            {

                sonidosPersonaje[5].Stop();
                sonidosPersonaje[4].Play();
                collision.GetComponent<PuntoPregunta>().activarPuntoPregunta();
                ManejadorPreguntas.instanciaActiva.PuntoDePregunta = collision.GetComponent<PuntoPregunta>();
            }
            return;

        }

        if (collision.tag.Equals("Destructor"))
        {
            indiceDestructor = compararObjeto(collision.gameObject);
            // StartCoroutine(activarSonidoCallendo(collision.GetComponentInParent<AudioSource>()));



            collision.GetComponentsInParent<AudioSource>()[0].Play();
            Invoke("iniciarSonidoRespawn", 1.2f);

            if (indiceDestructor != -1)
            {
                gameObject.SetActive(false);
                ControladorHUD.instance.disminuirVida();
                Invoke("reaparecerPersonaje", 2f);
                
            }
            return;
        }

        if (collision.gameObject==profesora)
        {
            Debug.Log("Toca Profesora");

                collision.GetComponent<Collider2D>().enabled = false;
                collision.GetComponent<MoveOnPath>().currentWayPointID = 0;
                collision.GetComponent<MoveOnPath>().correr = true;
                collision.GetComponent<Animator>().SetBool("Correr", true);
                enemigo.SetActive(true);
        }

        if (collision.tag.Equals("LluviaBloques"))
        {
            ControladorHUD.instance.disminuirVida();
            Destroy(collision.gameObject);
            
            return;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag.Equals("Trampolin"))
        {
            sonidosPersonaje[3].Play();
        }
        if (collision.gameObject.tag.Equals("LluviaBloques") && !enDaño)
        {
            enDaño = true;
            ControladorHUD.instance.disminuirVida();
            Destroy(collision.gameObject);
            GetComponent<Animation>().Play();
            sonidosPersonaje[6].Play();
            return;
        }

        if (collision.gameObject.tag.Equals("Caen"))
        {

            StartCoroutine(desabilitarisKinematic(collision.gameObject));
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("PuntoRetro"))
        {

            sonidosPersonaje[4].Stop();
            sonidosPersonaje[5].Play();
            collision.GetComponent<PuntoRetroalimentacion>().OcultarPuntoRetro();
        }

        if (collision.tag.Equals("PuntoPregunta"))
        {

            if (collision.GetComponent<PuntoPregunta>() != null)
            {

                sonidosPersonaje[4].Stop();
                sonidosPersonaje[5].Play();
                collision.GetComponent<PuntoPregunta>().desactivarPuntoPregunta();

            }

        }

       

    }
    IEnumerator activarSonidoCallendo(AudioSource audio)
    {
        audio.Play();
       yield return new WaitForSeconds(2f);
        audio.Stop();
        yield return null; 

    }

    public int compararObjeto(GameObject obj)
    {
        for (int i = 0; i < destructores.Length; i++)
        {
            if (obj == destructores[i])
            {
                return i;
            }
        }
        return -1;
    }

    public void reaparecerPersonaje()
    {
        profesora.GetComponent<MoveOnPath>().Resetear();
        gameObject.transform.position = checkpoints[indiceDestructor].transform.position;
        gameObject.SetActive(true);
        enemigo.SetActive(false);
        Invoke("detenerSonidoRespawn", 1.7f);
        //sonidosPersonaje[6].Play();
        //Invoke("detenerSonidoRespawn", 1f);
    }

    public void RestablecerDeDaño()
    {
        enDaño = false;
    }

    IEnumerator desabilitarisKinematic(GameObject obj)
    {
        yield return new WaitForSeconds(0.2f);
        obj.GetComponent<Rigidbody2D>().isKinematic = false;
        yield return new WaitForSeconds(2f);

        Destroy(obj);
    }

    void iniciarSonidoRespawn()
    {
        destructores[0].GetComponentsInParent<AudioSource>()[1].Play();
    }

    void detenerSonidoRespawn()
    {
        destructores[0].GetComponentsInParent<AudioSource>()[1].Stop();
    }
}
