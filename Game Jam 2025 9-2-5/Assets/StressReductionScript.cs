using UnityEngine;

public class StressReductionScript : MonoBehaviour
{

    public TimerStressScript StressScript;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.name == "PlayerCharacter")
        {
            Debug.Log(collision.gameObject.name + " has entered collision area");
            StressScript.invert_stress = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.name == "PlayerCharacter")
        {
            Debug.Log(collision.gameObject.name + " has left collsion area");
            StressScript.invert_stress = true;
        }
    }


}
