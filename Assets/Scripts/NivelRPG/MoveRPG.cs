using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MoveRPG : MonoBehaviour
{


    // Normal Movements Variables
    private float walkSpeed;
    private float curSpeed;
    private GameObject canvasNiveles;
    private bool enColision;
    private Animator anim;
    private bool listo;


    public string nombreNivel;
    public GameObject canvasInfografias;
    public GameObject textoCargando;
    public GameObject ButtonComenzar;

    public CanvasGroup fademe;

    public Sprite[] imagenesJugadores;

    private AsyncOperation async;

    public AudioSource[] audios;

    void Start()
    {

        if (ControladorHUD.instance.panelPuntajes.activeSelf)
            this.enabled = false;


        audios = GetComponents<AudioSource>();
        nombreNivel = "";
        enColision = false;
        canvasNiveles = GameObject.Find("Canvas");
        curSpeed = (float)(2);
        anim = GetComponent<Animator>();
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = imagenesJugadores[ControladorHUD.IndexPersonaje];
        listo = false;
    }

    public void Update()
    {
        if (enColision && Input.GetKeyDown("f"))
        {
            enColision = false;
            audios[3].Play();
            canvasInfografias.transform.Find(nombreNivel).gameObject.SetActive(true);
            canvasInfografias.SetActive(true);


            StartCoroutine(load());
            return;

        }

        if (async != null && async.progress >= 0.9f&& !listo)
        {
            listo = true;
            StartCoroutine("activarBoton");

        }


    }

    void FixedUpdate()
    {
        if ((Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0))
        {

            if (audios[0].isPlaying)
                audios[0].Stop();

            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
           
        }



        if (Input.GetAxisRaw("Horizontal") != 0 )
        {
            anim.SetBool("Avanzar", false);
            anim.SetInteger("Estado", 0);


            if (Input.GetAxisRaw("Horizontal") < 0)
                transform.localScale = new Vector3(-0.2f, 0.2f, 1f);
            else
                transform.localScale = new Vector3(0.2f, 0.2f, 1f);

            if (!audios[0].isPlaying)
                audios[0].Play();
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Lerp(0, Input.GetAxisRaw("Horizontal") * curSpeed, 1), 0);
        }


        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") != 0)
        {

            anim.SetBool("Avanzar", false);
            if (Input.GetAxisRaw("Vertical") > 0)
                anim.SetInteger("Estado", 1);
            else
                anim.SetInteger("Estado", 2);

            if (!audios[0].isPlaying)
                audios[0].Play();
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, Mathf.Lerp(0, Input.GetAxisRaw("Vertical") * curSpeed, 1));

        }

      
        if (GetComponent<Rigidbody2D>().velocity==Vector2.zero)
            anim.SetBool("Avanzar", true);

    }


  

    IEnumerator load()
    {


        async = SceneManager.LoadSceneAsync(nombreNivel);
        async.allowSceneActivation = false;


        yield return async;

    }

    public void ActivateScene()
    {
       
        fademe.gameObject.SetActive(true);

        StartCoroutine(activarFameEscena());

        ControladorHUD.instance.cargarCanvarJugable();

    }

    IEnumerator activarBoton()
    {
        Debug.Log("Entra A boton");
        yield return new WaitForSeconds(1f);
        textoCargando.SetActive(false);
        ButtonComenzar.SetActive(true);
    }





    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("GameController"))
        {
            audios[2].Play();
            enColision = true;
        }

        if (enColision)
        {
            nombreNivel = collision.name;
            GameObject nivel = canvasNiveles.transform.FindChild(nombreNivel).gameObject;
            nivel.SetActive(true);
            nivel.GetComponent<Animator>().SetBool("Salida", false);
        }


        if (collision.tag.Equals("Corazon"))
        {
            audios[1].Play();
            ControladorHUD.instance.cogerCorazon(collision.gameObject);
            enColision = false;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (enColision && !collision.tag.Equals("Corazon"))
        {
            //audios[2].Play();
            canvasNiveles.transform.FindChild(collision.name).GetComponent<Animator>().SetBool("Salida", true);
        }
        enColision = false;

    }


    IEnumerator activarFameEscena()
    {
        async.allowSceneActivation = true;
        fademe.alpha = 0;
        while (!async.isDone)
        {

            Debug.Log("Entra a corrutina" + async.progress);
            fademe.alpha += Time.deltaTime / 2;
            Fade.alpha = fademe.alpha;

            yield return null;
        }
    }
}