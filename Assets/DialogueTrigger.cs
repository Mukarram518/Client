using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    //public GameObject dialogueBox;
    //public Text dialogueText;

    //public string dialogue;

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        dialogueText.text = dialogue;
    //        dialogueBox.SetActive(true);
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        dialogueBox.SetActive(false);
    //    }
    //}
    public GameObject UiObject;
    private void Start()
    {
        UiObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UiObject.SetActive(true);
            StartCoroutine(WaitForSec());
        }
        IEnumerator WaitForSec()
        {
            yield return new WaitForSeconds(3);
            UiObject.SetActive(false);
        }
    }
}
