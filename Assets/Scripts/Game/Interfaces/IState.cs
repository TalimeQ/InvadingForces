using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Invading.StateCore {

    public interface IState<T>{
            void InitState(T controller);
            void DeinitState(T controller);
            void UpdateState(T controller);
    }
}