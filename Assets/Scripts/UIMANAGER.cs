using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMANAGER : MonoBehaviour {
    public Text TimeText;
    public Text ScoreText;
    public Text ItemText;
    public Text endText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateTimeText(float score)
        
    {
        showmyui(TimeText);
        TimeText.text = score.ToString("n2");
    }
  public   void UpdateScoreText(int score)
    {
        showmyui(ScoreText); 
        ScoreText.text = score.ToString();

    }
    public void End(int score)
    {
        showmyui(endText);
        endText.text = " You made " + score + " items " + "press 'Z' to play again";

    }
    public  void showItem(string s)
    {
        showmyui(ItemText);
        // this.gameObject.SetActive(true);
        ItemText.text = s;
    }
    public void hidemyui(Text t)
    {
        t.gameObject.SetActive(false);

    }
    public void showmyui(Text t)
    {
        t.gameObject.SetActive(true);
    }
        
        


}
