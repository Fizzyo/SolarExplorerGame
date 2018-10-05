using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fizzyo;

public class DisplayScore : MonoBehaviour {
    public int score;
    public Text displayedScore;
	// Use this for initialization
	void Start () {
        score = BackGround.score;
        displayedScore = GameObject.FindGameObjectWithTag("finalscore").GetComponent<Text>();
        displayedScore.text = "Your Score: " + score.ToString();
        FizzyoFramework.Instance.Achievements.PostScore(score);
        if (score > 500000)
        {
            FizzyoFramework.Instance.Achievements.UnlockAchievement("78f29b82 - 6439 - 4b67 - 81f8 - bfba8e10ae5c");
        }
        else if (score > 1000000)
        {
            FizzyoFramework.Instance.Achievements.UnlockAchievement("fe2329f2-1d75-4c78-9be3-a464783601c9");
        }
        else if (score > 2000000)
        {
            FizzyoFramework.Instance.Achievements.UnlockAchievement("7f1ac5a7-02bc-4193-be87-6288af7fe2ea");

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
