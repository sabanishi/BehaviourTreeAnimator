using GameAiBehaviour;
using UnityEngine;

namespace Sabanishi.BehaviourTreeeAnimator.PlayerSystem.TreeSystem
{
    /// <summary>
    /// BehaviourTreeControllerを可視化するコンポーネント
    /// </summary>
    public class BehaviourTreeControllerProvider:MonoBehaviour,IBehaviourTreeControllerProvider
    {
        public BehaviourTreeController BehaviourTreeController { get; private set; }

        public void Set(BehaviourTreeController controller)
        {
            BehaviourTreeController = controller;
        }
    }
}