using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlock : MonoBehaviour
{
    [SerializeField] private GameObject blockObj;    
      
    public GameObject lastBlock;


    void Start()
    {              
        GenerateNewBlock();
    }     
    

    public void GenerateNewBlock()
    {
        GameObject myBlock = Instantiate(blockObj, transform.position, transform.rotation);
        myBlock.transform.parent = transform.transform;
        lastBlock = myBlock;
    }

        

}

   



