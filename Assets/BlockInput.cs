using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInput : MonoBehaviour
{
    private Transform cuerda;
    private bool doInput;
    
    void Start()
    {
        cuerda = GameObject.FindGameObjectWithTag("cuerda").transform;
    }

    public void EnableBlockInput()
    {
        doInput = true;
    }

    public void DisableBlockInput()
    {
        doInput = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (doInput)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GetComponent<GenerateBlock>().lastBlock != null)
                {
                    if (GetComponent<GenerateBlock>().lastBlock.gameObject.GetComponent<Rigidbody2D>() == null)
                    {
                        SetRigi();
                        GetComponent<GenerateBlock>().lastBlock.transform.parent = null;
                        cuerda.gameObject.GetComponent<ControlCuerda>().DoCraneOut = true;
                        doInput = false;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }

    public void SetRigi()
    {
        GetComponent<GenerateBlock>().lastBlock.AddComponent<Rigidbody2D>();
        GetComponent<GenerateBlock>().lastBlock.GetComponent<Rigidbody2D>().gravityScale = 2;
        GetComponent<GenerateBlock>().lastBlock.GetComponent<Rigidbody2D>().drag = 1;
        GetComponent<GenerateBlock>().lastBlock.GetComponent<Rigidbody2D>().angularDrag = 1;
    }
}

