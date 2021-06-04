using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlCamara : MonoBehaviour
{

    [SerializeField] private float speed = 1.2f;
    [SerializeField] private float maximoDeBloquesEnPantalla = 4f;
    [SerializeField] private float minimoDeAlturaParaSubir = 5f;
    float cubosObjetivo;
    float alturaObjetivo;
    List <GameObject> blocks;   
    List<GameObject> blocksOnScreen;
    Camera cam;
    Plane[] planes;
    bool yaBajate;
    GameObject lastCube;
    // Start is called before the first frame update
    void Start()
    {
        cubosObjetivo = maximoDeBloquesEnPantalla+1;
        alturaObjetivo = minimoDeAlturaParaSubir;
        cam = GetComponent<Camera>();        
        blocksOnScreen = new List<GameObject>();
        blocks = new List<GameObject>();
        yaBajate = false;
    }

    // Update is called once per frame
    void Update()
    {

        // lastCube = GetComponent<AlturaTorre>().constructedBlocks[GetComponent<AlturaTorre>().constructedBlocks.Count - 1];
        blocks = GetComponent<AlturaTorre>().constructedBlocks;
        foreach (GameObject block in blocks)
        {           
            if (block.GetComponentInParent<Renderer>().isVisible)
            {                
                if (!blocksOnScreen.Contains(block))
                {
                    blocksOnScreen.Add(block);
                }                                   
            }
            else
            {
                if (blocksOnScreen.Contains(block)) 
                {
                    blocksOnScreen.Remove(block);
                }
                   
            }
        }        
        
        
        if(blocksOnScreen.Count >= cubosObjetivo && GetComponent<AlturaTorre>().RetAltura() >= alturaObjetivo)
        {
            Subir();
            yaBajate = true;
        }
              

        if(blocks.Count >= alturaObjetivo)
        {
            if (!blocksOnScreen.Contains(blocks[blocks.Count - 1]) && yaBajate == true)
            {                
                    Bajar();
                
            }          
           
        }          
       
    }

    public void PisoRemovido(GameObject obj)
    {
        blocksOnScreen.Remove(obj);
    }
    private void LateUpdate()
    {
        var fixY = gameObject.transform.position;
        if(fixY.y < 0)
        {
            fixY.y = 0;
        }
        gameObject.transform.position = fixY;
    }


    void Subir()
    {
        var tPos = transform.position;
        tPos.y += speed * Time.deltaTime;
        transform.position = tPos;
    }

    

    void Bajar()
    {
        var tPos = transform.position;        
        tPos.y = blocks[blocks.Count - 1].transform.position.y;                
        transform.position = tPos;
    }
   
}
