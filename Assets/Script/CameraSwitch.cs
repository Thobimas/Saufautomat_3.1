using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public GameObject CameraPlayerOne;
    public GameObject CameraPlayerTwo;
    public GameObject CameraPlayerThree;

    public GameObject PlayerOne;
    public GameObject PlayerTwo;
    public GameObject PlayerThree;

    
    private NPCMove npc1Turn;
    private NPCMove npc2Turn;
    private PlayerMove npc3Turn;

    AudioListener CameraPlayerOneAudioLis;
    AudioListener CameraPlayerTwoAudioLis;
    AudioListener CameraPlayerThreeAudioLis;

    // Use this for initialization
    void Start()
    {

        //Get Camera Listeners
        CameraPlayerOneAudioLis = CameraPlayerOne.GetComponent<AudioListener>();
        CameraPlayerTwoAudioLis = CameraPlayerTwo.GetComponent<AudioListener>();
        CameraPlayerThreeAudioLis = CameraPlayerThree.GetComponent<AudioListener>();

        //Camera Position Set
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }

    // Update is called once per frame
    void Update()
    {
        
        npc1Turn = PlayerOne.GetComponent<NPCMove>();
        npc2Turn = PlayerTwo.GetComponent<NPCMove>();
        npc3Turn = PlayerThree.GetComponent<PlayerMove>();
        //Change Camera Keyboard
        switchCamera();
    }

    //Change Camera Keyboard
    void switchCamera()
    {
        if(npc1Turn.turn)
        {
            cameraChangeCounter(1);
        }

        if(npc2Turn.turn)
        {
            cameraChangeCounter(2);
        }

        if(npc3Turn.turn)
        {
            cameraChangeCounter(3);
        }
    }

    //Camera Counter
    void cameraChangeCounter(int position)
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter = 0;
        cameraPositionCounter+= position;
        cameraPositionChange(cameraPositionCounter);
        cameraPositionCounter = 0;
    }

    //Camera change Logic
    void cameraPositionChange(int camPosition)
    {
        switch (camPosition)
        {
            case 0:
                    Debug.Log("Weil 0 Case gucken wir NPC 1 zu");
                    CameraPlayerOne.SetActive(true);
                    CameraPlayerOneAudioLis.enabled = true;

                    CameraPlayerTwoAudioLis.enabled = false;
                    CameraPlayerTwo.SetActive(false);

                    CameraPlayerThreeAudioLis.enabled = false;
                    CameraPlayerThree.SetActive(false);
                    break;
            case 1:
                    CameraPlayerOne.SetActive(true);
                    CameraPlayerOneAudioLis.enabled = true;

                    CameraPlayerTwoAudioLis.enabled = false;
                    CameraPlayerTwo.SetActive(false);

                    CameraPlayerThreeAudioLis.enabled = false;
                    CameraPlayerThree.SetActive(false);
                    break;
            case 2:
                    CameraPlayerTwo.SetActive(true);
                    CameraPlayerTwoAudioLis.enabled = true;

                    CameraPlayerOneAudioLis.enabled = false;
                    CameraPlayerOne.SetActive(false);

                    CameraPlayerThreeAudioLis.enabled = false;
                    CameraPlayerThree.SetActive(false);  
                    break;  
            case 3:
                    CameraPlayerThreeAudioLis.enabled = true;
                    CameraPlayerThree.SetActive(true);

                    CameraPlayerTwo.SetActive(false);
                    CameraPlayerTwoAudioLis.enabled = false;

                    CameraPlayerOneAudioLis.enabled = false;
                    CameraPlayerOne.SetActive(false);
                    break;
            default:
                    Debug.Log("Der CamCounter funktioniert nicht richtig!" +  camPosition);
                    CameraPlayerThreeAudioLis.enabled = false;
                    CameraPlayerThree.SetActive(false);

                    CameraPlayerTwo.SetActive(false);
                    CameraPlayerTwoAudioLis.enabled = false;

                    CameraPlayerOneAudioLis.enabled = false;
                    CameraPlayerOne.SetActive(false);
                    break;
        }
        //Set camera position database
        PlayerPrefs.SetInt("CameraPosition", camPosition);

        camPosition = 0;

    }
}