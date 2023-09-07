using System;
using UnityEngine;

namespace ViewModels
{
    [CreateAssetMenu(menuName = "ViewModels/PlayerUiViewModel")]
    public class PlayerUiViewModel : ScriptableObject
    {
        private const string NameButtonTextActive = "적용하기";
        private const string NameButtonTextInactive = "이름변경";
        private const string MessageIncorrectName = "이름은 2글자이상 10글자이하로 정해주세요.";

        private event Action _onValuesChanged;
        public event Action<string> NameChanged;
        public event Action<string> ButtonTextChanged;
        public event Action<bool> NameFieldVisibleChanged;
        public event Action<string> NameFieldTextChanged;
        public event Action<string> MessageChannel;

        [SerializeField] private string _nameFieldText = string.Empty;
        [SerializeField] private string _characterName;
        [SerializeField] private string _buttonText = NameButtonTextInactive;
        [SerializeField] private bool _isVisibleNameField;

        public PlayerUiViewModel()
        {
            _characterName = "이름";
            _onValuesChanged += () => NameChanged?.Invoke(_characterName);
            _onValuesChanged += () => ButtonTextChanged?.Invoke(_buttonText);
            _onValuesChanged += () => NameFieldVisibleChanged?.Invoke(_isVisibleNameField);
            _onValuesChanged += () => NameFieldTextChanged?.Invoke(_nameFieldText);
        }

        public void Bind()
        {
            _onValuesChanged?.Invoke();
        }

        public void ChangeNameClicked()
        {
            if (_isVisibleNameField)
            {
                _characterName = _nameFieldText;
            }

            _isVisibleNameField = !_isVisibleNameField;
            _buttonText = _isVisibleNameField ? NameButtonTextActive : NameButtonTextInactive;
            _onValuesChanged?.Invoke();
        }

        private bool ValidateName(string newName)
        {
            return newName.Length >= 2 && newName.Length <= 10;
        }

        private void OnValidate()
        {
            _onValuesChanged?.Invoke();
        }

        public void ChangeNameFieldValue(string newValue)
        {
            if (ValidateName(newValue))
            {
                _nameFieldText = newValue;
            }
            else
            {
                MessageChannel?.Invoke(MessageIncorrectName);
            }
        }
    }
}