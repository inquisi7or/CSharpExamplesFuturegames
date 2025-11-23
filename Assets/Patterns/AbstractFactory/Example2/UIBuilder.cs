using UnityEngine;
using UnityEngine.UI;

public enum UIInventoryCategory {
    Weapons,
    Potions,
    Other
}

public class UIBuilder : MonoBehaviour {
    [Header("General")]
    public UIInventoryCategory inventoryCategory;
    public Transform uiRoot; // e.g. a panel under the Canvas

    [Header("Prefabs")]
    public GameObject panelPrefab;
    public GameObject buttonPrefab;
    public GameObject labelPrefab;

    private IUIInventoryFactory factory;

    private void Awake() {
        // Choose concrete factory based on theme
        switch(inventoryCategory) {
            case UIInventoryCategory.Weapons:
                factory = new WeaponsInventoryFactory(panelPrefab, buttonPrefab, labelPrefab);
                break;
            case UIInventoryCategory.Potions:
                factory = new PotionsInventoryFactory(panelPrefab, buttonPrefab, labelPrefab);
                break;
        }
    }

    private void Start() {
        if(factory == null) {
            Debug.LogError("UIBuilder: factory not set. Check theme and prefabs.");
            return;
        }

        if(uiRoot == null) {
            Debug.LogError("UIBuilder: uiRoot not assigned.");
            return;
        }

        // Build a small menu using only the abstract factory
        GameObject panel = factory.CreatePanel(uiRoot);
        factory.CreateLabel(panel.transform, "Main Menu");
        factory.CreateButton(panel.transform, "Start Game", () => Debug.Log("Start Game clicked"));
        factory.CreateButton(panel.transform, "Options", () => Debug.Log("Options clicked"));
        factory.CreateButton(panel.transform, "Quit", () => Debug.Log("Quit clicked"));
    }
}
