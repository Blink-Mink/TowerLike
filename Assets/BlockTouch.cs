using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTouch : MonoBehaviour
{
    AlturaTorre alturaTotal;
    GameObject floor;
    public void Start()
    {
        alturaTotal = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AlturaTorre>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {      
        if (collision.gameObject.CompareTag("floor"))
        {
            if(alturaTotal.RetAltura() < 1)
            {
                alturaTotal.NuevoPiso();
                floor = collision.gameObject;
                Invoke("EditFloor", 1f);
            }           
        }
        if(collision.gameObject.CompareTag("block"))
        {
                alturaTotal.NuevoPiso();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("block"))
        {
            alturaTotal.RemoverPiso();
        }
    }

    void EditFloor()
    {        
        GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        var sz = floor.gameObject.transform.localScale;
        sz.x = transform.localScale.x/100f;
        sz.x *= 3.2f;
        floor.gameObject.transform.localScale = sz;
        var of = floor.gameObject.transform.position;
        of.x = transform.position.x;
        floor.gameObject.transform.position = of;
    }
}
