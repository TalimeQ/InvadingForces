using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invading.StateCore;

namespace Invading.State
{

    public class GameState : IState<GlobalGameController>
    {
        void IState<GlobalGameController>.DeinitState(GlobalGameController controller)
        {
            Debug.Log("Game state  deinitialized");
        }

        void IState<GlobalGameController>.InitState(GlobalGameController controller)
        {
            Debug.Log("Game state initialized");
        }

        void IState<GlobalGameController>.UpdateState(GlobalGameController controller)
        {
            Debug.Log("Game state update");
        }
    }
}