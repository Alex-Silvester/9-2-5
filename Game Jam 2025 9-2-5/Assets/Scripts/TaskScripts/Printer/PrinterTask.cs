using System;
using System.Linq;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PrinterTask", menuName = "Scriptable Objects/PrinterTask")]
public class PrinterTask : Task
{
    List<char> correct_button_order;
    List<char> button_order;

    char[] characters = { 'r', 'g', 'b' };

    public override void initTask()
    {
        base.initTask();

        button_order.Clear();

        correct_button_order.Clear();

        for(int i = 0; i < 3; i++)
        {
            int char_idx = (int)Math.Floor(UnityEngine.Random.value * 3);
            correct_button_order.Add(characters[char_idx]);

        }

        setIndicatorColour(optional_interactable.transform.Find("FirstButton").GetComponent<Image>(), 0);
        setIndicatorColour(optional_interactable.transform.Find("SecondButton").GetComponent<Image>(), 1);
        setIndicatorColour(optional_interactable.transform.Find("ThirdButton").GetComponent<Image>(), 2);
    }

    public override void run()
    {
        if(button_order.Count > 3)
        {
            button_order.Clear();
        }

        if(button_order.Count < 3)
        {
            return;
        }

        if (button_order[0] == correct_button_order[0] &&
            button_order[1] == correct_button_order[1] &&
            button_order[2] == correct_button_order[2])
        {
            Debug.Log("Task Complete");
            complete = true;
        }

    }

    public void buttonRed()
    {
        button_order.Add('r');
    }

    public void buttonGreen()
    {
        button_order.Add('g');
    }

    public void buttonBlue() 
    {
        button_order.Add('b');
    }

    private void setIndicatorColour(Image component, int idx)
    {
        switch(correct_button_order[idx])
        {
            case 'r':
                component.color = Color.red;
                break;
            case 'g':
                component.color = Color.green;
                break;
            case 'b':
                component.color = Color.blue;
                break;
            default: break;
        }
    }
}
