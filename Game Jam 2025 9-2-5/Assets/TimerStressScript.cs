using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerStressScript : MonoBehaviour
{

    public Slider stress_meter;
    public float max_stress;
    public float stress_gain;
    public bool stop_stress = false;
    float stress;

    [SerializeField] TextMeshProUGUI timer_text;
    public float time_scaling;
    int hours;
    float minutes;




    void Start()
    {
        stress = 0;
        stress_meter.maxValue = max_stress;
        stress_meter.value = stress;
        hours = 9;
        minutes = 0;
    }


    void Update()
    {
        if (stop_stress == false)
        {
            stress += stress_gain * Time.deltaTime;
            stress_meter.value = stress;
        }


        if (hours != 5)
        {

            if (minutes < 60)
            {
                minutes += Time.deltaTime * time_scaling;
            }
            if (minutes >= 60)
            {
                minutes = 0;
                hours += 1;
            }
            if (hours == 13)
            {
                hours = 1;
            }
        }


        timer_text.text = string.Format("{0:00}:{1:00}", hours, minutes);
    }
}
