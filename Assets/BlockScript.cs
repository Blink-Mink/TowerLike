using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public GameObject spawnPoint;
 
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("blockSpawn");
    }

    // Update is called once per frame
    void Update()
    {       
        
            if (Input.GetMouseButtonDown(0))
            {
                if (gameObject.GetComponent<Rigidbody2D>() == null)
                {
                    SetRigi();                    
                    transform.parent = null;
                    Invoke("GNB",1f);                    
                }
                else
                {
                    return;
                }
            }      
        
    }

    public void SetRigi()
    {
        gameObject.AddComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().gravityScale = 2;
        GetComponent<Rigidbody2D>().drag = 1;
        GetComponent<Rigidbody2D>().angularDrag = 1;
    }

    public void GNB()
    {
        spawnPoint.GetComponent<hasBlock>().GenerateNewBlock();
    }

   
}

