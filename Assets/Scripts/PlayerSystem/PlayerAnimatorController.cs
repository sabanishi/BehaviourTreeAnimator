using GameAiBehaviour;
using Sabanishi.BehaviourTreeeAnimator.PlayerSystem.TreeSystem;
using Sabanishi.Core;
using UnityEngine;

namespace Sabanishi.BehaviourTreeeAnimator.PlayerSystem
{
    /// <summary>
    /// PlayerのAnimatorをBehaviourTreeで制御するためのクラス
    /// </summary>
    public class PlayerAnimatorController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private BehaviourTree tree;

        private BehaviourTreeController _btController;
        
        public void Activate()
        {
            _btController = new();
            _btController.Setup(tree);

            _btController.BindActionNodeHandler<AnimatorNode, AnimatorNodeHandler>(h => h.Setup(animator));
            BindBehaviourTreeController();
        }

        public void Deactivate()
        {
            UnbindBehaviourTreeController();
            _btController.ResetLinkNodeHandlers();
            _btController.ResetConditionHandlers();
            _btController.ResetActionNodeHandlers();
        }

        private void BindBehaviourTreeController()
        {
            if (!gameObject.TryGetComponent<BehaviourTreeControllerProvider>(out var provider))
            {
                provider = gameObject.AddComponent<BehaviourTreeControllerProvider>();
            }

            provider.Set(_btController);
        }

        private void UnbindBehaviourTreeController()
        {
            if (!gameObject.TryGetComponent<BehaviourTreeControllerProvider>(out var provider)) return;
            provider.Set(null);
        }

        public void Update()
        {
            _btController.Update(Time.deltaTime);
        }

        public void SetXVelocity(float value)
        {
            _btController.Blackboard.SetFloat("XSpeed", value);
        }
        
        public void SetYVelocity(float value)
        {
            _btController.Blackboard.SetFloat("YSpeed", value);
        }
        
        public void SetIsGround(bool value)
        {
            _btController.Blackboard.SetBoolean("IsGround", value);
        }
    }
}