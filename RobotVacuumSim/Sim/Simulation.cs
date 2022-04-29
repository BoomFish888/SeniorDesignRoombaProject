using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacuumSim.Sim
{
    public class Simulation
    {
        public static bool simStarted = false; // Is the simulation currently running
        public static int simSpeed = 1; // 1x, 5x, or 50x speed
        public static int simTimeElapsed = 0; // Simulation time elapsed (in seconds)
        public static int lastSimTimeElapsed = 0;
        public static string simulationStartTime;
    }
}