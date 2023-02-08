using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteboardButton : MonoBehaviour
{
    public enum button_types
    {
        Next,
        Back
    };

    public button_types button_type;

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
        if (button_type == button_types.Next)
        {
            Camera.main.GetComponent<MenuCamera>().Next();
        }
        else if (button_type == button_types.Back)
        {
            Camera.main.GetComponent<MenuCamera>().Back();
        }        
    }
}
