using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class Actions : MonoBehaviour {

	private Animator animator;

	const int countOfDamageAnimations = 3;
	int lastDamageAnimation = -1;

	public float walk;
	public float run;

	void Awake () {
		animator = GetComponent<Animator> ();
	}

	public void Stay () {
		animator.SetFloat ("Speed", 0f);
		}

	public void Walk () {
		animator.SetFloat ("Speed", walk);
	}

	public void Run () {
		animator.SetFloat ("Speed", run);
	}


    public void Death () {
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Death"))
			animator.Play("Idle", 0);
		else
			animator.SetTrigger ("Death");
	}




}
