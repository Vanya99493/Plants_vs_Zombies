using System;

namespace Interfaces
{
    public interface IDestroyable
    {
        public event Action<IDestroyable> DestroyEvent;

        public void Destroy();
    }
}