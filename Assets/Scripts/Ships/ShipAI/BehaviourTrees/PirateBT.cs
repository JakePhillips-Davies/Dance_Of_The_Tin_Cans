using System.Collections.Generic;
using BehaviourTree;
using UnityEngine;

[RequireComponent(typeof(SpaceShip))]
public class PirateBT : BehaviourTree.BehaviurTree
{
    protected override Node SetupTree()
    {
        SpaceShip ship = GetComponent<SpaceShip>();

        return  new Runner(new List<Node>() {

                    new Selector(new List<Node>() { // Handle target locking

                        new CheckIsTargetLocked(ship),
                        new LogTargetInRange(ship, "Miner"),
                        new LogSearchPoint(ship)

                    }),
                    new Sequence(new List<Node>() { // Run a timer

                        new CheckIsTargetLocked(ship),
                        new Timer(ship.shipEmotionChip.timeoutTime),
                        new Selector(new List<Node>() { // Re-check for new target

                            new LogTargetInRange(ship, "Miner"),
                            new LogSearchPoint(ship)

                        })

                    }),
                    new Sequence(new List<Node>() { // Handle attacking

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
                    
                    new LogFleeDir(ship, "Cop"), // Log flee direction
                    new LogAvoidObstacleDir(ship), // Log avoid obstacle direction

                    new CalculateDesiredDir(ship), 

                    new ApplyThrust(ship)

                });
    }
}