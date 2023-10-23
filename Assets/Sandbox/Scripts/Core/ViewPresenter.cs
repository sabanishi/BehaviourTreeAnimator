namespace Sabanishi.Core
{
    /// <summary>
    /// ModelとViewの橋渡しとなるPresenter
    /// </summary>
    public class ViewPresenter<TModel,TView> where TModel:Model where TView:View
    {
        protected readonly TModel Model;
        protected readonly TView View;
        
        public ViewPresenter(TModel model,TView view)
        {
            Model = model;
            View = view;
        }
    }
}