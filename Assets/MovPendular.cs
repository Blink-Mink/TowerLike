using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPendular : MonoBehaviour
{
    Rigidbody2D rgbd;    
    public float leftLimit = 0.3f;
    public float rightLimit = 0.3f;
    public float initSpeed;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        rgbd.angularVelocity = initSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
    }

    public void Mover()
    {
        if(transform.rotation.z < rightLimit && rgbd.angularVelocity > 0 && rgbd.angularVelocity < speed)
        {
            rgbd.angularVelocity = speed;
        }
        else if(transform.rotation.z > leftLimit && rgbd.angularVelocity < 0 && rgbd.angularVelocity > -speed)
        {
            rgbd.angularVelocity = -speed;
        }
    }
}
