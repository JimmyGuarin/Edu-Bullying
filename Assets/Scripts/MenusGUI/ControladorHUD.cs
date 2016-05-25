using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControladorHUD : MonoBehaviour
{

    public static ControladorHUD instance;

    //Variables controladoras del HUD
    public static int puntajeTotal = 0;
    public static int numeroVidas = 4;
    public static bool[] nivelesSuperados = new bool[7];
    public static int IndexPersonaje;
    public static int nivelActual;

    //Tipos de HUD
    public GameObject canvasHudPlay;
    public GameObject canvasHud;
    public GameObject imagenVictoria;


    //Propiedades del inspector
    public Image[] bombillas;
    public Image[] corazones;
    public GameObject[] personajes;
    public Text textoPuntaje;
    public Slider BarraConocimiento;

    //Colores Bombillaswe
    public Color colorBombillaApagada;
    public Color colorBombillaEncendida;

    private static Vector3 posicionPlayer;

    void Awake()
    {



        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    // Use this for initialization
    void Start()
    {



        personajes[IndexPersonaje].SetActive(true);



    }


    public void aumentarPuntaje(int cantidad, bool conocimiento)
    {

        puntajeTotal += cantidad;
        textoPuntaje.text = "" + puntajeTotal;
        if (conocimiento)
            StartCoroutine(AumentarConocimiento((int)(cantidad)));
    }

    IEnumerator AumentarConocimiento(int valor)
    {


        while (valor > 0)
        {
            BarraConocimiento.value += 1;
            valor--;

            switch ((int)BarraConocimiento.value)
            {
                case 36:
                    bombillas[0].color = colorBombillaEncendida;
                    break;
                case 68:
                    bombillas[1].color = colorBombillaEncendida;
                    break;
                case 97:
                    bombillas[2].color = colorBombillaEncendida;
                    break;
            }

            if (BarraConocimiento.value == 36)
            {
                bombillas[0].color = colorBombillaEncendida;
            }

            yield return new WaitForSeconds(0.05f);
        }
    }

    public void OnEnable()
    {

        personajes[IndexPersonaje].SetActive(true);
    }



    //Returna false si se quedo sin vidas
    public bool disminuirVida()
    {

        numeroVidas--;
        if (numeroVidas == -1)
            return false;

        corazones[numeroVidas].color = colorBombillaApagada;
        return true;


    }

    public void aumentarVida()
    {
        if (numeroVidas < 4)
        {
            corazones[numeroVidas].color = colorBombillaEncendida;
            numeroVidas++;
        }


    }

    public void cargarCanvarJugable()
    {
        canvasHud.SetActive(false);
        canvasHudPlay.SetActive(true);
        foreach (Image bombilla in bombillas)
        {

            bombilla.color = colorBombillaApagada;
            BarraConocimiento.value = 0;
        }
    }

    public void cargarCanvasCorredor()
    {
        canvasHud.SetActive(true);
        canvasHudPlay.SetActive(false);
    }

    public void GanarNivel()
    {
        imagenVictoria.SetActive(true);
        nivelesSuperados[nivelActual] = true;

    }


    //MetodoLlamado si se ganó el nivel
    public void irACorredor(int nivelJugado)
    {
        Destroy(gameObject);
    }

    public void MenuPrincipal()
    {
        gameObject.SetActive(false);
        personajes[IndexPersonaje].SetActive(false);
        SceneManager.LoadScene(0);


    }
}
