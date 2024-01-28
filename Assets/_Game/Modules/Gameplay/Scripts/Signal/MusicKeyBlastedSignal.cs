using Library.SignalBusSystem;

namespace Modules.Gameplay
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