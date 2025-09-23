using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class closePanel : MonoBehaviour
{
    [SerializeField]
    Image previous_panel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeCurrentPanel()
    {
        gameObject.SetActive(false);

        if(!previous_panel.IsUnityNull())
        { 
            previous_panel.GetComponent<closePanel>().closeCurrentPanel(); 
        }
    }
}
