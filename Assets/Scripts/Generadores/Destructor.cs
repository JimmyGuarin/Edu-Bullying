using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("hay Colosion");
        if (collision.gameObject.tag.Equals(gameObject.tag))
        {
            Destroy(collision.gameObject);
        }
        
    }
}
