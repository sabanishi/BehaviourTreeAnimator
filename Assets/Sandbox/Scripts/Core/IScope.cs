using System;
using System.Threading;
using UniRx;

namespace  Sabanishi.Core
{
    /// <summary>
    /// スコープ管理用インターフェース
    /// </summary>
    public interface IScope
    {
        /**キャンセル用Token*/
        CancellationToken Token { get; }
        /**終了通知用Observable*/
        IObservable<Unit> OnDisposedAsObservable { get; }
    }
}