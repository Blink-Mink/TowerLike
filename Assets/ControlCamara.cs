using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlCamara : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float cubosObjetivo;
    [SerializeField] private float alturaObjetivo;
    GameObject[] blocks;
    List<GameObject> blocksOnScreen;
    Camera cam;
    Plane[] planes;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();        
        blocksOnScreen = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
        blocks = GameObject.FindGameObjectsWithTag("block");
        foreach (GameObject block in blocks)
        {           
            if (block.GetComponent<Renderer>().isVisible)
            {
                if (!blocksOnScreen.Contains(block))
                    blocksOnScreen.Add(block);
            }
            else
            {
                if (blocksOnScreen.Contains(block))
                    blocksOnScreen.Remove(block);
            }
        }
        if(blocksOnScreen.Count >= cubosObjetivo && GetComponent<AlturaTorre>().RetAltura() > alturaObjetivo)
        {
            Subir();
        }
        else
        {
            NoSubir();
        }        
       
    }


    void Subir()
    {
        var tPos = transform.position;
        tPos.y += speed * Time.deltaTime;
        transform.position = tPos;
    }

    void NoSubir()
    {

    }


   
}
