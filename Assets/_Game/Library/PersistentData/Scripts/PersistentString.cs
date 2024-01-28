using UnityEngine;

namespace Library.PersistentData.Scripts
{
    public class PersistentString : PersistentVariable<string>
    {
        public PersistentString(string saveKey, string value = default) : base(saveKey, value) { }

        protected override void Save()
        {
            PlayerPrefs.SetString(_saveKey, _value);
        }

        protected override void Load()
        {
            _value = PlayerPrefs.GetString(_saveKey);
        }
    }
}