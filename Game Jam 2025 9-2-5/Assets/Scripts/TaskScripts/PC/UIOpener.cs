using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIOpener : MonoBehaviour
{
    [SerializeField] 
    List<Image> new_UIs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < new_UIs.Capacity; i++)
        {
            new_UIs[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openUI()
    {
        for (int i = 0; i < new_UIs.Capacity; i++)
        {
            new_UIs[i].gameObject.SetActive(true);
        }
    }
}
