using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GuiManager : MonoBehaviour {


    public static int indexPersonaje = 0;

    

    public GameObject canvasSeleccionarPersonaje;
    public GameObject canvasMenuPrincipal;

    public GameObject[] offPersonajes;

    public GameObject imagenCarga;
    AsyncOperation async;

    public GameObject bottonCambiarEscena;
    public GameObject textoCargando;

    public GameObject[] imagenMenuPrincipal;
    public CanvasGroup fademe;
    public Fade fade;

    private bool listo;
    

    void Awake(){

        listo = false;

        


        if (indexPersonaje != 0)
        {
            canvasSeleccionarPersonaje.SetActive(false);
            offPersonajes[0].SetActive(true);
            offPersonajes[ControladorHUD.IndexPersonaje].SetActive(false);

            imagenMenuPrincipal[ControladorHUD.IndexPersonaje].SetActive(true);
            canvasMenuPrincipal.SetActive(true);

        }
       
    }
   
	// Use this for initialization
	void Start () {

       

	}
	
	// Update is called once per frame
	void Update () {

     

        if (async != null && async.progress==0.9f&& !listo)
        {

            Debug.Log("Entra a activar");
            listo = true;
          

            StartCoroutine("activarBoton");


        }

    }



    public void cambiarPersonaje(int intPersonaje)
    {
        indexPersonaje = intPersonaje;
        ControladorHUD.IndexPersonaje = indexPersonaje - 1;
        
    }

    public  void CerrarAplicacion() {

        Application.Quit();
    }

    public void Jugar()
    {
        
        imagenCarga.SetActive(true);
        imagenMenuPrincipal[ControladorHUD.IndexPersonaje].SetActive(false);
        StartCoroutine("load");
    }

    IEnumerator load()
    {
        Debug.LogWarning("ASYNC LOAD STARTED - " +
           "DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;
        textoCargando.SetActive(true);
        yield return async;
    }

    public void ActivateScene()
    {

        
        fademe.alpha =Fade.alpha;
        fademe.gameObject.SetActive(true);
       
        StartCoroutine(activarFameEscena()); 
           
        if (ControladorHUD.instance!=null)
            ControladorHUD.instance.gameObject.SetActive(true);
        


    }
    IEnumerator activarBoton()
    {
        Debug.Log("Entra A boton");
        yield return new WaitForSeconds(1f);
        textoCargando.SetActive(false);
        bottonCambiarEscena.SetActive(true);
    }

    IEnumerator activarFameEscena()
    {
        async.allowSceneActivation = true;
        while (!async.isDone)
        {
            
            Debug.Log("Entra a corrutina" + async.progress);
            fademe.alpha += Time.deltaTime / 2;
            Fade.alpha = fademe.alpha;
           
            yield return null;
        }
    }
}
