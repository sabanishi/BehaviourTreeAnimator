using UnityEngine;

namespace Sabanishi.Core
{
    /// <summary>
    /// Presenterの基底クラス
    /// </summary>
    public class Presenter:MonoBehaviour
    {
        private DisposableScope _lifeScope;
        public bool IsActive => _lifeScope != null;
        
        private bool _isDisposed;
        
        /// <summary>
        /// 有効化
        /// </summary>
        public void Activate()
        {
            //既にActivate済み、またはDispose済みの時、以降の処理を行わない
            if(_lifeScope != null || _isDisposed) return;
            
            _lifeScope = new();
            ActivateInternal(_lifeScope);
        }

        /// <summary>
        /// 無効化
        /// </summary>
        public void Deactivate()
        {
            _lifeScope.Dispose();
            _lifeScope = null;
            DeactivateInternal();
        }

        /// <summary>
        /// 破棄処理
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed) return;
            _isDisposed = true;
            Deactivate();
            DisposeInternal();
        }
        
        public void Update()
        {
            UpdateInternal();
        }
        
        public void LateUpdate()
        {
            LateUpdateInternal();
        }

        public void FixedUpdate()
        {
            FixedUpdateInternal();
        }

        protected virtual void ActivateInternal(IScope scope)
        {
        }
        
        protected virtual void DeactivateInternal()
        {
        }
        
        protected virtual void DisposeInternal()
        {
        }
        
        protected virtual void UpdateInternal()
        {
        }
        
        protected virtual void LateUpdateInternal()
        {
        }
        
        protected virtual void FixedUpdateInternal()
        {
        }
    }
}