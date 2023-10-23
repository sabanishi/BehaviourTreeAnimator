using System;
using System.Threading;
using UniRx;

namespace Sabanishi.Core
{
    /// <summary>
    /// スコープ管理用
    /// </summary>
    public class DisposableScope:IScope
    {
        private readonly Subject<Unit> _disposedSubject;
        private readonly CancellationTokenSource _cancellationTokenSource;
        /**廃棄済みか*/
        public bool IsDisposed { get; private set; }
        
        public DisposableScope()
        {
            _cancellationTokenSource = new CancellationTokenSource();
           _disposedSubject = new Subject<Unit>();
        }

        public CancellationToken Token => _cancellationTokenSource.Token;

        public IObservable<Unit> OnDisposedAsObservable=> _disposedSubject;

        /// <summary>
        /// 廃棄処理
        /// </summary>
        public void Dispose()
        {
            if (IsDisposed) return;
            
            IsDisposed = true;
            
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _disposedSubject.OnNext(Unit.Default);
            _disposedSubject.Dispose();
        }
    }
}