﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacuumSim.UI.Floorplan;
using VacuumSim.UI.FloorplanGraphics;


namespace VacuumSim.Components
{
    /// <summary>
    /// Subclass of VacuumController. Wall Follow Pathing algorithm for the Vacuum.
    /// </summary>
    public class VWallFollowAlgorithm : VacuumController
    {
        bool currentlyRoundingACorner = false;

        private string WallFollowAlgVer = "Wall Follow Algorithm Version 2.2";
        public override string getVer()
        {
            return WallFollowAlgVer;
        }


        public override void ExecVPath(VacuumDisplay VacDisplay, FloorplanLayout floorPlan, CollisionHandler collisionHandler, FloorCleaner floorCleaner, Vacuum ActualVacuumData)
        {
            //Debug.WriteLine("running wall follow algorithm");
            
            var collision = collisionHandler;
            int battery = VacDisplay.batterySecondsRemaining;

            if (battery > 0)
            {
               
                ActualVacuumData.VacuumCoords[0] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Cos((Math.PI * VacDisplay.vacuumHeading) / 180);
                ActualVacuumData.VacuumCoords[1] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Sin((Math.PI * VacDisplay.vacuumHeading) / 180);
                
                VacDisplay.CenterVacuumDisplay(ActualVacuumData.VacuumCoords, floorPlan);

                if (collision.VacuumCollidedWithObstacle(VacDisplay, floorPlan))
                {
                    collision.HandleCollision(VacDisplay, ActualVacuumData, floorPlan);

                    //actually start running the algorithm
                    if (VacDisplay.firstWallCol)
                    {
                        VacDisplay.firstWallCol = false;
                        Debug.WriteLine("startTile Set");
                    }

                    //align with wall by turning clockwise
                    VacDisplay.vacuumHeading += 90;
                    VacDisplay.vacuumHeading = VacDisplay.vacuumHeading % 360;
                }

                if (!VacDisplay.firstWallCol)
                {
                    //need the tile to the left of the vacuum
                    if (VacDisplay.vacuumHeading < 90.0f) //vaccuum is heading right
                    {
                        if (NoVacuuumInnerTilesAreAdjacentToANonFloorInnerTile(VacDisplay, floorPlan)) // Vacuum is now clear to change direction and round the corner
                        {
                            if (!currentlyRoundingACorner)
                            {
                                VacDisplay.vacuumHeading = 270; // Start going up
                                currentlyRoundingACorner = true;
                            }
                        }
                        else
                            currentlyRoundingACorner = false;
                    }
                    else if (VacDisplay.vacuumHeading < 180.0f) // vacuum is heading down
                    {
                        if (NoVacuuumInnerTilesAreAdjacentToANonFloorInnerTile(VacDisplay, floorPlan)) // Vacuum is now clear to change direction and round the corner
                        {
                            if (!currentlyRoundingACorner)
                            {
                                VacDisplay.vacuumHeading = 0; // Start going right
                                currentlyRoundingACorner = true;
                            }
                        }
                        else
                            currentlyRoundingACorner = false;
                    }
                    else if (VacDisplay.vacuumHeading < 270.0f) // vacuum is heading left
                    {
                        if (NoVacuuumInnerTilesAreAdjacentToANonFloorInnerTile(VacDisplay, floorPlan)) // Vacuum is now clear to change direction and round the corner
                        {
                            if (!currentlyRoundingACorner)
                            {
                                VacDisplay.vacuumHeading = 90; // Start going down
                                currentlyRoundingACorner = true;
                            }
                        }
                        else
                            currentlyRoundingACorner = false;
                    }
                    else //vacuum is heading up
                    {
                        if (NoVacuuumInnerTilesAreAdjacentToANonFloorInnerTile(VacDisplay, floorPlan)) // Vacuum is now clear to change direction and round the corner
                        {
                            if (!currentlyRoundingACorner)
                            {
                                VacDisplay.vacuumHeading = 180; // Start going left
                                currentlyRoundingACorner = true;
                            }
                        }
                        else
                            currentlyRoundingACorner = false;
                    }

                    Debug.WriteLine(VacDisplay.vacuumHeading);
                }

                floorCleaner.CleanInnerTiles(VacDisplay, ActualVacuumData, floorPlan);

                FloorCanvasCalculator.UpdateSimulationData(VacDisplay);
            }
        }

        public bool NoVacuuumInnerTilesAreAdjacentToANonFloorInnerTile(VacuumDisplay VacDisplay, FloorplanLayout HouseLayout)
        {
            List<InnerTile> innerHitboxTiles = HouseLayout.GetVacuumHitboxInnerTiles(VacDisplay, HouseLayout);

            // Iterate through each vacuum inner tile and check if any of them are adjacent to a non-floor tile
            foreach (InnerTile innerTile in innerHitboxTiles)
            {
                InnerTile leftAdjTile = HouseLayout.GetInnerTileFromCoordinates(innerTile.x - InnerTile.innerTileSideLength, innerTile.y);
                InnerTile rightAdjTile = HouseLayout.GetInnerTileFromCoordinates(innerTile.x + InnerTile.innerTileSideLength, innerTile.y);
                InnerTile aboveAdjTile = HouseLayout.GetInnerTileFromCoordinates(innerTile.x, innerTile.y - InnerTile.innerTileSideLength);
                InnerTile belowAdjTile = HouseLayout.GetInnerTileFromCoordinates(innerTile.x, innerTile.y + InnerTile.innerTileSideLength);

                if (leftAdjTile.obstacle != ObstacleType.Floor || rightAdjTile.obstacle != ObstacleType.Floor ||
                    aboveAdjTile.obstacle != ObstacleType.Floor || belowAdjTile.obstacle != ObstacleType.Floor)
                    return false;
            }

            return true;
        }
    }
}
