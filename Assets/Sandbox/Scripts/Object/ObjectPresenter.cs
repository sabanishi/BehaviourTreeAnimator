using Sabanishi.Core;
using UniRx;
using UnityEngine;

namespace Sabanishi.BehaviourTreeeAnimator.Object
{
    /// <summary>
    /// ObjectのPresenterの基底クラス
    /// </summary>
    public class ObjectPresenter<TModel,TActor>:ActorPresenter<TModel,TActor>
        where TModel:ObjectModel where TActor:ObjectActor
    {
        private Subject<string> _testSubject;
        
        public ObjectPresenter(TModel model):base(model)
        {
        }

        protected override void ActivateInternal(IScope scope)
        {
            _testSubject = new();
            _testSubject.TakeUntil(scope).Subscribe(Debug.Log);
        }

        protected override void DeactivateInternal()
        {
        }

        public void Fire(string text)
        {
            _testSubject?.OnNext(text);
        }
    }
}