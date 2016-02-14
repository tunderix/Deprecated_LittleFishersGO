using UnityEngine;
using System.Collections;

public class FishingTarget_Functionalities : MonoBehaviour {

	//StateMachine Enumeration.
	//------------------------------
	public enum State{
		spawning,
		idle,
		hooked,
		die
	};

	//Attributes
	//------------------------------

	//StateMachine Attributes
	public State state;
	public float time_spawning;
	public float time_idle;
	public float time_hooked;
	public float time_die;
	private float stateTimeLeft;

	//Randomizer TimerValues
	public float time_hook_rand_min;
	public float time_hook_rand_max;
	public float time_hook_random;
	public float time_idle_rand_min;
	public float time_idle_rand_max;
	public float time_idle_random;

	//Animation Attributes
	Animator anim;

	#region StateIEnums
	IEnumerator spawningState ()
	{
		SpawnEnter ();
		while (state == State.spawning) {
			yield return 0;
		}
		SpawnExit ();
		NextState ();
	}

	IEnumerator idleState ()
	{
		IdleEnter ();
		while (state == State.idle) {
			yield return 0;
		}
		IdleExit ();
		NextState ();
	}

	IEnumerator hookedState ()
	{
		HookedEnter ();
		while (state == State.hooked) {
			yield return 0;
		}
		HookedExit ();
		NextState ();
	}

	IEnumerator dieState ()
	{
		DieEnter ();
		while (state == State.die) {
			yield return 0;
		}
		DieExit ();
		NextState ();
	}
	#endregion

	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		NextState ();
	}

	void Update()
	{

		//Check Timer, And act depending on state!
		if (stateTimeLeft <= 0) {
			TimeOff (this.state);
		} else if (stateTimeLeft > -0.2f){
			//decrement timer and set corresponding state depending on currentState;
			stateTimeLeft -= Time.deltaTime;
		}
	}

	void actionAtState(State status){
		
		//Check The Current State:
		switch (status) {
		case State.spawning:
			break;
		case State.idle:
			FishingFailure ();
			break;
		case State.hooked:
			FishingSuccess ();
			break;
		case State.die:
			break;
		}
	}

	void TimeOff(State status){
		//Check The Current State:
		switch (status) {
		case State.spawning:
			this.state = State.idle;
			NextState ();
			break;
		case State.idle:
			this.state = State.hooked;
			NextState ();
			break;
		case State.hooked:
			this.state = State.die;
			NextState ();
			break;
		case State.die:
			this.state = State.idle;
			NextState ();
			break;
		}
	}

	void NextState () {
		string methodName = state.ToString() + "State";
		System.Reflection.MethodInfo info =
			GetType().GetMethod(methodName,
				System.Reflection.BindingFlags.NonPublic |
				System.Reflection.BindingFlags.Instance);
		StartCoroutine((IEnumerator)info.Invoke(this, null));
	}

	void setTime(float timeToSet){
		stateTimeLeft = timeToSet;
	}

	private void SpawnEnter(){
		//set Timings for logics
		this.time_hook_random = Random.Range (this.time_hook_rand_min, this.time_hook_rand_max);
		this.time_idle_random = Random.Range (this.time_idle_rand_min, this.time_idle_rand_max);
		setTime (time_spawning);
	}
	private void SpawnExit(){
	}
	private void IdleEnter(){
		setTime (time_idle + this.time_idle_random);
	}
	private void IdleExit(){

		//Set Animation as FishON;
		anim.SetTrigger("setFishOn");
	}
	private void HookedEnter(){
		Debug.Log ("FishON");
		setTime (time_hooked + this.time_hook_random);
	}
	private void HookedExit(){
	}
	private void DieEnter(){
		Debug.Log ("State: Die Enter");
		anim.SetTrigger("endFishing");
		setTime (time_die);

	}
	private void DieExit(){
		Debug.Log ("State: Die Exit");
		Destroy (gameObject);
	}

	void FishingSuccess(){

		//
		//TODO ---> Call GameController :: SuccessAtFishing;
		//

		Debug.Log("Fishing Success");

		killThisObject ();
	}

	void FishingFailure(){

		//
		//TODO ---> Call GameController :: FailureAtFishing;
		//

		Debug.Log("Fishing Failure");

		killThisObject ();

	}

	void killThisObject(){

		this.state = State.die;
	}
		
	void OnMouseDown()
	{
		actionAtState (this.state);
	}


}
