using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour
{


    private float velocidad = 0f;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(GameObject.Find("CharacterRobotBoy").GetComponent<Rigidbody2D>().velocity.x);

        

        float velfinal = GameObject.Find("CharacterRobotBoy").GetComponent<Rigidbody2D>().velocity.x;
        float vely = GameObject.Find("CharacterRobotBoy").GetComponent<Rigidbody2D>().velocity.y;

        if (velfinal != 0 && (velfinal<=-6 || velfinal >= 6))
        {
            velocidad = velfinal *0.01f;
            GetComponent<Renderer>().material.mainTextureOffset += new Vector2(Time.deltaTime * velocidad,vely*0.001f );
           
        }
            
       

        

    }
}
