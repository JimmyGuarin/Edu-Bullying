using UnityEngine;
using System.Collections;

public class PresentacionObjetivos : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        Time.timeScale = 0;
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
        Time.timeScale = 1;
        GetComponent<Animation>().Play();
        
    }
}
