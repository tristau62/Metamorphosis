using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace LowPolyAnimalPack.DemoScene
{
  [RequireComponent(typeof(Animator)), RequireComponent(typeof(CharacterController))]
  public class DEMO_Animal : MonoBehaviour
  {
    [SerializeField]
    private DEMO_AnimalState[] states = new DEMO_AnimalState[] { new DEMO_AnimalState() };
    private int currentState = 0;

    [SerializeField]
    private float wanderRange = 10f;
    public float WanderRange
    {
      get
      {
        return wanderRange;
      }
      set
      {
#if UNITY_EDITOR
        SceneView.RepaintAll();
#endif
        //Undo.RecordObject(this, "Change Wander Range");
        wanderRange = value;
      }
    }

    [SerializeField]
    public bool showGizmos = true;

    private Vector3 originalPos;
    private Animator animator;
    private CharacterController characterController;
    private Color rangeColor = new Color(0f, 0f, 205f);
    private Vector3 currentTarget;
    private float currentTurnSpeed;
    private bool changeStatesOnNextIdle = false;

    private const float distanceToReachTarget = 0.2f;

    public void OnDrawGizmosSelected()
    {
      if (!showGizmos)
        return;

      // Draw circle of radius.
      Gizmos.color = rangeColor;
      Gizmos.DrawWireSphere(originalPos == Vector3.zero ? transform.position : originalPos, wanderRange);

      if (!Application.isPlaying)
        return;

      // Draw target position.
      if (currentTarget != Vector3.zero)
      {
        Gizmos.DrawSphere(currentTarget + new Vector3(0f, 0.1f, 0f), 0.2f);
        Gizmos.DrawLine(transform.position, currentTarget);
      }
    }

    private void Awake()
    {
      if (states.Length == 0)
      {
        Debug.LogError("No states found.");
        enabled = false;
        return;
      }

      originalPos = transform.position;
      animator = GetComponent<Animator>();
      characterController = GetComponent<CharacterController>();
    }

		private void Start()
		{
			if (states.Length > 1)
			{
				List<int> defaultStates = new List<int>();
				int currentState = 0;
				foreach (DEMO_AnimalState state in states)
				{
					if (state.DefaultState)
					{
						defaultStates.Add(currentState);
					}
					currentState++;
				}

				if (defaultStates.Count == 0)
				{
					BeginState(0);
					return;
				}

				BeginState(defaultStates[Random.Range(0, defaultStates.Count)]);
				return;
			}

			BeginState(0);
		}

    private void BeginState(int newState)
    {
      currentState = newState;

      if (states.Length > 1)
      {
        StartCoroutine(State(GetStateTime()));
      }

      // Animator updates.
      if (!string.IsNullOrEmpty(states[currentState].AnimationTriggerEnterState))
      {
        animator.SetTrigger(states[currentState].AnimationTriggerEnterState);
      }
      if (!string.IsNullOrEmpty(states[currentState].AnimationStateBool))
      {
        animator.SetBool(states[currentState].AnimationStateBool, true);
      }

      if (states[currentState].AllowMovmentInThisState)
      {
        StartCoroutine(Idle(Random.Range(0, (states[currentState].MaxIdleTime / 2) * 100) / 100));
      }
    }

    private IEnumerator State(float stateTime)
    {
      yield return new WaitForSeconds(stateTime);

      if (!states[currentState].AllowMovmentInThisState)
      {
        ChangeStates();
      }
      else
      {
        changeStatesOnNextIdle = true;
      }
    }

    private void ChangeStates()
    {
      changeStatesOnNextIdle = false;

      // Get next state.
      int newState = Random.Range(0, states.Length);
      if (states.Length > 1 && newState == currentState)
      {
        ChangeStates();
        return;
      }

      // Animator updates.
      if (!string.IsNullOrEmpty(states[currentState].AnimationTriggerExitState))
      {
        animator.SetTrigger(states[currentState].AnimationTriggerExitState);
      }
      if (!string.IsNullOrEmpty(states[currentState].AnimationStateBool))
      {
        animator.SetBool(states[currentState].AnimationStateBool, false);
      }

      BeginState(newState);
    }

    private IEnumerator Walk(Vector3 target)
    {
      currentTarget = target;
      currentTurnSpeed = states[currentState].TurnSpeed;

      if (!string.IsNullOrEmpty(states[currentState].AnimationMovementBool))
      {
        animator.SetBool(states[currentState].AnimationMovementBool, true);
      }

      float walkTime = 0f;
      float timeUntilAbortWalk = Vector3.Distance(transform.position, target) / states[currentState].MoveSpeed;

      while (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.y), new Vector3(target.x, 0, target.y)) > distanceToReachTarget && walkTime < timeUntilAbortWalk)
      {
        characterController.SimpleMove(transform.TransformDirection(Vector3.forward) * states[currentState].MoveSpeed);

        Vector3 relativePos = target - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * currentTurnSpeed);
        currentTurnSpeed += Time.deltaTime;

        walkTime += Time.deltaTime;
        yield return null;
      }

      currentTarget = Vector3.zero;
      StartCoroutine(Idle(GetIdleTime()));
    }

    private IEnumerator Idle(float idleTime)
    {
      if (!string.IsNullOrEmpty(states[currentState].AnimationMovementBool))
      {
        animator.SetBool(states[currentState].AnimationMovementBool, false);
      }

      if (changeStatesOnNextIdle)
      {
        ChangeStates();
        yield break;
      }

      yield return new WaitForSeconds(idleTime);

      if (changeStatesOnNextIdle)
      {
        ChangeStates();
        yield break;
      }

      StartCoroutine(Walk(RandonPointInRange()));
    }

    private Vector3 RandonPointInRange()
    {
      Vector3 randomPoint = originalPos + Random.insideUnitSphere * wanderRange;
      return new Vector3(randomPoint.x, transform.position.y, randomPoint.z);
    }

    private float GetIdleTime()
    {
      return Random.Range(states[currentState].MinIdleTime * 100, states[currentState].MaxIdleTime * 100) / 100;
    }

    private float GetStateTime()
    {
      return Random.Range(states[currentState].MinStateTime * 100, states[currentState].MaxStateTime * 100) / 100;
    }
  }
}