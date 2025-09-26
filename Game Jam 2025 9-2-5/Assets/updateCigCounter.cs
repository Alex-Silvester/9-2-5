using TMPro;
using UnityEngine;

public class updateCigCounter : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        text.GetComponent<TMP_Text>().text = $"Cigarettes: {player.GetComponent<PlayerController>().destress_cig}";
    }
}
