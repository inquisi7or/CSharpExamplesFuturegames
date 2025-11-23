using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public interface IUIInventoryFactory {
    GameObject CreatePanel(Transform parent);
    Button CreateButton(Transform parent, string text, UnityAction onClick);
    Text CreateLabel(Transform parent, string text);
}
