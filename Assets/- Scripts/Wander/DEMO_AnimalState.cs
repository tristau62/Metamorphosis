using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LowPolyAnimalPack.DemoScene
{
  [Serializable]
  public class DEMO_AnimalState
  {
    [SerializeField]
    private string stateName = "Walking/Idle";

    [SerializeField]
    private bool defaultState = true;
    public bool DefaultState { get { return defaultState; } }

    [SerializeField]
    private float minStateTime = 20f;
    public float MinStateTime
    {
      get
      {
        return minStateTime;
      }
      set
      {
        minStateTime = Mathf.Clamp(value, 0, maxStateTime);
      }
    }

    [SerializeField]
    private float maxStateTime = 40f;
    public float MaxStateTime
    {
      get
      {
        return maxStateTime;
      }
      set
      {
        maxStateTime = Mathf.Clamp(value, minIdleTime, 100);
      }
    }

    [SerializeField]
    private string animationTriggerEnterState = string.Empty;
    public string AnimationTriggerEnterState { get { return animationTriggerEnterState; } }

    [SerializeField]
    private string animationTriggerExitState = string.Empty;
    public string AnimationTriggerExitState { get { return animationTriggerExitState; } }

    [SerializeField]
    private string animationStateBool = string.Empty;
    public string AnimationStateBool { get { return animationStateBool; } }

    [SerializeField]
    private bool allowMovmentInThisState = true;
    public bool AllowMovmentInThisState { get { return allowMovmentInThisState; } }

    [SerializeField]
    private string animationMovementBool = "isWalking";
    public string AnimationMovementBool { get { return animationMovementBool; } }

    [SerializeField]
    private float moveSpeed = 3;
    public float MoveSpeed
    {
      get
      {
        return moveSpeed;
      }
      set
      {
        moveSpeed = value;
      }
    }

    [SerializeField]
    private float turnSpeed = 2;
    public float TurnSpeed
    {
      get
      {
        return turnSpeed;
      }
      set
      {
        turnSpeed = value;
      }
    }

    [SerializeField]
    private float minIdleTime = 0.5f;
    public float MinIdleTime
    {
      get
      {
        return minIdleTime;
      }
      set
      {
        minIdleTime = Mathf.Clamp(value, 0, maxIdleTime);
      }
    }

    [SerializeField]
    private float maxIdleTime = 2.5f;
    public float MaxIdleTime
    {
      get
      {
        return maxIdleTime;
      }
      set
      {
        maxIdleTime = Mathf.Clamp(value, minIdleTime, 20);
      }
    }
  }
}