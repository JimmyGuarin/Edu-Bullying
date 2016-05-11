using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;

    private Vector3 m_CurrentVelocity;

    void Update()
    {
        if (player.position.y < 4)
            offset.Set(offset.x, 7, offset.z);
        else{

            if (player.position.y <= 8)
                offset.Set(offset.x, 4, offset.z);
            else
                offset.Set(offset.x,2, offset.z);
        }
         

        Vector3 newPos = Vector3.SmoothDamp(transform.position,player.position+offset, ref m_CurrentVelocity,1f);

        transform.position = newPos;

      
    }

}