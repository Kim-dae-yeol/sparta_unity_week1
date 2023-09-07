using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using ViewModels;
using Button = UnityEngine.UI.Button;

namespace Bindings
{
    public class TownUiBindings : MonoBehaviour
    {
        private float _fontSize = 0.5f;
        private float _width;


        [SerializeField] private PlayerUiViewModel _vm;
        [SerializeField] private TextMeshProUGUI _tmp;

        [SerializeField] private Canvas _playerNameCanvas;
        private RectTransform _canvasRectTransform;

        [SerializeField] private Button _nameButton;

        [SerializeField] private TMP_InputField _nameField;

        private void Awake()
        {
            _canvasRectTransform = _playerNameCanvas.GetComponent<RectTransform>();
        }

        private void Start()
        {
            _vm.NameChanged += OnNameChanged;
            _vm.ButtonTextChanged += OnNameButtonTextChanged;
            _vm.NameFieldVisibleChanged += OnNameFieldVisibleChanged;
            _nameButton.onClick.AddListener(_vm.ChangeNameClicked);
            _nameField.lineLimit = 1;
            _nameField.characterLimit = 10;
            _nameField.onValueChanged.AddListener(_vm.ChangeNameFieldValue);
            _vm.Bind();
        }

        private void OnNameChanged(string newValue)
        {
            UpdatePlayerNameUi(newValue);
        }

        private void OnNameButtonTextChanged(string newValue)
        {
            var text = _nameButton.GetComponentInChildren<TextMeshProUGUI>();
            if (text == null) return;
            text.text = newValue;
        }

        private void OnNameFieldVisibleChanged(bool isVisible)
        {
            if (_nameField == null) return;
            _nameField.gameObject.SetActive(isVisible);
        }

        private void UpdatePlayerNameUi(string characterName)
        {
            _tmp.text = characterName;
            _width = characterName.Length * _fontSize + 0.5f;
        }

        private void FixedUpdate()
        {
            if (Math.Abs(_canvasRectTransform.rect.width - _width) > 0.0005f)
            {
                _canvasRectTransform.sizeDelta = new Vector2(_width, _canvasRectTransform.rect.height);
                var x = _width * 0.5f * -1;
                _canvasRectTransform.localPosition = new Vector2(x: x, y: _playerNameCanvas.transform.localPosition.y);
            }
        }

        private void OnDestroy()
        {
            _vm.NameChanged -= OnNameChanged;
            _vm.NameFieldVisibleChanged -= OnNameFieldVisibleChanged;
            _vm.ButtonTextChanged -= OnNameButtonTextChanged;
            _nameButton.onClick.RemoveAllListeners();
            _nameField.onValueChanged.RemoveAllListeners();
        }
    }
}