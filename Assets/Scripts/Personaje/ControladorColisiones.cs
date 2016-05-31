using UnityEngine;
using System.Collections;

public class ControladorColisiones : MonoBehaviour
{

    public GameObject profesora;
    public GameObject enemigo;
    public GameObject[] checkpoints;
    public GameObject[] destructores;
    private int indiceDestructor = -1;
    private bool enDaño;

    // Use this for initialization
    void Start()
    {
        enDaño = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("PuntoRetro"))
        {
            collision.GetComponent<PuntoRetroalimentacion>().MostrarPuntoRetro();
            return;
        }

        if (collision.tag.Equals("Coins"))
        {

            Destroy(collision.gameObject);
            ControladorHUD.instance.aumentarPuntaje(5, false);
            return;

        }


        if (collision.tag.Equals("Corazon"))
        {

            Destroy(collision.gameObject);
            ControladorHUD.instance.aumentarVida();
            return;

        }


        if (collision.tag.Equals("PuntoPregunta"))
        {

            if (collision.GetComponent<PuntoPregunta>() != null)
            {

                collision.GetComponent<PuntoPregunta>().activarPuntoPregunta();
                ManejadorPreguntas.instanciaActiva.PuntoDePregunta = collision.GetComponent<PuntoPregunta>();
            }
            return;

        }

        if (collision.tag.Equals("Destructor"))
        {
            indiceDestructor = compararObjeto(collision.gameObject);
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
        if (collision.gameObject.tag.Equals("LluviaBloques") && !enDaño)
        {
            enDaño = true;
            ControladorHUD.instance.disminuirVida();
            Destroy(collision.gameObject);
            GetComponent<Animation>().Play();
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

            collision.GetComponent<PuntoRetroalimentacion>().OcultarPuntoRetro();
        }

        if (collision.tag.Equals("PuntoPregunta"))
        {

            if (collision.GetComponent<PuntoPregunta>() != null)
            {

                collision.GetComponent<PuntoPregunta>().desactivarPuntoPregunta();
            }

        }

       

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
}
