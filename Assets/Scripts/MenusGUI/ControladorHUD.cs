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
    public static string nombreJugador = "";
    public static int posicionPuntajes = 0;
    public static bool[] nivelesSuperados = new bool[7];
    public static int IndexPersonaje;
    public static int nivelActual;

    //Tipos de HUD
    public GameObject canvasHudPlay;
    public GameObject canvasHud;
    public GameObject imagenVictoria;
    public GameObject panelDerrota;
    public Text textoPuntajes;
    public GameObject panelPuntajes;
    public GameObject pedirNombre;
    public GameObject jugador;
   

    //Propiedades del inspector
    public Image[] bombillas;
    public Image[] corazones;
    public GameObject[] personajes;
    public Text textoPuntaje;
  
    public Slider BarraConocimiento;
    public bool[] indexcorazonesrpg;
    //Colores Bombillaswe
    public Color colorBombillaApagada;
    public Color colorBombillaEncendida;

    private static Vector3 posicionPlayer;
    private GameObject corazonesrpg;

    private AudioSource sonido;
   

    void Awake()
    {



        if (instance == null)
        {
            instance = this;
            indexcorazonesrpg = new bool[4];
            corazonesrpg = GameObject.Find("corazones");
            DontDestroyOnLoad(this.gameObject);
            sonido = GetComponents<AudioSource>()[1];
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
        if(!sonido.isPlaying)
            sonido.Play();

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
    public void disminuirVida()
    {

        numeroVidas--;
        if (numeroVidas == 0)
        {
            corazones[numeroVidas].color = colorBombillaApagada;
            panelDerrota.SetActive(true);
          
        }
        if (numeroVidas >0)
        {
            Debug.Log(numeroVidas);
            corazones[numeroVidas].color = colorBombillaApagada;
           
        }
     
       


    }

    public void aumentarVida()
    {
        if (numeroVidas < 4)
        {
            if (numeroVidas < 0)
                numeroVidas = 0;
            corazones[numeroVidas].color = colorBombillaEncendida;
            numeroVidas++;
        }


    }

    public void cargarCanvarJugable()
    {
        canvasHud.SetActive(false);
        canvasHudPlay.SetActive(true);
        //corazonesrpg.SetActive(false);
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
        corazonesrpg = GameObject.Find("corazones");
        for (int i = 0; i < indexcorazonesrpg.Length; i++)
        {
            if (indexcorazonesrpg[i] == true)
                corazonesrpg.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void GanarNivel()
    {
        imagenVictoria.SetActive(true);
        nivelesSuperados[nivelActual] = true;

    }


    //MetodoLlamado si se ganó el nivel
    public void irACorredor()
    {

        SceneManager.LoadScene(2);

        if (posicionPuntajes == 0)
        {
            OnLevelComplete();
        }
        
        finalizarJuego();
        

    }

    public void MenuPrincipal()
    {
        gameObject.SetActive(false);
        personajes[IndexPersonaje].SetActive(false);
        SceneManager.LoadScene(1);


    }

    public  void cogerCorazon(GameObject corazon)
    {
      

        for (int i = 0; i < corazonesrpg.transform.childCount; i++)
        {
            if (corazonesrpg.transform.GetChild(i).gameObject == corazon)
            {
                corazonesrpg.transform.GetChild(i).gameObject.SetActive(false);
                indexcorazonesrpg[i] = true;
                ControladorHUD.instance.aumentarVida();
                return;
            }
        }
    }


    public static void OnLevelComplete()
    {
        int temp = 0;
        string nameTemp = "";
        int s =puntajeTotal;
        //values from your scoring logic 
        for (int i = 1; i <= 5; i++) //for top 5 highscores 
        {
            if (PlayerPrefs.GetInt("highscorePos" + i) < s) //if cuurent score is in top 5 
            {
                temp = PlayerPrefs.GetInt("highscorePos" + i); //store the old highscore in temp varible to shift it down 
                nameTemp = PlayerPrefs.GetString("nombre" + i);
                PlayerPrefs.SetInt("highscorePos" + i, s); //store the currentscore to highscores 
                if (i < 5) //do this for shifting scores down 
                {
                    int j = i + 1;
                    s = PlayerPrefs.GetInt("highscorePos" + j); //Try and put this here 
                    PlayerPrefs.SetInt("highscorePos" + j, temp);
                    PlayerPrefs.SetString("nombre" + j, nameTemp);
                }
            }
        }


        for (int i = 1; i <= 5; i++) //for top 5 highscores 
        {
            Debug.Log("Puntaje "+i+""+PlayerPrefs.GetInt("highscorePos" + i));
        }
    }


    public  void finalizarJuego()
    {

       
       
        int pos = posicionPuntajes;

        if (posicionPuntajes != 0&&PlayerPrefs.GetInt("highscorePos" +posicionPuntajes)!=puntajeTotal)
        {
            PlayerPrefs.SetInt("highscorePos" + posicionPuntajes, puntajeTotal);
            if (nombreJugador.Equals(""))
                PlayerPrefs.SetString("nombre" + posicionPuntajes, "Anónimo");
            else
                PlayerPrefs.SetString("nombre" + posicionPuntajes, nombreJugador);
            for (int j = 1; j < 5; j++)
            {

                for (int i = 1; i < 5; i++)
                {
                    if (PlayerPrefs.GetInt("highscorePos" + i) < PlayerPrefs.GetInt("highscorePos" + (i + 1)))
                    {
                        int tmp = PlayerPrefs.GetInt("highscorePos" + (i + 1));
                        string nombretmp = PlayerPrefs.GetString("nombre" + (i + 1));

                        PlayerPrefs.SetString("nombre" + (i + 1), PlayerPrefs.GetString("nombre" + i));
                        PlayerPrefs.SetInt("highscorePos" + (i + 1), PlayerPrefs.GetInt("highscorePos" + i));

                        PlayerPrefs.SetString("nombre" + i, nombretmp);
                        PlayerPrefs.SetInt("highscorePos" + i, tmp);
                    }
                }
            }
        }
     
        for (int i = 5; i >= 1; i--)
        {
                if (PlayerPrefs.GetInt("highscorePos" + i) == puntajeTotal)
                {
                    Debug.Log("entraaa");
                    posicionPuntajes = i;
                }
        }



        if (pos != posicionPuntajes)
        {

            if (nombreJugador.Equals(""))
            {

                pedirNombre.SetActive(true);
            }
            textoPuntajes.text = "Felicidades <color=#a52a2aff>" + nombreJugador + "</color>, alcanzaste la posicion <color=#a52a2aff><b><size=65>" + posicionPuntajes + "</size></b></color> en la Tabla de Posiciones";
            panelPuntajes.SetActive(true);
          
            

        }

           

    }

    public void AlmacenarNombre(Text nombre)
    {
        

        if (nombre.text.Equals("") && nombreJugador.Equals(""))
        {
            nombre.text = "Anónimo";
            PlayerPrefs.SetString("nombre" + posicionPuntajes, nombre.text);
        }

        else
        {
            if (nombreJugador.Equals(""))
                nombreJugador = nombre.text;
            PlayerPrefs.SetString("nombre" + posicionPuntajes, nombreJugador);
        }
        Debug.Log("Nombre Jugador: " + nombreJugador);
        nombre.text = "";
        GameObject.FindGameObjectWithTag("Player").GetComponent<MoveRPG>().enabled = true;
    }




}
