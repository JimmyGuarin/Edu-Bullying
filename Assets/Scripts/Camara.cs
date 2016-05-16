using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour
{
    public void OnEnable()
    {
        GetComponent<CameraFollow>().enabled = false;
    }

    void Update()
    {
        if (GetComponent<CameraFollow>().target.transform.position.x >-5)
        {
            GetComponent<CameraFollow>().enabled = true;
        }
    }
}