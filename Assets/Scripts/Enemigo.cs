using UnityEngine;
using UnityEngine.UI;
//using System.Collections;

public class Enemigo : MonoBehaviour
{


    public GameObject canvasConversacion;
    private bool enColision;
    public MovimientoPersonaje mp;

    // Use this for initialization
    void Start()
    {

        enColision = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (enColision)
        {

            if (Input.GetKeyDown("f"))
            {
                GameObject.Find("CanvasPreguntas").GetComponent<AudioSource>().Play();
                mp.enabled = false;
                transform.GetChild(0).gameObject.SetActive(false);
                canvasConversacion.SetActive(true);
                GetComponent<Collider2D>().enabled = false;
                enColision = false;

               
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.SetActive(false);
        enColision = false;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {

        transform.GetChild(0).gameObject.SetActive(true);
        enColision = true;
    }
}
