using System.Collections.Generic;
using BehaviourTrees;
using UnityEngine;

[RequireComponent(typeof(SpaceShip))]
public class BountyHunterBT : BehaviourTrees.BehaviourTree
{
    protected override Node SetupTree()
    {
        SpaceShip ship = GetComponent<SpaceShip>();

        return  new Selector(new List<Node>() {

                    new Sequence(new List<Node>() { // Leaving

                        new CheckIfWantingToLeave(ship),
                        new Runner(new List<Node>() {

                            new ClearDirectionLogs(ship), // Clear direction logs

                            new LogLeaveDir(ship),
                            new LogAvoidObstacleDir(ship), // Log avoid obstacle direction

                            new CalculateDesiredDir(ship), 

                            new ApplyThrust(ship),

                            new AttemptToLeave(ship)

                        })

                    }),

                    new Runner(new List<Node>() { // Working
                        
                        new Selector(new List<Node>() { // Handle target locking

                            new CheckIsTargetLocked(ship),
                            new LogTargetInRange(ship, "Pirate"),
                            new LogSearchPoint(ship)

                        }),
                        new Sequence(new List<Node>() { // Run a timer

                            new CheckIsTargetLocked(ship),
                            new Timer(ship.shipEmotionChip.timeoutTime, "boredomTimer"),
                            new Selector(new List<Node>() { // Re-check for new target

                                new LogTargetInRange(ship, "Pirate"),
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
                        
                        new LogAvoidObstacleDir(ship), // Log avoid obstacle direction

                        new CalculateDesiredDir(ship), 

                        new ApplyThrust(ship)

                    })

                });
    }
}