using UnityEngine;
using UnityEngine.UI;

public class FinalScoreScript : MonoBehaviour
{
    [SerializeField] Text score_text;
    [SerializeField] Text final_text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        string static_Score = StaticDataScript.final_score;
        score_text.text = static_Score;

        if (StaticDataScript.win_condition == true)
        {
            final_text.text = "you survived!";
        }
        if (StaticDataScript.win_condition == false)
        {
            final_text.text = "Over stressed!";
        }

    }

}
