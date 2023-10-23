using UnityEngine;

namespace Sabanishi.Core
{
    /// <summary>
    /// ModelとActorの橋渡しとなるPresenter
    /// </summary>
    public class ActorPresenter<TModel,TActor>:Presenter where TModel:Model where TActor:Actor
    {
        protected readonly TModel Model;
        protected TActor Actor;
        
        public ActorPresenter(TModel model)
        {
            Model = model;
            //Actor = actor;
        }
    }
}