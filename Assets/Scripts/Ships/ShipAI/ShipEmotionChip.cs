using System;
using EditorAttributes;
using Unity.VisualScripting;
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
    [field: SerializeField, Range(0.01f, 10f)] public float cautiousness  {get; private set;}
    [field: SerializeField, Range(0.01f, 10f)] public float fearfulness  {get; private set;}
    [field: SerializeField, Range(0.01f, 10f)] public float jumpiness  {get; private set;}
    [field: SerializeField, Range(0.01f, 10f)] public float greediness  {get; private set;}
    [field: SerializeField] public float normalMaxSpeed  {get; private set;}

    [field: Space(10)]
    [field: Title("Emotion")]
    [field: SerializeField, ReadOnly] public float caution  {get; private set;}
    [field: SerializeField, ReadOnly] public float fear  {get; private set;}
    [field: SerializeField, ReadOnly] public float greed  {get; private set;}

    
    [field: Space(10)]
    [field: Title("Timeout")]
    [field: SerializeField] public float timeoutTime  {get; private set;}
    [field: SerializeField, ReadOnly] public float timer  {get; private set;}



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

        float obstacleDistVar = Mathf.Max(0f, 1 - (ship.closestObstacleDist/ship.avoidObstacleRange));
        float hostileDistVar = Mathf.Max(0f, 1 - (ship.closestHostileDist/ship.searchRange));
        float targetDistVar = Mathf.Max(0f, 1 - (ship.targetDist/ship.searchRange));
        float weaponRangeVar = Mathf.Max(0f, 1 - (ship.gun.range/ship.searchRange));
        float healthVar = 100 * -ship.health.healthChange/ship.health.maxHealth;

        // Caution
        float newCaution = cautiousness * (3 - 2 * (ship.health.currentHealth / ship.health.maxHealth)) * (
            obstacleDistVar * (2f/3f) +
            hostileDistVar * (1f/3f) +
            jumpiness * healthVar
        );

        // Fear
        float newFear = fearfulness * (3 - 2 * (ship.health.currentHealth / ship.health.maxHealth)) * (
            obstacleDistVar * (1f/3f) +
            hostileDistVar * (2f/3f) +
            jumpiness * 1.5f * healthVar
        );

        float newGreed = greediness * (
            (targetDistVar < weaponRangeVar) ? 
                Mathf.Max(0.25f, targetDistVar)
            :
                Mathf.Max(0.05f, weaponRangeVar - (weaponRangeVar * (1 - ((1 - targetDistVar) / (1 - weaponRangeVar))) * 2f))
        );

        caution = newCaution;
        fear = (newFear > fear)? newFear : Mathf.Lerp(newFear, fear, 0.99f);
        greed = newGreed;

        ship.SetMaxSpeed(Mathf.Clamp(normalMaxSpeed + (fear * normalMaxSpeed / 10) - (caution * normalMaxSpeed / 10) + (greed * normalMaxSpeed / 10), normalMaxSpeed / 2, normalMaxSpeed * 1.5f));

    }


    #endregion
//--#

//--#
    #region Timer


    public void IncramentTimer(float time) {
        timer += time;
    }
    public void ResetTimer() {
        timer = 0;
    }


    #endregion
}
