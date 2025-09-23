using UnityEngine;

public class BossScript : MonoBehaviour
{

    public TimerStressScript stress_script;




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerCharacter") 
        {
            stress_script.boss_close = true;
            Debug.Log(other.gameObject.name + " has entered boss collision area");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PlayerCharacter")
        {
            stress_script.boss_close = false;
            Debug.Log(other.gameObject.name + " has exited boss collision area");
        }

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
