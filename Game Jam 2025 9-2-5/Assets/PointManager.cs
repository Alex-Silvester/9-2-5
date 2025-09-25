using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI Points_Text;
    public int Score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Points_Text.text = ("Points:" + Score.ToString());
        StaticDataScript.final_score = Points_Text.text;
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    Score = Score + 1;    
        //}
    }
}
