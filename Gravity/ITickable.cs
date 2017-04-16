using System;

namespace Gravity
{
    internal interface ITickable
    {
        void Tick(float deltaTime);
    }
}