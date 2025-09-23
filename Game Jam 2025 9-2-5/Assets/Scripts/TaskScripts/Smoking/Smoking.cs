using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Smoking", menuName = "Scriptable Objects/Smoking")]
public class Smoking : Task
{
    public override void run()
    {
        Debug.Log("Smoking");
        optional_interactable.GetComponent<TimerStressScript>().stress -= 20.0f;
        complete = true;
    }
}
