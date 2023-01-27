using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingScript : MonoBehaviour
{
    // this should be the breathing component
    SkinnedMeshRenderer breathMesh;
    // breath step size for controlling breathing animation.
    public float bc_step_size = 0.05f;
    // breath position.
    float breathValue = 0f;
    // check which way to increase the count or lower it.
    bool breathIn = true;

    // Start is called before the first frame update
    void Start()
    {
        breathMesh = GetComponent<SkinnedMeshRenderer> ();
        breathValue = breathMesh.GetBlendShapeWeight (0);
    }

    // Update is called once per frame
    void Update()
    {
        // increments or dicrements based on if the compoent is breathing in or not.
        if(breathIn){
            breathMesh.SetBlendShapeWeight (0, breathValue);
            breathValue += bc_step_size;
            breathIn = breathValue < 100;
        }
        else{
            breathMesh.SetBlendShapeWeight (0, breathValue);
            breathValue -= bc_step_size;
            breathIn = breathValue <= 0;
        }
    }
}
