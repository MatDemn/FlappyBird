using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointTrigger : MonoBehaviour
{
    PipePairScript pipePairRef;
    // Start is called before the first frame update
    void Start()
    {
        pipePairRef = GetComponentInParent<PipePairScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GManager.Instance.AddPoints(pipePairRef.pointsAmount);
    }
}
