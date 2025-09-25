using UnityEngine;
using UnityEngine.UI;

public class CoffeeProgressScript : MonoBehaviour
{
    [SerializeField]
    CoffeeMachine coffee_task;

    [SerializeField]
    GameObject interaction_UI;

    [SerializeField]
    GameObject progress_bar;

    bool in_range = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interaction_UI.SetActive(true);

        progress_bar.transform.Find("ProgressBar").GetComponent<Slider>().value = 0.0f;

        coffee_task.coffee_made = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(in_range)
        {
            progress_bar.SetActive(true); 
        }
        else
        {
            progress_bar.SetActive(false);
        }

        progress_bar.transform.Find("ProgressBar").GetComponent<Slider>().value = coffee_task.time / 3.0f;

        if(coffee_task.coffee_made)
        {
            interaction_UI.SetActive(true);
        }
        else
        {
            interaction_UI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        in_range = true;
    }

    private void OnTriggerExit(Collider other)
    {
        in_range = false;
    }
}
