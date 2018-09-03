using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Invading.StateCore {
    public class GlobalGameController : MonoBehaviour, IStateMachine<GlobalGameController> {

        public IState<GlobalGameController> currentState;
        public void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
        public void ChangeState(IState<GlobalGameController> newState)
        {
            if(currentState != null)
            {
                currentState.DeinitState(this);
            }
            currentState = newState;
            if(currentState != null)
            {
                currentState.InitState(this);
            }
        }

        public void UpdateState()
        {
            if(currentState != null)
            {
                currentState.UpdateState(this);
            }
            
        }

        void Update () {
            UpdateState();
	    }
    
   

    }    
    }