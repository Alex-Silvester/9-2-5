using System;
using System.Linq;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PrinterTask", menuName = "Scriptable Objects/PrinterTask")]
public class PrinterTask : Task
{
    public List<char> correct_button_order = new List<char> { 'r', 'r', 'r' };
    public List<char> button_order;

    public override void initTask()
    {
        base.initTask();


        correct_button_order = new List<char> { 'r', 'r', 'r' };
        button_order.Clear();
    }

    public override void run()
    {
        if (!complete)
        {
            if (button_order.Count > 3)
            {
                button_order.RemoveRange(0, 3);
            }

            if (button_order.Count < 3)
            {
                return;
            }

            if (button_order[0] == correct_button_order[0] &&
                button_order[1] == correct_button_order[1] &&
                button_order[2] == correct_button_order[2])
            {
                complete = true;
            }
        }

    }

    public override void reset()
    {
        base.reset();
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
}
