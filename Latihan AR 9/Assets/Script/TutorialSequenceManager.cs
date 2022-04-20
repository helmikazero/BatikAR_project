using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSequenceManager : MonoBehaviour
{
    [System.Serializable]
    public class SequenceUnit
    {
        public string sequenceDesc;
        public GameObject[] itemsToSow;
    }

    public SequenceUnit[] tutorialSequence;

    public int currentSequenceIndex;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }

        currentSequenceIndex++;

        for (int i = 0; i < tutorialSequence[currentSequenceIndex].itemsToSow.Length; i++)
        {
            tutorialSequence[currentSequenceIndex].itemsToSow[i].SetActive(true);
        }

    }

    public void PREV_PAGE()
    {
        for (int i = 0; i < tutorialSequence[currentSequenceIndex].itemsToSow.Length; i++)
        {
            tutorialSequence[currentSequenceIndex].itemsToSow[i].SetActive(false);
        }

        currentSequenceIndex--;

        for (int i = 0; i < tutorialSequence[currentSequenceIndex].itemsToSow.Length; i++)
        {
            tutorialSequence[currentSequenceIndex].itemsToSow[i].SetActive(true);
        }

    }

    public void END_TUTORIAL ()
    {
        SceneManager.LoadScene("MainMenu");
    }

  
}
