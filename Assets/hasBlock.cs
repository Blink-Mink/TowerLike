using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasBlock : MonoBehaviour
{
    
    public GameObject blockObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   


    public void GenerateNewBlock()
    {
        GameObject myBlock = Instantiate(blockObj, transform.position, transform.rotation);
        myBlock.transform.parent = gameObject.transform;
    }
}
