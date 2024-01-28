using Library.SignalBusSystem;

namespace Modules.Gameplay
{
    public class CharacterSelectedSignal : ISignal
    {
        public readonly string CharacterName;

        public CharacterSelectedSignal(string characterName)
        {
            CharacterName = characterName;
        }
    }
}