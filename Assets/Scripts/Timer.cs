using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
public class Timer : MonoBehaviour {

	public float time = 30;
	public float maxTime = 30;
	public Image TimerBar;


	void Start () 
	{
	
	}
	
	void Update () 
	{
		if (GameManager.playGame)
		{
			//time is deducting by game time until 0
			if (time > 0)
				time -= Time.deltaTime;
			else
			{
				//call function LoseGame when time runs out
				time = 0;
				GameManager.loseGame = true;
			}
			ShowTimer();
		}
	}

	void ShowTimer()
	{
		if (TimerBar)
		{
			//TimeBar is filled by the time remaining
			float timeRatio = time / maxTime;
			TimerBar.fillAmount = timeRatio;
		}
	}
}
