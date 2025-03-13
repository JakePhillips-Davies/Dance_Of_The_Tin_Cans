using System.Collections.Generic;
using BehaviourTree;
using UnityEngine;

[RequireComponent(typeof(SpaceShip))]
public class MinerBT : BehaviourTree.Tree
{
    protected override Node SetupTree()
    {
        SpaceShip ship = GetComponent<SpaceShip>();

        Node root = new Selector(new List<Node>() {

                        new Sequence(new List<Node>() {

                            new CheckTargetInWeaponRange(ship),
                            new AttackTarget(ship),
                            new MoveUpToTarget(ship)

                        }),
                        new Sequence(new List<Node>() {

                            new CheckForAsteroidInRange(ship),
                            new MoveUpToTarget(ship)

                        }),
                        new Wander(ship)

                    });

        return root;
    }
}