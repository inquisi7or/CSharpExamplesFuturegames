using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class WeaponsInventoryFactory : IUIInventoryFactory {
    private readonly GameObject _panelPrefab;
    private readonly GameObject _buttonPrefab;
    private readonly GameObject _labelPrefab;

    public WeaponsInventoryFactory(GameObject panelPrefab, GameObject buttonPrefab, GameObject labelPrefab) {
        _panelPrefab = panelPrefab;
        _buttonPrefab = buttonPrefab;
        _labelPrefab = labelPrefab;
    }

    public GameObject CreatePanel(Transform parent) {
        return Object.Instantiate(_panelPrefab, parent);
    }

    public Button CreateButton(Transform parent, string text, UnityAction onClick) {
        GameObject go = Object.Instantiate(_buttonPrefab, parent);
        Button button = go.GetComponent<Button>();
        Text label = go.GetComponentInChildren<Text>();

        if(label != null) {
            label.text = text;
        }

        if(button != null && onClick != null) {
            button.onClick.AddListener(onClick);
        }

        return button;
    }

    public Text CreateLabel(Transform parent, string text) {
        GameObject go = Object.Instantiate(_labelPrefab, parent);
        Text label = go.GetComponent<Text>();
        if(label != null) {
            label.text = text;
        }

        return label;
    }
}
