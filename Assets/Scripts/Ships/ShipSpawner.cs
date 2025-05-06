using System.Collections.Generic;
using UnityEngine;

/*
    #==============================================================#
	
	
	
	
*/
public class ShipSpawner : MonoBehaviour
{    
//--#
    #region Variables


    [field: SerializeField] public List<SpaceShip> ships { get; private set; }

    float timer = 0;


    #endregion
//--#



//--#
    #region Unity events


    private void Start() {
        for (int i = 0; i < 30; i++) {
            SpawnShip();
        }
    }
    private void FixedUpdate() {
        timer += Time.fixedDeltaTime;

        if (timer > 30) {
            timer = 0;
            SpawnShip();
        }
    }


    #endregion
//--#



//--#
    #region Spawn ship


    public void SpawnShip() {
        int i = Random.Range(0, ships.Count);
        Vector3 point = Random.onUnitSphere * 20000;
        SpaceShip ship = Instantiate(ships[i], point, Quaternion.LookRotation(-point, Vector3.up), this.transform);

        ship.rb.linearVelocity = ship.transform.forward * 500;

        ship.shipEmotionChip.cautiousness = Random.Range(0f, 10f);
        ship.shipEmotionChip.fearfulness = Random.Range(0f, 10f);
        ship.shipEmotionChip.jumpiness = Random.Range(0f, 10f);
        ship.shipEmotionChip.greediness = Random.Range(0f, 10f);
    }


    #endregion
//--#



//--#
    #region Remove ship


    public void RemoveShip(SpaceShip ship) {
        Destroy(ship.gameObject);
    }


    #endregion
//--#
}
