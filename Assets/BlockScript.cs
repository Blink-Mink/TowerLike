using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    
    
    [SerializeField] private Transform pendulo;    
    public bool doInput;
 
    // Start is called before the first frame update
    void Start()
    {
        
        pendulo = GameObject.FindGameObjectWithTag("pendulo").transform;               
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (doInput)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (gameObject.GetComponent<Rigidbody2D>() == null)
                {
                    SetRigi();
                    transform.parent = null;                    
                    pendulo.gameObject.GetComponent<ControlCuerda>().DoCraneOut = true;
                    doInput = false;
                }
                else
                {
                    return;
                }
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

   

    
}

