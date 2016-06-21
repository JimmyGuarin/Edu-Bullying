using UnityEngine;
using UnityEngine.UI;
//using System.Collections;

public class Enemigo : MonoBehaviour
{


    public GameObject canvasConversacion;
    private bool enColision;
    public MovimientoPersonaje mp;


    public AudioSource audioFondo;

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
                mp.GetComponent<ControladorColisiones>().indiceDestructor = mp.GetComponent<ControladorColisiones>().destructores.Length - 1;
                mp.GetComponents<AudioSource>()[2].volume = 0;
                mp.enabled = false;
                HideMouse.SetCursorPos(Screen.width / 2, Screen.height / 4);
                transform.GetChild(0).gameObject.SetActive(false);
                canvasConversacion.SetActive(true);
                GetComponent<Collider2D>().enabled = false;
                enColision = false;
                audioFondo.volume = 0.05f;
                GetComponent<AudioSource>().Play();


               
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
