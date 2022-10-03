using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stateVars : MonoBehaviour
{
    public bool isENT = false;
    public bool isNurse = false;
    public bool isPT = false;
    public int patAge;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }


}
