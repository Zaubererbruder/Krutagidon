using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class StateMachineBase<T>
    {
        protected T _state;
        public T State => _state;

        public delegate void StateChangedDelegate(T previousState, T newState);
        public event StateChangedDelegate StateChanged;

        public virtual void SetState(T state)
        {
            T prevState = _state;
            _state = state;
            StateChanged?.Invoke(prevState, state);
        }
    }

    public class StateMachineException : Exception
    {
        public StateMachineException() : base() { }
        public StateMachineException(string message) : base(message) { }
    }
}
