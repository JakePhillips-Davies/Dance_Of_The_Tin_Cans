using System.Collections.Generic;
using BehaviourTree;
using UnityEngine;

[RequireComponent(typeof(SpaceShip))]
public class MinerBT : BehaviourTree.Tree
{
    protected override Node SetupTree()
    {
        SpaceShip ship = GetComponent<SpaceShip>();

        Node root = new Runner(new List<Node>() {

                        new Selector(new List<Node>() { // Handle target locking

                            new CheckIsTargetLocked(ship),
                            new LogTargetInRange(ship, "Asteroid"),
                            new LogSearchPoint(ship)

                        }),
                        new Sequence(new List<Node>() { // Run a timer

                            new CheckIsTargetLocked(ship),
                            new Timer(ship),
                            new Selector(new List<Node>() { // Re-check for new target

                                new LogTargetInRange(ship, "Asteroid"),
                                new LogSearchPoint(ship)

                            })

                        }),
                        new Sequence(new List<Node>() { // Handle mining

                            new CheckTargetInWeaponRange(ship),
                            new AttackTarget(ship)

                        }),

                        new ClearDirectionLogs(ship), // Clear direction logs

                        new Sequence(new List<Node>() { // Log target direction

                            new CheckIsTargetLocked(ship),
                            new LogTargetDir(ship)

                        }),
                        new Selector(new List<Node>() { // Log search point direction

                            new CheckIsTargetLocked(ship),
                            new LogSearchDir(ship)

                        }),
                        
                        new LogFleeDir(ship, "Pirate"), // Log flee direction
                        new LogAvoidObstacleDir(ship), // Log avoid obstacle direction

                        new CalculateDesiredDir(ship), 

                        new ApplyThrust(ship)

                    });

        return root;
    }
}