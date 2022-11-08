using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteboardButton : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnMouseOver()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        print("Hello World");
    }
}
