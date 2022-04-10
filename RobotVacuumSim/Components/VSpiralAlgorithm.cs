﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacuumSim.UI.FloorplanGraphics;

namespace VacuumSim.Components
{
    /// <summary>
    /// Subclass of VacuumController. Implements Spiral Pathing algorithm for the Vacuum.
    /// </summary>
    public class VSpiralAlgorithm : VacuumController
    {
        private bool spiralFlag = false;
        private int obstacleDistanceCounter = 0;
        public override void ExecVPath(VacuumDisplay VacDisplay, FloorplanLayout HouseLayout, CollisionHandler collisionHandler, FloorCleaner floorCleaner, Vacuum ActualVacuumData)
        {
            //If the vacuum is not in a spiral, it will just move in a straight line until it is a reasonable distance away from the obstacle it just hit.
            if (spiralFlag == false)
            {
                ActualVacuumData.VacuumCoords[0] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Cos(Math.PI * VacDisplay.vacuumHeading / 180);
                ActualVacuumData.VacuumCoords[1] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Sin(Math.PI * VacDisplay.vacuumHeading / 180);

                obstacleDistanceCounter++;

                // this is pretty arbitrary; it just allows the vacuum to get far enough from an obstacle/wall before it starts spiraling so it has enough room. this can be changed as needed. 
                if (obstacleDistanceCounter >= 30)
                    spiralFlag = true;
            }
            else if (spiralFlag == true)
            {
                // equations are    x = (a + b * theta) * cos(theta) multiplied by the actual distance traveled per frame
                //                  y = (a + b * theta) * sin(theta) multiplied by the actual distance traveled per frame
                // a is the position of the centerpoint of the spiral.
                // b is how far apart the loops of the spiral are. 
                ActualVacuumData.VacuumCoords[0] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)((0.01 + 0.0002 * ActualVacuumData.heading) * (Math.Cos(Math.PI * ActualVacuumData.heading / 180)));
                ActualVacuumData.VacuumCoords[1] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)((0.01 + 0.0002 * ActualVacuumData.heading) * (Math.Sin(Math.PI * ActualVacuumData.heading / 180)));

                // headings had to be stored separate because the %360 that needs to be done to the vacuum display heading interferes with the proper calulations of each point on the spiral. so, increment the heading used
                // for the calulation seperated from the modded heading for the display. 
                ActualVacuumData.heading++;
                VacDisplay.vacuumHeading = ActualVacuumData.heading % 360;
            }

            VacDisplay.CenterVacuumDisplay(ActualVacuumData.VacuumCoords, HouseLayout);

            if (collisionHandler.VacuumCollidedWithObstacle(VacDisplay, HouseLayout))
            {
                collisionHandler.HandleCollision(VacDisplay, ActualVacuumData, HouseLayout);
                // when the vacuum encounters an obstacle, it will turn a random direction and travel in a straight line once more
                // until it determines with the obstacleDistanceCounter that it has traveled sufficiently far away.
                Random rnd = new Random();
                VacDisplay.vacuumHeading = rnd.Next() % 360;
                ActualVacuumData.heading = VacDisplay.vacuumHeading;
                spiralFlag = false;
                // reset the counter to allow the vacuum to move away from the obstacle
                obstacleDistanceCounter = 0;
            }
            floorCleaner.CleanInnerTiles(VacDisplay, ActualVacuumData, HouseLayout);

            FloorCanvasCalculator.UpdateSimulationData(VacDisplay);

            // upon completion
            if (Vacuum.VacuumAlgorithm.Count != 0)
                Vacuum.VacuumAlgorithm.RemoveAt(0);
            if (Vacuum.VacuumAlgorithm.Count == 0)
                allAlgFinish = true;
        }
    }
}
