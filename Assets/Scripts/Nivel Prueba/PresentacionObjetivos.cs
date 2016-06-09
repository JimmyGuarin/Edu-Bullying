using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PresentacionObjetivos : MonoBehaviour
{

  

    // Use this for initialization
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(transform.GetChild(0).FindChild("Button").gameObject);
        //Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Deshabilitar()
    {
        gameObject.SetActive(false);
    }

    public void Funcion()
    {
        EventSystem.current.SetSelectedGameObject(null);
        Time.timeScale = 1;
        GetComponent<Animation>().Play();
        
    }
}
