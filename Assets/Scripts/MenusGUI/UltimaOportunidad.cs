using UnityEngine;
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
        puntosRetro = ManejadorPreguntas.instanciaActiva.misPuntosRetro;
        ResetearCanvas();
        pr = (PuntosRetro)puntosRetro[(int)Random.Range(0, puntosRetro.Count - 1)];
        pr.Barajar();
        Moldear();
        Time.timeScale = 0;
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
            corazon.SetActive(true);
        }
        else
        {
            botonPrecionado.GetComponent<Image>().color = Color.red;
            textoPuntaje.text = "No conseguiste una vida";
            botonCerrar2.SetActive(true);
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
        if (cc.indiceDestructor != -1)
        {
            Debug.Log(cc.indiceDestructor + " destructor");
            GameObject.FindGameObjectWithTag("Player").GetComponent<ControladorColisiones>().reaparecerPersonaje();
            
        }
            
    }

    public void MenuPrincipal()
    {
        Time.timeScale = 1;
        ControladorHUD.instance.aumentarVida();
        ControladorHUD.instance.aumentarVida();
        SceneManager.LoadScene(2);
    }


    public void ReiniciarNivel()
    {
        Time.timeScale = 1;
        ControladorHUD.instance.aumentarVida();
        ControladorHUD.instance.aumentarVida();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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


}
