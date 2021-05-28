using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public GameObject spawnPoint;
    public Transform pendulo;
    bool DoCraneOut;
    bool DoCraneIn;
    bool doInput;
 
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("blockSpawn");
        pendulo = GameObject.FindGameObjectWithTag("pendulo").transform;
        DoCraneOut = false;
        DoCraneIn = false;
        doInput = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (pendulo.position.y <= 8.22f)
        {
            DoCraneIn = false;
            doInput = true;
        }

        if (doInput)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (gameObject.GetComponent<Rigidbody2D>() == null)
                {
                    SetRigi();
                    transform.parent = null;                    
                    DoCraneOut = true;
                    doInput = false;
                }
                else
                {
                    return;
                }
            }
        }            

        if (DoCraneOut)
        {
            CraneOut();
        }

        if (DoCraneIn)
        {
            CraneIn();
        }
    }

    public void SetRigi()
    {
        gameObject.AddComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().gravityScale = 2;
        GetComponent<Rigidbody2D>().drag = 1;
        GetComponent<Rigidbody2D>().angularDrag = 1;
    }

    public void CraneOut()
    {
        var pendPos = pendulo.position;
        pendPos.y += 3f * 0.00075f;
        pendulo.position = pendPos;
        if (pendulo.position.y > 13)
        {
            doInput = false;
            DoCraneOut = false;
            GNB();           
            DoCraneIn = true;
        }
    }

    public void CraneIn()
    {
        var pendPos = pendulo.position;
        pendPos.y -= 3f * 0.00075f;
        pendulo.position = pendPos;        
    }
    public void GNB()
    {        
        spawnPoint.GetComponent<hasBlock>().GenerateNewBlock();
    }

    
}

