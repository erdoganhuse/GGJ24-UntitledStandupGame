using Library.SignalBusSystem;

namespace Modules.Gameplay
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