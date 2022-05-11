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


    // Start is called before the first frame update
    void Start()
    {
        tutorialSequence[0].voiceRecorder.Play();
        for (int i = 0; i < tutorialSequence.Length; i++)
        {
            tutorialSequence[i].isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void NEXT_PAGE()
    {
        for (int i = 0; i < tutorialSequence[currentSequenceIndex].itemsToSow.Length; i++)
        {
            tutorialSequence[currentSequenceIndex].itemsToSow[i].SetActive(false);
            tutorialSequence[currentSequenceIndex].voiceRecorder.Stop();
        }

        currentSequenceIndex++;

        for (int i = 0; i < tutorialSequence[currentSequenceIndex].itemsToSow.Length; i++)
        {
            tutorialSequence[currentSequenceIndex].itemsToSow[i].SetActive(true);
            tutorialSequence[currentSequenceIndex].voiceRecorder.Play();
        }

        if (tutorialSequence[currentSequenceIndex].isOn)
        {
            tutorialSequence[currentSequenceIndex].voiceRecorder.Stop();
        }
        else
        {
            tutorialSequence[currentSequenceIndex].voiceRecorder.Play();
        }
    }

    public void PREV_PAGE()
    {
        for (int i = 0; i < tutorialSequence[currentSequenceIndex].itemsToSow.Length; i++)
        {
            tutorialSequence[currentSequenceIndex].itemsToSow[i].SetActive(false);
            tutorialSequence[currentSequenceIndex].voiceRecorder.Stop();
        }

        currentSequenceIndex--;

        for (int i = 0; i < tutorialSequence[currentSequenceIndex].itemsToSow.Length; i++)
        {
            tutorialSequence[currentSequenceIndex].itemsToSow[i].SetActive(true);
            tutorialSequence[currentSequenceIndex].voiceRecorder.Play();
        }

        if (tutorialSequence[currentSequenceIndex].isOn)
        {
            tutorialSequence[currentSequenceIndex].voiceRecorder.Stop();
        }
        else
        {
            tutorialSequence[currentSequenceIndex].voiceRecorder.Play();
        }
    }

    public void END_TUTORIAL ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void MuteToggle (Toggle mute)
    {
        if (mute.isOn)
        {
            tutorialSequence[currentSequenceIndex].voiceRecorder.Stop();
            MuteAudio();
        }
        else
        {
            tutorialSequence[currentSequenceIndex].voiceRecorder.Play();
            MuteAudio();
        }
    }

    public void MuteAudio ()
    {
        if (tutorialSequence[currentSequenceIndex].isOn)
        {
            tutorialSequence[currentSequenceIndex].isOn = false;
        }
        else
        {
            tutorialSequence[currentSequenceIndex].isOn = true;
        }
    }
    

}
