using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[ExecuteInEditMode]
public class AutoCentre : MonoBehaviour
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
    private void Update() {
        transform.position -= objectList[focus].position;

        focusName = objectList[focus].name;
    }


    private void OnValidate() {
        UpdateObjectList();
    }


    public void UpdateObjectList() {
        List<Transform> tempList = new();

        foreach (SpaceShip ship in GetComponentsInChildren<SpaceShip>()) {
            tempList.Add(ship.transform);
        }

        objectList = tempList.ToArray();
    }
}
