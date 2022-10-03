using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SuctionTrach : MonoBehaviour
{
    public GameObject AbleCont;
    public GameObject AbleBlank1;
    public GameObject AbleBlank2;
    public GameObject AbleBlank3;
    public GameObject AbleL;
    public GameObject AbleR;

    public GameObject UnableMask;
    public GameObject UnableIntubation;
    public GameObject UnableBlank1;
    public GameObject UnableBlank2;
    public GameObject UnableL;
    public GameObject UnableR;

    public GameObject MaskAdded;
    public GameObject IntubationAdded;

    public GameObject CameraMask;
    public GameObject CameraIntubation;

    public GameObject camera;

    int count = 0;

    // Global Vars are
    // ST_Able;
    // ST_Unable;

    // Start is called before the first frame update
    void Start()
    {
        AbleBlank1.active = false;
        AbleBlank2.active = false;
        AbleBlank3.active = false;

        UnableBlank1.active = false;
        UnableBlank2.active = false;

        UnableL.active = false;
        UnableR.active = false;

        MaskAdded.active = false;
        IntubationAdded.active = false;

        CameraIntubation.active = false;

        Debug.Log("SuctionTrach started");

        camera = GameObject.Find("Main Camera - Mask");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.renderMode = UnityEngine.Video.VideoRenderMode.CameraFarPlane;
    }

    public void ableContinue(string click)
    {   

        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        videoPlayer.url = "Assets/Prefabs/TeenF_Success_Suction.mp4";
        videoPlayer.isLooping = false;
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();
        if (click == "Continue")
        {
            GlobalVarStorage.ST_Able = true;

            AbleL.active = false;
            AbleR.active = false;

            UnableL.active = true;
            UnableR.active = true;
        }
    }


    public void unable(string click)
    {
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        videoPlayer.url = "Assets/Prefabs/teenF_Fail_Suction.mp4";
        videoPlayer.isLooping = false;
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();
        if (click == "Mask Patient")
        {
            if(IntubationAdded.active == true)
            {
                IntubationAdded.active = false;
                MaskAdded.active = true;
            }
            else
            {
                MaskAdded.active = true;
            }
            UnableMask.active = false;
            count = count + 1;
            Debug.Log("Mask Clicked");
        }

        if (click == "Intubation")
        {
            if(MaskAdded.active == true)
            {
                MaskAdded.active = false;
                IntubationAdded.active = true;
            }
            else
            {
                IntubationAdded.active = true;
            }
            UnableIntubation.active = false;
            count = count + 1;
            Debug.Log("Intubation Clicked");
        }

        if(count == 2)
        {
            SceneManager.LoadScene("Patient Deteriorating");
        }
    }

}
