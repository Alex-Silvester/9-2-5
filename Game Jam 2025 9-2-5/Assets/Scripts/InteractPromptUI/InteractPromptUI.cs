using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractPromptUI : MonoBehaviour
{
    bool PlayerInTrigger = false;
    public GameObject InteractPrompt_UI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InteractPrompt_UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && PlayerInTrigger)
        {
            print("f key was pressed");
            InteractPrompt_UI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        InteractPrompt_UI.SetActive(true);
        PlayerInTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        InteractPrompt_UI.SetActive(false);
        PlayerInTrigger = false;
    }

}
