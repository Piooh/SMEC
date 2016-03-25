using UnityEngine;
using System.Collections;

public class RunningDust : StateMachineBehaviour
{
	public GameObject dustPrefab = null;
	private ParticleSystem dustFx = null;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
 		if( false == animator.gameObject.tag.Equals( "Player" ) )	{ return; }

		if( null == dustFx )
		{
			var go = Instantiate( dustPrefab, Vector3.zero, Quaternion.identity ) as GameObject;
			dustFx = go.GetComponent<ParticleSystem>();
			go.transform.parent = animator.gameObject.transform;
		}

		dustFx.Play();
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if( null == dustFx || false == animator.gameObject.tag.Equals( "Player" )  ) { return; }

		dustFx.Stop();
	}
}
