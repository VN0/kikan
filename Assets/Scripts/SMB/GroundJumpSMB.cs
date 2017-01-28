﻿using UnityEngine;
using System.Collections;

public class GroundJumpSMB : StateMachineBehaviour {
  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    if (_rigidState == null) {
      _rigidState = animator.GetComponent<RigidState>();
      _jump = animator.GetComponent<GroundJump>();
    }

    Debug.Log("jump");
    _transitionFlag = false;
    _jump.Jump();
  }

  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    if (_rigidState.Ground && _transitionFlag)
      GroundUpdate(animator);

    if (_rigidState.Air)
      _transitionFlag = true;
  }

  private void GroundUpdate(Animator animator) {
    if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) {
      animator.SetBool("WalkLeft", true);
      animator.SetBool("GroundJump", false);
      return;
    }

    if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)) {
      animator.SetBool("WalkRight", true);
      animator.SetBool("GroundJump", false);
      return;
    }

    if (Input.GetButton("Jump")) {
      _transitionFlag = false;
      _jump.Jump();
      return;
    } else {
      animator.SetBool("Idle", true);
      animator.SetBool("GroundJump", false);
      return;
    }
  }

  private RigidState _rigidState;
  private GroundJump _jump;
  private bool _transitionFlag;
}

