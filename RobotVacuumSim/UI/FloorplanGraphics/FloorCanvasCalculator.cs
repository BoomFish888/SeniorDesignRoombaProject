﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using VacuumSim.Sim;
using System.Diagnostics;

namespace VacuumSim.UI.FloorplanGraphics
{
    /// <summary>
    /// Performs calculations for graphics objects on the FloorCanvas
    /// </summary>
    public class FloorCanvasCalculator
    {
        public static int frameCount { get; set; } = 0; // Count of frames displayed during a simulation
        public const int framesPerSimSecond = 4; // Number of frames per simulation second

        /// <summary>
        /// Calculates the endpoints of the vacuum's whiskers
        /// </summary>
        /// <param name="VacDisplay"> The display of the vacuum onto FloorCanvas </param>
        public static void CalculateWhiskerCoordinates(VacuumDisplay VacDisplay)
        {
            // Choose fixed start (x, y) coordinates of whiskers based on vacuum heading
            VacDisplay.whiskersStartingCoords[0] = VacDisplay.vacuumCoords[0] + (VacuumDisplay.vacuumDiameter / 2.0f) * (float)Math.Cos((Math.PI * VacDisplay.vacuumHeading - 30) / 180);
            VacDisplay.whiskersStartingCoords[1] = VacDisplay.vacuumCoords[1] + (VacuumDisplay.vacuumDiameter / 2.0f) * (float)Math.Sin((Math.PI * VacDisplay.vacuumHeading - 30) / 180);

            // Calculate ending (x, y) coordinates of whiskers
            // 2 inch long whiskers = tile side length (2 ft = 24 inches) / 12
            // Also have to convert the 2 inches to screen coordinates
            float lenWhiskersExtendFromVacuum = FloorplanLayout.tileSideLength / 12.0f;

            if (Simulation.simStarted) // Only want to rotate whiskers during simulation timer ticks
                VacDisplay.whiskersHeadingWRTVacuum = (VacDisplay.whiskersHeadingWRTVacuum + 30) % 270;

            VacDisplay.whiskersEndingCoords[0] = VacDisplay.vacuumCoords[0] + (VacuumDisplay.vacuumDiameter / 2.0f + lenWhiskersExtendFromVacuum) * (float)Math.Cos((Math.PI * VacDisplay.vacuumHeading - VacDisplay.whiskersHeadingWRTVacuum) / 180);
            VacDisplay.whiskersEndingCoords[1] = VacDisplay.vacuumCoords[1] + (VacuumDisplay.vacuumDiameter / 2.0f + lenWhiskersExtendFromVacuum) * (float)Math.Sin((Math.PI * VacDisplay.vacuumHeading - VacDisplay.whiskersHeadingWRTVacuum) / 180);
        }

        /// <summary>
        /// Conversion from inches to screen units
        /// FloorplanLayout.tileSideLength is the length of a tile's edge in screen units, and 24.0f is the length of a tile's edge in inches (24 in = 2 ft)
        /// </summary>
        /// <param name="inches"> A given value in inches </param>
        /// <returns> The converted value in screen units </returns>
        public static float ConvertInchesToScreenUnits(float inches)
        {
            return inches * (FloorplanLayout.tileSideLength / 24.0f);
        }

        /// <summary>
        /// Conversion from screen units to inches
        /// </summary>
        /// <param name="inches"> A given value in screen units </param>
        /// <returns> The converted value in inches</returns>
        public static float ConvertScreenUnitsToInches(float screenUnits)
        {
            return screenUnits * (24.0f / FloorplanLayout.tileSideLength);
        }

        /// <summary>
        /// Gets the distance (in screen units) traveled per frame
        /// </summary>
        /// <param name="vacuumSpeedInInches"> The speed of the vacuum (in inches) selected by the user </param>
        /// <returns> The distance (in screen units) traveled per frame </returns>
        public static float GetDistanceTraveledPerFrame(float vacuumSpeedInInches)
        {
            return ConvertInchesToScreenUnits(vacuumSpeedInInches) / framesPerSimSecond;
        }

        /// <summary>
        /// Updates simulation data after a frame update
        /// After "framesPerSimSecond" frame updates, simulation time can be incremented, and battery left decremented
        /// This is because "framesPerSimSecond" frame updates = 1 simulation second
        /// </summary>
        /// <param name="VacDisplay"> The display of the vacuum onto FloorCanvas </param>
        public static void UpdateSimulationData(VacuumDisplay VacDisplay)
        {
            frameCount++;

            if (frameCount % framesPerSimSecond == 0)
            {
                Simulation.simTimeElapsed++;
                VacDisplay.batterySecondsRemaining--;
            }
        }

        /// <summary>
        /// Returns the text explaining how much battery is left on the vacuum
        /// </summary>
        /// <param name="VacDisplay"> The display of the vacuum onto FloorCanvas </param>
        /// <returns> The text that goes in the battery life label on FloorCanvas </returns>
        public static string GetBatteryRemainingText(VacuumDisplay VacDisplay)
        {
            string s = VacDisplay.batterySecondsRemaining == 1 || VacDisplay.batterySecondsRemaining / 60 == 1 ? "" : "s"; // Get extra 's' if plural

            return "" + (VacDisplay.batterySecondsRemaining >= 60 ? VacDisplay.batterySecondsRemaining / 60 + " minute" + s : VacDisplay.batterySecondsRemaining + " second" + s);
        }

        /// <summary>
        /// Returns the text explaining how much "simulation time" has elapsed
        /// </summary>
        /// <returns> The text that goes in the elapsed time label on FloorCanvas </returns>
        public static string GetTimeElapsedText()
        {
            string s = Simulation.simTimeElapsed == 1 || Simulation.simTimeElapsed / 60 == 1 ? "" : "s"; // Get extra 's' if plural

            return "" + (Simulation.simTimeElapsed >= 60 ? Simulation.simTimeElapsed / 60 + " minute" + s : Simulation.simTimeElapsed + " second" + s);
        }
    }
}
