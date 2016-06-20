using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PresentacionObjetivos : MonoBehaviour
{
    private MovimientoPersonaje mp;
  

    // Use this for initialization
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(transform.GetChild(0).FindChild("Button").gameObject);
        mp = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoPersonaje>();
        mp.enabled = false;
        //Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Deshabilitar()
    {
        gameObject.SetActive(false);
        mp.enabled = true;
    }

    public void Funcion()
    {
        EventSystem.current.SetSelectedGameObject(null);
        Time.timeScale = 1;
        GetComponent<Animation>().Play();
        GameObject.Find("Escenario").GetComponent<AudioSource>().Play();
        
    }
}
