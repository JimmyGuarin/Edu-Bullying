using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class MaquinaEstadosConver : MonoBehaviour
{


    public EstadoConversacion[] estados;

    private int estadoActual;
    private AudioSource[] audios;

    public Sprite[] imagenesVillano;

    public Sprite[] imagenesArnold;
    public Sprite[] imagenesKeily;
    public Sprite[] imaganesFred;
    public Sprite[] imagenesFill;

    //public Image personajePlayerNpc;
    public Text textoPlayerNpc;
    public Button[] botonesNpc;
    public Slider SliderVillano;
    public Image imagenActualVillano;
    public Image imagenVictimaActual;
    public Sprite[] imagenesVActual;
    public Text textoVictima;
    void Start()
    {
        estadoActual = 0;
        audios = GetComponents<AudioSource>();
        Moldear();
        SeleccionarVictima();
        StartCoroutine(activar());

    }


    public void CambiarEstado(int i)
    {

        estadoActual = estados[estadoActual].proximos[i];
        int suma = estados[estadoActual].tipo;
        StartCoroutine(MoverSlider(suma));
        Moldear();

    }

    public void Moldear()
    {
        EstadoConversacion converActual = estados[estadoActual];


        //switch (converActual.tipo)
        //{
        //    case 0:
        // personajePlayerNpc.sprite = imagenProfesora;
        textoPlayerNpc.text = converActual.pregunta.Enunciado;
        for (int i = 0; i < 3; i++)
        {

            if (converActual.proximos != null && converActual.proximos.Length > 3)
            {

                botonesNpc[i].onClick.AddListener(() => { CambiarEstado(converActual.proximos[i]); });
            }
            botonesNpc[i].GetComponentInChildren<Text>().text = converActual.pregunta.Respuestas[i];


        }
        // gameObject.SetActive(true);
        //  break;

        // }
    }

    IEnumerator MoverSlider(int valor)
    {
        if (valor < 0)
            audios[0].Play();
        else
            audios[1].Play();

        while (valor != 0)
        {

            if (valor < 0)
            {

                valor++;
                SliderVillano.value -= 1;
            }

            else
            {
                SliderVillano.value += 1;
                valor--;
            }


            switch ((int)SliderVillano.value)
            {
                case 20:

                    imagenActualVillano.sprite = imagenesVillano[0];
                    imagenVictimaActual.sprite = imagenesVActual[0];
                    break;
                case 30:
                    imagenActualVillano.sprite = imagenesVillano[1];
                    imagenVictimaActual.sprite = imagenesVActual[1];
                    break;
                case 50:
                    imagenActualVillano.sprite = imagenesVillano[2];
                    break;
                case 0:
                    this.gameObject.SetActive(false);
                    estadoActual = 0;
                    Moldear();
                    SliderVillano.value = 30;
                    GameObject jugador = GameObject.FindGameObjectWithTag("Player");
                    jugador.GetComponent<Animation>().Play();
                    jugador.GetComponent<MovimientoPersonaje>().enabled = true;
                    jugador.GetComponent<ControladorColisiones>().enemigo.GetComponent<Collider2D>().enabled = true;
                    jugador.GetComponents<AudioSource>()[2].volume =1;
                    ControladorHUD.instance.disminuirVida();
                    break;
                case 60:

                    Invoke("terminarConversacion", 1f);

                    break;

            }

            yield return new WaitForSeconds(0.05f);
        }


    }



    void terminarConversacion()
    {
        this.gameObject.SetActive(false);
        ControladorHUD.instance.GanarNivel();

    }

    void SeleccionarVictima()
    {
        //imagenActualVictima.sprite = imagenesVictimas[ControladorHUD.IndexPersonaje];
        switch (ControladorHUD.IndexPersonaje)
        {
            case 0:
                textoVictima.text = "ARNOLD";
                imagenesVActual = imagenesArnold;
                break;
            case 1:
                textoVictima.text = "KEILY";
                imagenesVActual = imagenesKeily;
                break;
            case 2:
                textoVictima.text = "FRED";
                imagenesVActual = imaganesFred;
                break;
            case 3:
                textoVictima.text = "FILL";
                imagenesVActual = imagenesFill;
                break;

        }
        imagenVictimaActual.sprite = imagenesVActual[1];

    }

    IEnumerator activar()
    {
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(botonesNpc[0].gameObject);
    }

    public void OnEnable()
    {
        StartCoroutine(activar());
    }
}
