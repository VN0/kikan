﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bunashibu.Kikan {
  public interface ILobbyMovementPlayer : IMonoBehaviour {
    Rigidbody2D Rigid { get; }
  }
}
