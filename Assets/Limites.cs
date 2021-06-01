using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limites : MonoBehaviour
{
    private enum Limit
    {
        Superior,
        Inferior
    }
    [SerializeField] private Limit Limite;
    // Start is called before the first frame update


    public void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.CompareTag("pendulo"))
        {
           
            if (Limite == Limit.Superior)
            {
                collision.GetComponentInChildren<ControlCuerda>().StopCrane(1);
            }
            else if (Limite == Limit.Inferior)
            {
                collision.GetComponentInChildren<ControlCuerda>().StopCrane(0);
            }
        }      
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pendulo"))
        {
            if (Limite == Limit.Superior)
            {
                collision.GetComponentInChildren<ControlCuerda>().MoveCrane(1);
            }
            else if (Limite == Limit.Inferior)
            {
                collision.GetComponentInChildren<ControlCuerda>().MoveCrane(0);
            }
        }
    }
}
