using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Pausa : MonoBehaviour
{


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
        SceneManager.LoadScene(1);
    }

    public void ManejarSonido()
    {

    }
}
