using Library.SignalBusSystem;

namespace Modules.Gameplay.Signal
{
    public class MusicKeyBlastedSignal : ISignal
    {
        public readonly BaseMusicKey MusicKey;

        public MusicKeyBlastedSignal(BaseMusicKey musicKey)
        {
            MusicKey = musicKey;
        }
    }
}