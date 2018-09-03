using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Invading.StateCore { 
    public interface IStateMachine<T> {

       void  ChangeState(IState<T> newState);
       void UpdateState();

    }
}