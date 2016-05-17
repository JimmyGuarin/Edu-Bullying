using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GuiManager : MonoBehaviour {


    public static int indexPersonaje=0;

    public GameObject canvasSeleccionarPersonaje;
    public GameObject canvasMenuPrincipal;

    public GameObject imagenCarga;
    AsyncOperation async;

    public GameObject bottonCambiarEscena;
    public GameObject textoCargando;

    void Awake(){

        if (indexPersonaje != 0)
        {
            canvasSeleccionarPersonaje.SetActive(false);
            canvasMenuPrincipal.SetActive(true);
        }
    }
   
	// Use this for initialization
	void Start () {

       

	}
	
	// Update is called once per frame
	void Update () {
	
	}



    public void cambiarPersonaje(int intPersonaje)
    {
        indexPersonaje = intPersonaje;
    }

    public  void CerrarAplicacion() {

        Application.Quit();
    }

    public void Jugar()
    {
        ControladorHUD.IndexPersonaje = indexPersonaje-1;
        imagenCarga.SetActive(true);
        StartCoroutine("load");
    }

    IEnumerator load()
    {
        Debug.LogWarning("ASYNC LOAD STARTED - " +
           "DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
        async = SceneManager.LoadSceneAsync(1);



        async.allowSceneActivation = false;
        textoCargando.SetActive(false);
        bottonCambiarEscena.SetActive(true);

        yield return async;
    }

    public void ActivateScene()
    {
        async.allowSceneActivation = true;
    }

}
