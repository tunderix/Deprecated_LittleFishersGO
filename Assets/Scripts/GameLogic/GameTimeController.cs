using UnityEngine;
using System.Collections;

public class GameTimeController : MonoBehaviour {

	const int DAY_COUNT = 4;

	public int currentDay;

	public float dayLength;
	public float dayTime;

	public bool gameActive;

	private int lastSecond;
	private int currentSecond;

	void Start () {
		currentDay = 0;
		gameActive = true;
	}

	void Update () {
		if (gameActive) {
			//Check Timer, And act depending on state!
			if (dayTime <= 0) {
				newDay ();
			} else{
				dayTime -= Time.deltaTime;

				currentSecond =  (int)dayTime;
				if (currentSecond != lastSecond) {
					lastSecond = currentSecond;

					secondChanged ();
				}
			}
		}
	}

	private void newDay(){
		switch (currentDay) {
		case 0:
			//Init code before the day ONE? 
			GameStarted();
			initBasicDay ();
			break;
		case DAY_COUNT:
			GameEnded ();
			break;
		default:
			initBasicDay ();
			break;
		}
	}

	private void initBasicDay(){
		currentDay++;
		dayTime = dayLength;
		Debug.Log ("DayChanged : " + currentDay);
	}

	private void GameStarted(){
		Debug.Log ("Game Started");
	}
	private void GameEnded(){
		gameActive = false;
		Debug.Log ("Game Ended");
	}

	private void secondChanged(){
		Debug.Log ("SECOND Changed : " + currentSecond);
	}
		
	public GameTime getCurrentGameTime(){
		return new GameTime (currentDay, currentSecond); 
	}
}
