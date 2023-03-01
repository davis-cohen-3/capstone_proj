using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NextStepsRealMenu : MonoBehaviour
{

    public Animator animator;
    public List<GameObject> gameButtonsForStart = new List<GameObject>();
    public List<GameObject> gameButtonsForTrach = new List<GameObject>();
    public List<GameObject> gameButtonsForMonitor = new List<GameObject>();
    public List<GameObject> gameButtonsForDoor = new List<GameObject>();
    List<List<GameObject>> gameButtons = new List<List<GameObject>>();
    int state = 1;
    int[,] substates = { {3, 3, 1, -1}, {2, 2, -1, 1}, {1 , -1, -1, -1}, {-1, 0, 0, 0} };

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gameButtons.Add(gameButtonsForStart);
        gameButtons.Add(gameButtonsForTrach);
        gameButtons.Add(gameButtonsForMonitor);
        gameButtons.Add(gameButtonsForDoor);
        print(gameButtons.Count);
    }

    void swapActivity(List<GameObject> activateList, List<GameObject> deactivateList)
    {
        for(int i = 0;  i < deactivateList.Count; i++){
            deactivateList[i].SetActive(false);
        }
        for(int i = 0;  i < activateList.Count; i++){
            activateList[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("left") && substates[0,state] != -1){
            int p_state = state;
            state = substates[0,state];
            animator.SetInteger("state", state);
            swapActivity(gameButtons[state], gameButtons[p_state]);
        }
        else if(Input.GetKeyUp("right") && substates[1,state] != -1){
            int p_state = state;
            state = substates[1,state];
            animator.SetInteger("state", state);
            swapActivity(gameButtons[state], gameButtons[p_state]);
        }
        else if(Input.GetKeyUp("up") && substates[2,state] != -1){
            int p_state = state;
            state = substates[2,state];
            animator.SetInteger("state", state);
            swapActivity(gameButtons[state], gameButtons[p_state]);
        }
        else if(Input.GetKeyUp("down") && substates[3,state] != -1){
            int p_state = state;
            state = substates[3,state];
            animator.SetInteger("state", state);
            swapActivity(gameButtons[state], gameButtons[p_state]);
        }
    }
}
