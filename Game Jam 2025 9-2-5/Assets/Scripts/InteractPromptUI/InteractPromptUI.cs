using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Runtime.InteropServices;

public class InteractPromptUI : MonoBehaviour
{
    bool PlayerInTrigger = false;
    public KeyCode InteractKey;
    public UnityEvent interactAction;
    public GameObject InteractPrompt_UI;
    public GameObject TargetUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InteractPrompt_UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(InteractKey) && PlayerInTrigger)
        {
            print("Interacted");
            InteractPrompt_UI.SetActive(false);
            interactAction.Invoke();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(!PlayerInTrigger)
        {
            InteractPrompt_UI.SetActive(true);
            gameObject.SetActive(true);
            PlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(PlayerInTrigger)
        {
            InteractPrompt_UI.SetActive(false);
            gameObject.SetActive(false);
            PlayerInTrigger = false;
        }
    }

    public void OpenPC()
    {
        TargetUI.SetActive(true);
    }

}
