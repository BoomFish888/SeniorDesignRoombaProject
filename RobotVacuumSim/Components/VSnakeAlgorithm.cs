using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacuumSim.UI.FloorplanGraphics;


namespace VacuumSim.Components
{
    /// <summary>
    /// Subclass of VacuumController. Implements Snake Pathing algorithm for the Vacuum.
    /// </summary>
    public class VSnakeAlgorithm : VacuumController
    {

        public override void ExecVPath(VacuumDisplay VacDisplay, FloorplanLayout floorPlan, CollisionHandler collisionHandler, FloorCleaner floorCleaner, Vacuum ActualVacuumData)
        {
            //Debug.WriteLine("running snake algorithm");



            var collision = collisionHandler;
            double test;

            ActualVacuumData.VacuumCoords[0] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Cos((Math.PI * VacDisplay.vacuumHeading) / 180);
            ActualVacuumData.VacuumCoords[1] += FloorCanvasCalculator.GetDistanceTraveledPerFrame(VacDisplay.vacuumSpeed) * (float)Math.Sin((Math.PI * VacDisplay.vacuumHeading) / 180);

            VacDisplay.CenterVacuumDisplay(ActualVacuumData.VacuumCoords, floorPlan);



            if (VacDisplay.hitCounter >25)
            {
                Random rnd = new Random();
                VacDisplay.vacuumHeading = rnd.Next() % 360;
                VacDisplay.hitCounter = 0;
            }



            //vacuum colides. Target position is set
            if (collision.VacuumCollidedWithObstacle(VacDisplay, floorPlan))
            {
                collision.HandleCollision(VacDisplay, ActualVacuumData, floorPlan);

                Debug.Write("Vacuum collided at ");
                Debug.WriteLine(VacDisplay.vacuumHeading);

                double angle = Math.PI * VacDisplay.vacuumHeading / 180.0;

                test = (ActualVacuumData.VacuumSize/2) * Math.Sin(angle);

                if(test<0)
                    VacDisplay.destination[0] = ActualVacuumData.VacuumCoords[0] + test;
                else
                    VacDisplay.destination[0] = ActualVacuumData.VacuumCoords[0] - test;

                Debug.WriteLine(VacDisplay.turnDirection);

                /*
                 * if you want to continue debugging the y pos of the target unncomment this block
                if (VacDisplay.turnDirection > 0 && VacDisplay.vacuumHeading == 0)
                {
                    Debug.WriteLine("target is down");
                    VacDisplay.destination[1] = ActualVacuumData.VacuumCoords[1] + Math.Sqrt((ActualVacuumData.VacuumSize / 2) * (ActualVacuumData.VacuumSize / 2) - test * test);
                }
                else
                {
                    Debug.WriteLine("target is up");
                    */
                VacDisplay.destination[1] = ActualVacuumData.VacuumCoords[1] - Math.Sqrt((ActualVacuumData.VacuumSize / 2) * (ActualVacuumData.VacuumSize / 2) - test * test);
                //}


                //VacDisplay.destination[1] = ActualVacuumData.VacuumCoords[1] - Math.Sqrt((ActualVacuumData.VacuumSize / 2) * (ActualVacuumData.VacuumSize / 2) - test * test);

                /*
                Debug.Write("Target X is ");
                Debug.WriteLine(VacDisplay.destination[0]);

                Debug.Write("Current X position is ");
                Debug.WriteLine(ActualVacuumData.VacuumCoords[0]);
                */

                VacDisplay.vacuumHeading += VacDisplay.turnDirection;
                VacDisplay.vacuumHeading = VacDisplay.vacuumHeading % 360;

                if (VacDisplay.vacuumHeading < 0)
                    VacDisplay.vacuumHeading = 360 + VacDisplay.vacuumHeading;

                if (VacDisplay.collided)
                {
                    Random rnd = new Random();
                    VacDisplay.vacuumHeading = rnd.Next() % 360;
                    VacDisplay.hitCounter = 0;

                }


                VacDisplay.collided = true;
                VacDisplay.hitCounter++;
                //X value of the target is reached 
            }
            if (VacDisplay.collided)
            {

                

                if ((VacDisplay.vacuumHeading > 270 && VacDisplay.vacuumHeading < 360) || (VacDisplay.vacuumHeading >=0 && VacDisplay.vacuumHeading < 90)) // right half
                {

                    if (ActualVacuumData.VacuumCoords[0] < VacDisplay.destination[0])
                    {
                        Debug.Write("Vacuum entered the right quadrent at ");
                        Debug.WriteLine(VacDisplay.vacuumHeading);
                        VacDisplay.vacuumHeading += VacDisplay.turnDirection;
                        VacDisplay.vacuumHeading = VacDisplay.vacuumHeading % 360;
                        if (VacDisplay.vacuumHeading < 0)
                            VacDisplay.vacuumHeading = 360 + VacDisplay.vacuumHeading;

                        VacDisplay.turnDirection = -VacDisplay.turnDirection;
                        Debug.Write("Vacuuum exited right quadrent at");
                        Debug.WriteLine(VacDisplay.vacuumHeading);
                        VacDisplay.collided = false;
                        VacDisplay.hitCounter++;

                    }

                }
                else if (VacDisplay.vacuumHeading > 90 && VacDisplay.vacuumHeading < 270) //left half
                {
                    if (ActualVacuumData.VacuumCoords[0] < VacDisplay.destination[0])
                    {
                        Debug.Write("Vacuum entered the left quadrent at ");
                        Debug.WriteLine(VacDisplay.vacuumHeading);
                        VacDisplay.vacuumHeading += VacDisplay.turnDirection;
                        
                        VacDisplay.vacuumHeading = VacDisplay.vacuumHeading % 360;
                        if (VacDisplay.vacuumHeading < 0)
                            VacDisplay.vacuumHeading = 360 + VacDisplay.vacuumHeading;

                        VacDisplay.turnDirection = -VacDisplay.turnDirection;
                        Debug.Write("Vacuuum exited left quadrent at");
                        Debug.WriteLine(VacDisplay.vacuumHeading);
                        VacDisplay.collided = false;
                        VacDisplay.hitCounter++;

                    }
                }
                else if (VacDisplay.vacuumHeading == 90)
                {
                    /* 
                    Debug.Write("actual vacuum at y pos ");
                    Debug.WriteLine(ActualVacuumData.VacuumCoords[1]);

                    Debug.Write("target y pos ");
                    Debug.WriteLine(VacDisplay.destination[1]);
                    */
                    if (ActualVacuumData.VacuumCoords[1] < VacDisplay.destination[1]) // straight down. if you dont want this to find the nearest corner, switch the < to >
                    {
                        VacDisplay.vacuumHeading += VacDisplay.turnDirection;
                        VacDisplay.vacuumHeading = VacDisplay.vacuumHeading % 360;
                        if (VacDisplay.vacuumHeading < 0)
                            VacDisplay.vacuumHeading = 360 + VacDisplay.vacuumHeading;

                        VacDisplay.turnDirection = -VacDisplay.turnDirection;
                        //Debug.Write("turned vacuum at y pos ");
                        //Debug.WriteLine(ActualVacuumData.VacuumCoords[1]);
                        //Debug.WriteLine(VacDisplay.vacuumHeading);

                        VacDisplay.collided = false;
                        VacDisplay.hitCounter++;

                    }
                }
                else //straight up
                {
                    Debug.WriteLine(VacDisplay.vacuumHeading);

                    if (ActualVacuumData.VacuumCoords[1] < VacDisplay.destination[1])
                    {
                        VacDisplay.vacuumHeading += VacDisplay.turnDirection;
                        VacDisplay.vacuumHeading = VacDisplay.vacuumHeading % 360;
                        if (VacDisplay.vacuumHeading < 0)
                            VacDisplay.vacuumHeading = 360 + VacDisplay.vacuumHeading;
                        VacDisplay.turnDirection = -VacDisplay.turnDirection;

                        //Debug.WriteLine("top quadrent");
                        //Debug.WriteLine(VacDisplay.vacuumHeading);

                        VacDisplay.collided = false;
                        VacDisplay.hitCounter++;

                    }


                }
            }

            floorCleaner.CleanInnerTiles(VacDisplay, ActualVacuumData, floorPlan);

            FloorCanvasCalculator.UpdateSimulationData(VacDisplay);
        }
    
    
    
        private string SnakeAlgVer = "Snake Algorithm Version 1.2"; 
        public override string getVer()
        {
            return SnakeAlgVer;
        }
    } 
}
