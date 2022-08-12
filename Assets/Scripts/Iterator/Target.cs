using System;

namespace Asteroids.Iterator
{
    [Flags]
    internal enum Target
    {
        Asteroid = 2,
        Comet = 3,
        TurboJet = 5,
        None = 0,
    }
}
