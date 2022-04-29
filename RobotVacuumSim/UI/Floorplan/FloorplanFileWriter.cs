using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VacuumSim
{
    public class FloorplanFileWriter
    {
        public static int currentObstacleGroupNumber = 0; // Group number of most recent obstacle that was added. Gets saved to the .txt file to be used when the floor plan is loaded again

        public FloorplanFileWriter()
        {
        }

        private static string[] GetTileGridData(FloorplanLayout HouseLayout)
        {
            string[] lines = new string[HouseLayout.numTilesPerCol + 1]; // NumTilesPerCol is technically the number of rows. Confusing, I know. The +1 is for the extra top row of data

            lines[0] = "SavedGroupID " + currentObstacleGroupNumber + " "; // Save the obstacle group number we were on
            lines[0] += "Dimensions " + HouseLayout.numTilesPerRow + " " + HouseLayout.numTilesPerCol; // Save the floorplan dimensions

            for (int i = 0; i < HouseLayout.numTilesPerCol; i++)
            {
                lines[i + 1] = i + " " + "0" + " " + HouseLayout.floorLayout[0, i].obstacle + " " + HouseLayout.floorLayout[0, i].groupID; // First value in row
                for (int j = 1; j < HouseLayout.numTilesPerRow; j++)
                {
                    lines[i + 1] = lines[i + 1] + " " + i + " " + j + " " + HouseLayout.floorLayout[j, i].obstacle + " " + HouseLayout.floorLayout[j, i].groupID;
                }
            }
            return lines;
        }

        public static void SaveTileGridData(string path, FloorplanLayout HouseLayout)
        {
            string[] lines = GetTileGridData(HouseLayout);
            File.WriteAllLines(path, lines);
        }

        public static string[] TileGridDataAsString(FloorplanLayout HouseLayout)
        {
            string[] lines = GetTileGridData(HouseLayout);

            return lines;
        }
    }
}