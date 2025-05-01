using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[ExecuteInEditMode]
public class FocusController : MonoBehaviour
{
    [SerializeField] UIDocument ui;
    public Transform[] objectList { get; private set; }
    public int focus = 0;
    public string focusName;
    
    private void Awake() {
        UpdateObjectList();
        
        if(ui != null) {
            ui.rootVisualElement.Q<TextField>("Focus").dataSource = this;
            ui.rootVisualElement.Q<Button>("Previous").clickable.clicked += () => {
                if(focus > 0) focus--;
            };
            ui.rootVisualElement.Q<Button>("Next").clickable.clicked += () => {
                if(focus < objectList.Length-1) focus++;
            };
        }
        
    }
    private void OnValidate() {
        UpdateObjectList();
    }

    private void FixedUpdate() {
        UpdateObjectList();
        if (focus >= objectList.Length) focus = objectList.Length-1;
        objectList[focus].GetComponent<SpaceShip>().DebugDirs(true); // Game specific!
    }

    private void Update() {
        focusName = GetFocus().name;
    }

    public void UpdateObjectList() {
        List<Transform> tempList = new();

        foreach (SpaceShip ship in GetComponentsInChildren<SpaceShip>()) { // Game specific!
            tempList.Add(ship.transform);
            ship.DebugDirs(false); // Game specific!
        }

        objectList = tempList.ToArray();
    }

    public Transform GetFocus() {
        return objectList[focus];
    }
}
