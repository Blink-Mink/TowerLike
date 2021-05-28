using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPendularF : MonoBehaviour
{
    
    public Transform pivotPoint;
    public float MaxAngleDeflection = 30.0f;
    public float SpeedOfPendulum = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoPendular();       

    }

    public void MovimientoPendular()
    {
        float angle = MaxAngleDeflection * Mathf.Sin(Time.time * SpeedOfPendulum);
        pivotPoint.localRotation = Quaternion.Euler(0, 0, angle);
    }
    
}
