using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class AvatorCtrl : MonoBehaviour {

    protected Animator animator;
    public float DirectionDampTime = .25f;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(animator)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            if(stateInfo.nameHash == Animator.StringToHash("Base Layer.Idle"))
            {
                if (Input.GetKeyUp("1"))
                    animator.SetBool("Attack",true);
                else
                    animator.SetBool("Attack", false);
            }

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            animator.SetFloat("Speed", h * h + v * v);
            animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);
        }
	}
}
