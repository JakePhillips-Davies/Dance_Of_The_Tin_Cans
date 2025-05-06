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
    public string focusInfo = "eee\neee";
    private Transform cachedFocus;
    
    private void Awake() {
        UpdateObjectList();
        
        if(ui != null) {
            ui.rootVisualElement.Q<TextField>("Focus").dataSource = this;
            ui.rootVisualElement.Q<TextField>("FocusInfo").dataSource = this;
            ui.rootVisualElement.Q<Button>("Previous").clickable.clicked += () => {
                focus--;

                if(focus < 0) focus = 0;
                else if(focus > objectList.Length-1) focus = objectList.Length-1;

                cachedFocus = objectList[focus];
            };
            ui.rootVisualElement.Q<Button>("Next").clickable.clicked += () => {
                focus++;

                if(focus > objectList.Length-1) focus = objectList.Length-1;
                else if(focus < 0) focus = 0;

                cachedFocus = objectList[focus];
            };
        }
        
        cachedFocus = objectList[focus];
    }
    private void OnValidate() {
        UpdateObjectList();
        cachedFocus = objectList[focus];
    }

    private void FixedUpdate() {
        UpdateObjectList();
        
        if (GetFocus() != null) {
            GetFocus().GetComponent<SpaceShip>().DebugDirs(true);
            focusInfo = GetFocus().GetComponent<SpaceShip>().StringyyyStriiiingyyyyyy();
        }
    }

    private void Update() {
        if (GetFocus() != null)
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
        return cachedFocus;
    }
}
