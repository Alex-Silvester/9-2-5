using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerStressScript : MonoBehaviour
{

    public Slider stress_meter;
    public Slider stress_meter_pc;
    public float max_stress;
    public float stress_gain_multiplier;
    public float stress_reduction_multiplier;
    public bool stop_stress = false;
    public bool invert_stress = false;
    int invert = 1;
    public float stress;


    [SerializeField] TextMeshProUGUI timer_text;
    [SerializeField] TextMeshProUGUI timer_text_pc;
    public float time_scaling;
    int hours;
    float minutes;




    void Start()
    {
        stress = 0;
        stress_meter.maxValue = max_stress;
        stress_meter.value = stress;
        stress_meter_pc.maxValue = max_stress;
        stress_meter_pc.value = stress;
        hours = 9;
        minutes = 0;
    }


    void Update()
    {

        if (invert_stress == true)
        {
            invert *= -1;
            invert_stress = false;
        }


        if (stop_stress == false)
        {
            if (invert == 1)
            {
                stress += stress_gain_multiplier * Time.deltaTime;
                stress_meter.value = stress;
                stress_meter_pc.value = stress;
            }
            if (invert == -1)
            {
                stress -= stress_reduction_multiplier * Time.deltaTime;
                stress_meter.value = stress;
                stress_meter_pc.value = stress;
            }
        }
        if (stress >= max_stress)
        {
            SceneManager.LoadScene("GameOver");
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
        timer_text_pc.text = string.Format("{0:00}:{1:00}", hours, minutes);

        if (stress <= 0)
        {
            stress = 0;
        }
    }
}
