using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invading.StateCore;

namespace Invading.State {
    public class MenuState : IState<GlobalGameController>
    {
        public void DeinitState(GlobalGameController controller)
        {
            Debug.Log("Game deinit");
        }

        public void InitState(GlobalGameController controller)
        {
            Debug.Log("Game init");
        }

        public void UpdateState(GlobalGameController controller)
        {
            Debug.Log("Game update");
        }
    }
}