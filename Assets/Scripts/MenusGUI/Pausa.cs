using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections;

public class Pausa : MonoBehaviour
{
    public AudioMixer master;

    public bool silencio=false;

    


    // Use this for initialization
    void Start()
    {
        

    }


    // Update is called once per frame
    void Update()
    {

    }

    public void OnEnable()
    {

       Time.timeScale = 0;

    }

    public void OnDisable()
    {

       Time.timeScale = 1;
    }


    public void MenuCorredor()
    {

        //Destroy(GameObject.Find("CanvasHUD"));
        SceneManager.LoadScene(2);
    }

    public void ManejarSonido()
    {
        if (!silencio)
        {
            master.SetFloat("silenciar",-80);
            silencio = true;
        }
        else
        {
            master.SetFloat("silenciar", 14);
            silencio =false;
        }
    
                
     }
}
