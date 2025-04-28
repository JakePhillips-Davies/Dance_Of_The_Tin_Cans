using EditorAttributes;
using UnityEngine;

/*
    #==============================================================#
	
	
	
	
*/
public class SettingsSingleton : MonoBehaviour
{    
//--#
    #region Variables


    public static SettingsSingleton Get {get; private set; }

    [field: Title("Damage")]
    [field: SerializeField] public float collisionDamageScale  {get; private set;}
    [field: SerializeField] public float collisionDamagePower  {get; private set;}

    [field: Space(10)]
    [field: Title("laser")]
    [field: SerializeField] public Material laserMat  {get; private set;}


    #endregion
//--#



//--#
    #region Unity events


    private void Awake() {
        if (Get != null) Debug.LogError("Multiple instances of this singleton found! " + this.name);
        Get = this;
    }


    #endregion
//--#



//--#
    #region Misc functions


    


    #endregion
//--#
}
