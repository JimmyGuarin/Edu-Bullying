using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections;

public class Pausa : MonoBehaviour
{
    public AudioMixer master;

    public bool silencio=false;

    public GameObject panelPausa;


    // Use this for initialization
    void Start()
    {
        

    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("p")|| Input.GetKeyDown(KeyCode.Escape))
        {
            ControladorHUD.instance.GetComponent<AudioSource>().Play();
            ToggleMenuPausa();
        }

    }

    public void ToggleMenuPausa()
    {

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            gameObject.SetActive(false);
            panelPausa.SetActive(true);
            EventSystem.current.SetSelectedGameObject(panelPausa.transform.GetChild(0).GetChild(0).gameObject);
        }
        else
        {
            Time.timeScale = 1;
            gameObject.SetActive(true);
            panelPausa.SetActive(false);
            EventSystem.current.SetSelectedGameObject(null);
        }


    }

   



    public void MenuCorredor()
    {
        Time.timeScale = 1;
        Debug.Log(ControladorHUD.numeroVidas);

        if (ControladorHUD.numeroVidas <= 0)
        {
            ControladorHUD.numeroVidas = 0;
            Debug.Log("Entra aumenta");
            ControladorHUD.instance.aumentarVida();
            ControladorHUD.instance.aumentarVida();
        }
        
        //Destroy(GameObject.Find("CanvasHUD"));
        SceneManager.LoadScene(2);
    }

    public void ManejarSonido()
    {
       

        if (!silencio)
        {
            master.SetFloat("silenciar",-80);
            silencio = true;
            EventSystem.current.SetSelectedGameObject(panelPausa.transform.GetChild(0).GetChild(3).gameObject);

        }
        else
        {
            master.SetFloat("silenciar", 0);
            silencio =false;
            EventSystem.current.SetSelectedGameObject(panelPausa.transform.GetChild(0).GetChild(2).gameObject);
        }
    
                
     }
}
