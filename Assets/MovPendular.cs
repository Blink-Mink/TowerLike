using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPendular : MonoBehaviour
{
    
    [Header("Valores Péndulo")]
    [SerializeField] private float MaxAngleDeflection = 30.0f;
    [SerializeField] private float SpeedOfPendulum = 1.0f;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        MovimientoPendular();
       
    }

    public void MovimientoPendular()
    {
        float angle = MaxAngleDeflection * Mathf.Sin(Time.time * SpeedOfPendulum);
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }

   

}
