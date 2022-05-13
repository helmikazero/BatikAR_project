using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class TutorialSequenceManager : MonoBehaviour
{
    [System.Serializable]
    public class SequenceUnit
    {
        public string sequenceDesc;
        public GameObject[] itemsToSow;
        public AudioSource voiceRecorder;
        public bool isOn = false;
    }

    public SequenceUnit[] tutorialSequence;

    public int currentSequenceIndex;

    public Transform TutorialPopUp;
    public Sprite ImageAudioOn;
    public Sprite ImageAudioOff;

    // Start is called before the first frame update
    void Start()
    {
        tutorialSequence[0].voiceRecorder.Play(); //Mengatur untuk mulai suara ke sequence 0
        for (int i = 0; i < tutorialSequence.Length; i++) // Mengatur semua sequence untuk awalnya Unmute
        {
            tutorialSequence[i].isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Mengatur tombol Next
    public void NEXT_PAGE()
    {
        

        for (int i = 0; i < tutorialSequence[currentSequenceIndex].itemsToSow.Length; i++)
        {
            tutorialSequence[currentSequenceIndex].itemsToSow[i].SetActive(false);
            
        }

        tutorialSequence[currentSequenceIndex].voiceRecorder.Stop();

        currentSequenceIndex++;

        for (int i = 0; i < tutorialSequence[currentSequenceIndex].itemsToSow.Length; i++)
        {
            tutorialSequence[currentSequenceIndex].itemsToSow[i].SetActive(true);
            
        }

        tutorialSequence[currentSequenceIndex].voiceRecorder.Play();

        if (tutorialSequence[currentSequenceIndex].isOn) // Mendeteksi Apakah sequence  setelahnya mute / unmute
        {
            tutorialSequence[currentSequenceIndex].voiceRecorder.Stop();
        }
        else
        {
            tutorialSequence[currentSequenceIndex].voiceRecorder.Play();
        }

        
    }


    // Mengatur Tombol Previous
    public void PREV_PAGE()
    {
        

        for (int i = 0; i < tutorialSequence[currentSequenceIndex].itemsToSow.Length; i++)
        {
            tutorialSequence[currentSequenceIndex].itemsToSow[i].SetActive(false);      
        }

        tutorialSequence[currentSequenceIndex].voiceRecorder.Stop();

        currentSequenceIndex--;

        for (int i = 0; i < tutorialSequence[currentSequenceIndex].itemsToSow.Length; i++)
        {
            tutorialSequence[currentSequenceIndex].itemsToSow[i].SetActive(true);
            
        }

        tutorialSequence[currentSequenceIndex].voiceRecorder.Play();

        if (tutorialSequence[currentSequenceIndex].isOn) // Mendeteksi Apakah sequence  sebelumnya mute / unmute
        {
            tutorialSequence[currentSequenceIndex].voiceRecorder.Stop();
        }
        else
        {
            tutorialSequence[currentSequenceIndex].voiceRecorder.Play();
        }


        

    }

    // Kembali ke Menu Utama
    public void END_TUTORIAL ()
    {
        SceneManager.LoadScene("MainMenu");
    }


    // Settingan Tombol Sound untuk mute / unmute
    public void MuteToggle ()
    {

        if (tutorialSequence[currentSequenceIndex].isOn)
        {
            tutorialSequence[currentSequenceIndex].isOn = false;
            tutorialSequence[currentSequenceIndex].voiceRecorder.Play();         
            All_AudioController();
            All_ToggleController();
        }
        else
        {
            tutorialSequence[currentSequenceIndex].isOn = true;
            tutorialSequence[currentSequenceIndex].voiceRecorder.Stop();            
            All_AudioController();
            All_ToggleController();
        }
    }

  
    // Mengontrol semua sequence untuk mute / unmute
    public void All_AudioController ()
    {
        for (int i = 0; i < tutorialSequence.Length; i++)
        {
            if (tutorialSequence[currentSequenceIndex].isOn)
            {
                tutorialSequence[i].isOn = true;
            }
            else
            {
                tutorialSequence[i].isOn = false;
            }
        }
    }


    // Mengontrol Semua UI Apakah mute / unmute
    public void All_ToggleController ()
    {
        for (int i = 0; i < TutorialPopUp.childCount; i++)
        {
            if (tutorialSequence[currentSequenceIndex].isOn)
            {
                TutorialPopUp.GetChild(i).GetChild(3).GetComponent<Image>().sprite = ImageAudioOff;
            }
            else
            {
                TutorialPopUp.GetChild(i).GetChild(3).GetComponent<Image>().sprite = ImageAudioOn;
            }
        }


           
    }
}
