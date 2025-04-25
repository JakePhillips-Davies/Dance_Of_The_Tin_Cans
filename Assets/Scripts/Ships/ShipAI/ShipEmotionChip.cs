using EditorAttributes;
using UnityEngine;

/*
    #==============================================================#
	
	
	
	
*/
[RequireComponent(typeof(SpaceShip))]
public class ShipEmotionChip : MonoBehaviour
{    
//--#
    #region Variables


    [field: Title("Personality")]
    [field: SerializeField, Range(0f, 1f)] public float recklessness  {get; private set;}
    [field: SerializeField, Range(0f, 1f)] public float fearlessness  {get; private set;}

    [field: Space(10)]
    [field: Title("Emotion")]
    [field: SerializeField, ReadOnly] public float cautioun  {get; private set;}
    [field: SerializeField, ReadOnly] public float fear  {get; private set;}


    public SpaceShip ship {get; private set;}


    #endregion
//--#



//--#
    #region Unity events


    private void Start() {
        ship = GetComponent<SpaceShip>();
    }


    #endregion
//--#



//--#
    #region Calculate emotion


    public void CalculateEmotion() {

    }


    #endregion
//--#
}
