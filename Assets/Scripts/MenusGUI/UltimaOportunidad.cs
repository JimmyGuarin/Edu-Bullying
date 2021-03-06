﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UltimaOportunidad : MonoBehaviour
{


    public Text enunciado;
    public Button[] botones;
    public GameObject botonCerrar;
    public GameObject botonCerrar2;
    public Text textoPuntaje;
    public GameObject corazon;
    public Text textoRetro;

    public AudioSource audioFondo;


    private ArrayList puntosRetro;
    private Preguntas pregunta;
    private PuntosRetro pr;

   
  

   void Start()
    {

        //puntosRetro = ManejadorPreguntas.instanciaActiva.misPuntosRetro;
        //pr = (PuntosRetro)puntosRetro[(int)Random.Range(0, puntosRetro.Count - 1)];
        //pr.Barajar();
        //Moldear();
        //Time.timeScale = 0;

    }

    public void OnEnable()
    {
        HideMouse.SetCursorPos(Screen.width / 2, Screen.height / 4);
        EventSystem.current.SetSelectedGameObject(null);
        puntosRetro = ManejadorPreguntas.instanciaActiva.misPuntosRetro;
        ResetearCanvas();
        pr = (PuntosRetro)puntosRetro[(int)Random.Range(0, puntosRetro.Count - 1)];
        pr.Barajar();
        Moldear();
        StartCoroutine(Activar());
        //Time.timeScale = 0;
        Debug.Log("Entra");
    }

    void Moldear()
    {
        
        int indice = 0;

        pregunta = (Preguntas)pr.misPreguntas[indice];

        while (!pregunta.IsMultiple)
        {
            indice++;
            if (indice >= pr.misPreguntas.Count)
                indice = 0;
            pregunta = (Preguntas)pr.misPreguntas[indice];
        }

        pregunta.Barajar(pregunta.Respuestas);
        enunciado.text = pregunta.Enunciado;
        for (int i = 0; i < 4; i++)
        {
            botones[i].GetComponentInChildren<Text>().text = pregunta.Respuestas[i];
        }
       
    }


    public void VerificarRespuesta(Button botonPrecionado)
    {
        botonPrecionado.transform.GetChild(0).GetComponent<Text>().color = Color.white;

        if (pregunta.EsCorrecta(botonPrecionado.transform.GetChild(0).GetComponent<Text>().text))
        {

            botonPrecionado.GetComponent<Image>().color = Color.green;
            textoPuntaje.text = " Conseguiste una Vida";
            ControladorHUD.instance.aumentarVida();
            botonCerrar.SetActive(true);
            EventSystem.current.SetSelectedGameObject(botonCerrar);
            corazon.SetActive(true);
        }
        else
        {
            botonPrecionado.GetComponent<Image>().color = Color.red;
            textoPuntaje.text = "No conseguiste una vida";
            botonCerrar2.SetActive(true);
            EventSystem.current.SetSelectedGameObject(botonCerrar2);

        }



        textoRetro.text = "Respuesta Correcta:    <size=60><color=green>" + RespuestaCorrecta(pregunta.IndexCorreta()) + "</color></size>";
        textoPuntaje.transform.parent.gameObject.SetActive(true);
        textoRetro.transform.parent.gameObject.SetActive(true);




    }


    public char RespuestaCorrecta(int index)
    {
        switch (index)
        {
            case 0:
                return 'A';
            case 1:
                return 'B';
            case 2:
                return 'C';
            case 3:
                return 'D';

        }
        return 'E';

    }


    public void ContinuarNivel()
    {
        Time.timeScale = 1;
        ControladorColisiones cc = GameObject.FindGameObjectWithTag("Player").GetComponent<ControladorColisiones>();

        cc.sonidosPersonaje[2].volume = 1;
        if (cc.indiceDestructor != -1)
        {
            Debug.Log(cc.indiceDestructor + " destructor");
            GameObject.FindGameObjectWithTag("Player").GetComponent<ControladorColisiones>().reaparecerPersonaje();
            
        }
        
            
    }

    public void MenuPrincipal()
    {
        Time.timeScale = 1;
        Debug.Log("Menu Principal");
        ControladorHUD.numeroVidas = 0;
        ControladorHUD.instance.aumentarVida();
        ControladorHUD.instance.aumentarVida();
        SceneManager.LoadScene(2);
    }


    public void ReiniciarNivel()
    {
        Time.timeScale = 1;
        ControladorHUD.numeroVidas = 0;
        ControladorHUD.instance.aumentarVida();
        ControladorHUD.instance.aumentarVida();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ControladorHUD.instance.cargarCanvarJugable();
    }

    public void ResetearCanvas()
    {
        foreach (Button b in botones)
        {

            b.GetComponent<Image>().color = Color.white;
            b.interactable = true;
            b.transform.GetChild(0).GetComponent<Text>().color = Color.black;
        }

    }

    IEnumerator  Activar()
    {
        yield return new WaitForEndOfFrame();
        audioFondo = GameObject.Find("Escenario").GetComponent<AudioSource>();
        audioFondo.volume = 0.05f;
        Debug.Log("activeb");
        EventSystem.current.SetSelectedGameObject(botones[0].gameObject);
        
    }
}
