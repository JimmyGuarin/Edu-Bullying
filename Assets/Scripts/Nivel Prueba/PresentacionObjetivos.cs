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

    public void OnDisable()
    {
        Time.timeScale = 1;
    }
}
