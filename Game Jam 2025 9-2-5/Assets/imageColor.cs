using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class imageColor : MonoBehaviour
{
    [SerializeField]
    PrinterTask task;

    [SerializeField]
    int idx;

    UnityEngine.UI.Image img;

    bool updated = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!task.isComplete() && updated == false)
        {
            Debug.Log("Starting");
            int rand = (int)Math.Floor(UnityEngine.Random.value * 3f);
            char col_char = rand == 0 ? 'r' : (rand == 1 ? 'g' : 'b');


            img = this.GetComponent<UnityEngine.UI.Image>();
            img.color = rand == 0 ? Color.red : (rand == 1 ? Color.green : Color.blue);

            task.correct_button_order[idx] = col_char;
            updated = true;
        }
        if (task.isComplete())
        {
            updated = false;
        }
    }
}