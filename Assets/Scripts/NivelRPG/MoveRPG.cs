﻿using UnityEngine;
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

    public string nombreNivel;
    public GameObject canvasInfografias;
    public GameObject textoCargando;
    public GameObject ButtonComenzar;

    public CanvasGroup fademe;

    public Sprite[] imagenesJugadores;

    private AsyncOperation async;

    void Start()
    {

        nombreNivel = "";
        enColision = false;
        canvasNiveles= GameObject.Find("Canvas");
        curSpeed = (float)(2);
        anim = GetComponent<Animator>();
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = imagenesJugadores[ControladorHUD.IndexPersonaje];

    }

    public void Update()
    {
        if (enColision && Input.GetKeyDown("f"))
        {
            enColision = false;
            canvasInfografias.transform.Find(nombreNivel).gameObject.SetActive(true);
            canvasInfografias.SetActive(true);
            
            
            StartCoroutine(load());
            return;
           
        }

        if (async != null && async.progress >= 0.9f)
        {
            textoCargando.SetActive(false);
            ButtonComenzar.SetActive(true);
          

        }

       
    }

    void FixedUpdate()
    {

        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            anim.SetInteger("Estado", 1);

            if (Input.GetAxisRaw("Horizontal") < 0)
                transform.localScale = new Vector3(-0.1f, 0.1f, 1);
            else
                transform.localScale = new Vector3(0.1f, 0.1f, 1);

            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Lerp(0, Input.GetAxisRaw("Horizontal") * curSpeed, 1), 0);
        }
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") != 0)
        {

            anim.SetInteger("Estado", 1);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, Mathf.Lerp(0, Input.GetAxisRaw("Vertical") * curSpeed, 1));
        }

        if ((Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) || (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0))
        {
            anim.SetInteger("Estado", 0);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }


    IEnumerator load()
    {
        

        async = SceneManager.LoadSceneAsync(nombreNivel);
        async.allowSceneActivation = false;
        

        yield return async;
       
    }

    public void ActivateScene()
    {
        fademe.alpha = 1f;
        fademe.gameObject.SetActive(true);

        StartCoroutine(activarFameEscena());

        ControladorHUD.instance.cargarCanvarJugable();
       
    }





    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("GameController"))
        {
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

            ControladorHUD.instance.cogerCorazon(collision.gameObject);
            enColision = false;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (enColision&&!collision.tag.Equals("Corazon"))
        {
            
            canvasNiveles.transform.FindChild(collision.name).GetComponent<Animator>().SetBool("Salida", true);
        }
        enColision = false;

    }


    IEnumerator activarFameEscena()
    {
        async.allowSceneActivation = true;
        while (!async.isDone)
        {

            Debug.Log("Entra a corrutina" + async.progress);
            fademe.alpha -= Time.deltaTime / 2;
            Fade.alpha = fademe.alpha;

            yield return null;
        }
    }
}