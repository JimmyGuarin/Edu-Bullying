using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControladorColegio : MonoBehaviour {

    public static ControladorColegio instancia;
    public RuntimeAnimatorController[] controladoresAnimaciones;
    public Sprite[] imagenesColorNiveles;

    

    private GameObject jugador;
    private GameObject mapa;
   
    void Awake()
    {

       
        instancia = this;
        mapa = transform.GetChild(0).gameObject;
        jugador = GameObject.FindGameObjectWithTag("Player");
        jugador.GetComponent<Animator>().runtimeAnimatorController = controladoresAnimaciones[ControladorHUD.IndexPersonaje];

    }

    // Use this for initialization
    void Start () {


        NivelSuperado();
        ControladorHUD.instance.cargarCanvasCorredor();
        

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NivelSuperado() {

        for(int i = 0; i < ControladorHUD.nivelesSuperados.Length; i++)
        {

            if (ControladorHUD.nivelesSuperados[i] != false)
            {
                mapa.transform.GetChild(i-1).GetComponent<SpriteRenderer>().sprite = imagenesColorNiveles[i-1];
            }
        }

    }

  

}
