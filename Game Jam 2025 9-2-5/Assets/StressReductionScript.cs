using UnityEngine;

public class StressReductionScript : MonoBehaviour
{

    public TimerStressScript StressScript;


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " has entered collision area");
        StressScript.invert_stress = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " has left collsion area");
        StressScript.invert_stress = true;
    }



}
