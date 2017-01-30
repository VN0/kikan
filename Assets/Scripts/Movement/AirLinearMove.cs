﻿using UnityEngine;
using System.Collections;

public class AirLinearMove : MonoBehaviour {
  void FixedUpdate() {
    if (_actFlag) {
      _rigid.AddForce(_inputVec * 2.0f);

      _actFlag = false;
      _inputVec.x = 0;
    }
  }

  public void MoveLeft() {
    _actFlag = true;
    _inputVec.x -= 1;

    if (_inputVec.x < -1)
      _inputVec.x = -1;
  }

  public void MoveRight() {
    _actFlag = true;
    _inputVec.x += 1;

    if (_inputVec.x > 1)
      _inputVec.x = 1;
  }

  [SerializeField] private Rigidbody2D _rigid;
  private bool _actFlag;
  private Vector2 _inputVec;
}
