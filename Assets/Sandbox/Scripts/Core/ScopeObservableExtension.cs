using System;
using UniRx;

namespace Sabanishi.Core
{
    /// <summary>
    /// IScope用のUniRx拡張メソッド
    /// </summary>
    public static class ScopeObservableExtension
    {
        public static IObservable<T> TakeUntil<T>(this IObservable<T> self, IScope scope)
        {
            return self.TakeUntil(scope.OnDisposedAsObservable);
        }
    }
}