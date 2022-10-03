using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

using UnityEngine;
using UnityEngine.SceneManagement;
public class rTrachMan : MonoBehaviour
{
    public GameObject tVars;
    public GameObject lPanel;
    public GameObject rPanel;
    public GameObject but1;
    public GameObject but2;
    public GameObject but3;
    public int phase = 0;
    public GameObject PB4E;

    public GameObject camera;


    // Start is called before the first frame update
    void Start()
    {
        if (!tVars.GetComponent<tVars>().isEnt)
        {
            Debug.Log("not an ent");
            but3.SetActive(false);
        }
        else
        {
            Debug.Log("you're an ent");
        }
        // Will attach a VideoPlayer to the main camera.
        camera = GameObject.Find("Main Camera");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void button1()
    {
        if(phase == 0)
        {
            //here goes replace trach vid
            var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
            videoPlayer.playOnAwake = false;
            videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
            videoPlayer.url = "Assets/Prefabs/TeenF_Fail_ambuBag.mp4";
            videoPlayer.isLooping = false;
            videoPlayer.loopPointReached += EndReached;
            videoPlayer.Play();

            //here goes ambu bag fail vid
            videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
            videoPlayer.playOnAwake = false;
            videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
            videoPlayer.url = "Assets/Prefabs/TeenF_Success_trachChange.mp4";
            videoPlayer.isLooping = false;
            videoPlayer.loopPointReached += EndReached;
            videoPlayer.Play();

            phase = 21;
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Unable to ventilate with low pressure.";
            but3.SetActive(false);

            but1.GetComponentInChildren<Text>().text = "Stop";
            but2.GetComponentInChildren<Text>().text = "Increase Pressure";
            PB4E.GetComponent<ReplaceTrachByPICUB4ENTArrives>().otherB = true;

        }
 
        else if(phase == 1)
        {
            but1.GetComponentInChildren<Text>().text = "Try again";
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Patient Expired";
            but2.SetActive(false);
            phase = 23;
        }

        else if(phase == 10)
        {
            phase = 11;
            Debug.Log("inbutton2 phase 1");
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Patient Intermittently Obstructs";
            but2.SetActive(true);
            but3.SetActive(true);

            but1.GetComponentInChildren<Text>().text = "Adjust neck position";
            but2.GetComponentInChildren<Text>().text = "Perform flexible tracheoscopy";
            but3.GetComponentInChildren<Text>().text = "Replace tube with shorter tube";
        }

        else if (phase == 21)
        {
            phase = 0;
            PB4E.GetComponent<ReplaceTrachByPICUB4ENTArrives>().otherB = false;
            PB4E.GetComponent<ReplaceTrachByPICUB4ENTArrives>().TaskOnPICUTeamClick();
            /*lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "By which method do you want the trach to be replaced?";
            but3.SetActive(true);
            if (!tVars.GetComponent<tVars>().isEnt)
            {
                Debug.Log("not an ent");
                but3.SetActive(false);
            }

            but1.GetComponentInChildren<Text>().text = "Replace trach by PICU team";
            but2.GetComponentInChildren<Text>().text = "Replace trach by PICU team before ENT team arrives";
            but3.GetComponentInChildren<Text>().text = "Replace trach by ENT team";*/
        }

        else if (phase == 22)
        {
            but1.GetComponentInChildren<Text>().text = "Try again";
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Patient Expired";
            phase = 23;
        }
        else if (phase == 23)
        {
            phase = 0;
            but1.GetComponentInChildren<Text>().text = "PICU team";
            but2.GetComponentInChildren<Text>().text = "PICU team before ENT team arrives";
            but3.GetComponentInChildren<Text>().text = "ENT team";
            PB4E.GetComponent<ReplaceTrachByPICUB4ENTArrives>().otherB = false;
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "By which method do you want the trach to be replaced?";
            but1.SetActive(true);
            but2.SetActive(true);
            but3.SetActive(true);
        }
        else if (phase == 11)
        {   
            
            but1.SetActive(false);
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Failed to relieve intermitten obstruction";
        }
        else if (phase == 3)
        {
            if(but2.active && but3.active)
            {
                but1.SetActive(false);
            }
            else
            {
                success();
            }
        }
        else if (phase == 31)
        {
            Debug.Log("in success");
            phase = 3;
            but1.SetActive(true);
            but2.SetActive(true);
            but3.SetActive(true);
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "How do you stabilize the patient in the long term? Please select the options in the correct order.";
            but1.GetComponentInChildren<Text>().text = "Get new trach";
            but2.GetComponentInChildren<Text>().text = "Insert obturator into new trach";
            but3.GetComponentInChildren<Text>().text = "Coat tip with KY jelly";
        }
        else if (phase == 4)
        {
            SceneManager.LoadScene("Inspect Trach");
        }
    }
    public void button2()
    {
        Debug.Log("inbutton2");
        if(phase == 1)
        {
            var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
            videoPlayer.playOnAwake = false;
            videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
            videoPlayer.url = "Assets/Prefabs/TeenF_Success_trachChange.mp4";
            videoPlayer.isLooping = false;
            videoPlayer.loopPointReached += EndReached;
            videoPlayer.Play();
            Debug.Log("phase 1");
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Success, trach replaced and patient revived. Continue to alternate scenario where patient intermittently obstructs.";
            but1.SetActive(true);
            but2.SetActive(false);
            but1.GetComponentInChildren<Text>().text = "Continue";
            phase = 10;

        }
        else if(phase == 21)
        {
            // VideoPlayer automatically targets the camera backplane when it is added
             // to a camera object, no need to change videoPlayer.targetCamera.
            var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
            videoPlayer.playOnAwake = false;
            videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
            videoPlayer.url = "Assets/Prefabs/TeenF_crepitus.mp4";
            videoPlayer.isLooping = false;
            videoPlayer.loopPointReached += EndReached;
            videoPlayer.Play();

     
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Neck becomes crepitus, vitals deteriorate";
            but2.SetActive(false);
            but1.GetComponentInChildren<Text>().text = "CPR";
            phase = 22;
        }
        else if (phase == 11)
        {
            but2.SetActive(false);
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Tracheostomy tube plowed into anterior wall of the patient�s trachea";
        }
        else if (phase == 3)
        {
            if (!but1.active && but3.active)
            {
                but2.SetActive(false);
            }
            else
            {
                success();
            }
        }
    }

    public void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.renderMode = UnityEngine.Video.VideoRenderMode.CameraFarPlane;
    }
    public void button3()
    {
        GlobalVarStorage.RT_ENT = true;
        if (phase == 0)
        {
            Debug.Log("in here");
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "What do you want to do with the trach ties?";
            but3.SetActive(false);
            but1.GetComponentInChildren<Text>().text = "Nothing";
            but2.GetComponentInChildren<Text>().text = "Pull on trach ties";
            phase = 1;
            PB4E.GetComponent<ReplaceTrachByPICUB4ENTArrives>().otherB = true;
        }
        else if (phase == 11)
        {
            
            success3();
        }
        else if (phase == 3)
        {
            if (!but1.active && !but2.active)
            {
                but3.SetActive(false);
                success2();
            }
            else
            {
                success();
            }
        }
    }

    public void success()
    {
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        videoPlayer.url = "Assets/Prefabs/TeenF_Success_trachChange.mp4";
        videoPlayer.isLooping = false;
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();
        phase = 31;
        lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Success! Now to stabilize patient in the long term.";
        but1.GetComponentInChildren<Text>().text = "Continue";
        but1.SetActive(true);
        but2.SetActive(false);
        but3.SetActive(false);


        
    }

    public void success2()
    {
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        videoPlayer.url = "Assets/Prefabs/TeenF_Success_trachChange.mp4";
        videoPlayer.isLooping = false;
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();
        Debug.Log("in success2");
        phase = 4;
        if (!GlobalVarStorage.endStateSuccess)
        {
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Success! Patient stabilized. Continue to trach in place scenario.";
            but1.GetComponentInChildren<Text>().text = "Continue";
            but1.SetActive(true);
            GlobalVarStorage.endStateSuccess = true;
        }
        else
        {
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Success! Patient stabilized. Training session complete";
        }
    }

    public void success3()
    {
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        videoPlayer.url = "Assets/Prefabs/TeenF_Success_curvedTrach.mp4";
        videoPlayer.isLooping = false;
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();

        phase = 31;
        lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Success! Now to stabilize patient in the long term.";
        but1.GetComponentInChildren<Text>().text = "Continue";
        but1.SetActive(true);
        but2.SetActive(false);
        but3.SetActive(false);
    }
    public void expire()
    {
        Debug.Log("in expire");
        but1.GetComponentInChildren<Text>().text = "Try again";
        but2.SetActive(false);
        but3.SetActive(false);
        lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Patient Expired";
        phase = 23;
    }
}
