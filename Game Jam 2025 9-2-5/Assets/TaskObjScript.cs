using UnityEngine;

public class TaskObjScript : MonoBehaviour
{
    bool collision = false;
    bool active = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(collision == true && Input.GetKeyDown(KeyCode.F))
        {
            gameObject.SetActive(false);
            active = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        collision = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited");
        collision = false;
    }  

    public bool isActive()
    {
        return active;
    }
}
