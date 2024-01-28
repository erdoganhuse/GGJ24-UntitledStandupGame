using Library.SignalBusSystem;

namespace Modules.Gameplay.Signal
{
    public class LevelStartedSignal : ISignal
    {
        public readonly Level SpawnedLevel;

        public LevelStartedSignal(Level spawnedLevel)
        {
            SpawnedLevel = spawnedLevel;
        }
    }
}