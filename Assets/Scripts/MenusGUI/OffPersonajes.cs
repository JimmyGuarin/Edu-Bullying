using UnityEngine;
using System.Collections;

public class OffPersonajes : MonoBehaviour
{
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void Activar()
    {
        if (this.gameObject.activeSelf == true)
        {

            if (anim.GetInteger("Estado") != 1)
            {
                anim.SetInteger("Estado", 1);
            }
        }
    }

    public void Desactivar()
    {
        if (this.gameObject.activeSelf == true)
        {

            if (anim.GetInteger("Estado") != 2)
            {
                anim.SetInteger("Estado", 2);
            }
        }

    }


    public void OnDisable()
    {
        GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }
}
