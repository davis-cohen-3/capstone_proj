using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStepsRealMenu : MonoBehaviour
{

    public Animator animator;
    int state = 1;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("left"))
        {
            if(state == 1){
                state = 4;
                animator.SetInteger("state", state);
            }
            else if(state == 2){
                state = 4;
                animator.SetInteger("state", state);
            }
            else if(state == 3){
                state = 2;
                animator.SetInteger("state", state);
            }
        }
        else if(Input.GetKeyUp("right")){
            if(state == 1){
                state = 3;
                animator.SetInteger("state", state);
            }
            else if(state == 2){
                state = 3;
                animator.SetInteger("state", state);
            }
            else if(state == 4){
                state = 2;
                animator.SetInteger("state", state);
            }
        }
        else if(Input.GetKeyUp("up")){
            if(state == 1){
                state = 2;
                animator.SetInteger("state", state);
            }
        }
        else if(Input.GetKeyUp("down")){
            if(state == 2){
                state = 1;
                animator.SetInteger("state", state);
            }
            else if(state == 3){
                state = 1;
                animator.SetInteger("state", state);
            }
            else if(state == 4){
                state = 1;
                animator.SetInteger("state", state);
            }
        }
    }
}
