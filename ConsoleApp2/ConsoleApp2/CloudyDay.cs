using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    abstract class CloudTown
    {
        abstract public long getPopulation();
        abstract public void setPeopleCovered(long peopleCovered);

        abstract public long getPeopleCovered();
    }

    class Cloud : CloudTown
    {

        public long minPos = 0;
        public long maxPos = 0;
        public long range = 0;
        public long cloudId = 0;
        public long peopleCovered = 0;
        public long pos = 0;

        public Cloud(long pos, long range, long cloudId)
        {
            this.range = range;
            this.minPos = pos - range;
            this.maxPos = pos + range;
            this.cloudId = cloudId;
            this.pos = pos;
        }

        public bool coversPos(long pos)
        {
            if (this.minPos <= pos && pos <= this.maxPos)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void setPeopleCovered(long peopleCovered)
        {
            this.peopleCovered = peopleCovered;
        }

        public override long getPeopleCovered()
        {
            return this.peopleCovered;
        }

        public override long getPopulation()
        {
            return 0;
        }
    }

    class Town : CloudTown
    {
        public long population = 0;
        public long location = 0;

        public Town(long location, long population)
        {
            this.population = population;
            this.location = location;
        }

        public override long getPopulation()
        {
            return this.population;
        }

        public override void setPeopleCovered(long peopleCovered)
        {

        }

        public override long getPeopleCovered()
        {
            return 0;
        }

    }

    class Position
    {
        public string type = "";
        public long point = 0;
        public int objectIndex = 0;


        public Position(string type, long point, int index)
        {
            this.type = type;
            this.point = point;
            this.objectIndex = index;
        }

        public bool isCloud()
        {
            if (this.type != "t")
            {
                return true;
            }

            return false;
        }
    }

    class Solution
    {
        private static int comparePositions(Position pos1, Position pos2)
        {
            if (pos1.point == pos2.point)
            {

                if (pos1.isCloud() && pos2.isCloud())
                {
                    return 0;
                }
                else if (!pos1.isCloud() && !pos2.isCloud())
                {
                    return 0;
                }

                //all clouds should be processed before towns hence clouds are less than towns.
                if (pos1.isCloud())
                {
                    return -1;
                }
                else
                {
                    return 1;
                }

            }

            if (pos1.point > pos2.point)
            {
                return 1;
            }
            else if (pos1.point < pos2.point)
            {
                return -1;
            }

            return 0;
        }

        // Complete the maximumPeople function below.
        public static long maximumPeople(long[] townPopulations, long[] townLocations, long[] cloudLocations, long[] cloudRanges)
        {

            List<CloudTown> cloudsAndTowns = new List<CloudTown>();
            List<Position> positions = new List<Position>();
            List<long> cloudIndexes = new List<long>();
            long maxPeople = 0;
            long sunnyPeople = 0;

            for (int i = 0; i < cloudLocations.Length; i++)
            {
                Cloud cloud = new Cloud(cloudLocations[i], cloudRanges[i], i);
                cloudsAndTowns.Add(cloud);

                //get the unique identifier of this cloud in our $cloudsAndTowns array
                int index = cloudsAndTowns.Count - 1;
                cloudIndexes.Add(index);

                //Insert the upper and lower bound positions into the $positions array
                //ensuring that every position has a unique key. 
                positions.Add(new Position("l", cloud.minPos, index));
                positions.Add(new Position("h", cloud.maxPos + 1, index));

            }

            for (int i = 0; i < townLocations.Length; i++)
            {
                Town town = new Town(townLocations[i], townPopulations[i]);
                cloudsAndTowns.Add(town);

                int index = cloudsAndTowns.Count - 1;
                positions.Add(new Position("t", town.location, index));
            }


            //sort the positions in ascending order. 
            positions.Sort(comparePositions);

            Dictionary<int, long> activeClouds = new Dictionary<int, long>();
            foreach (Position position in positions)
            {

                //Are you a town or a cloud?
                if (position.isCloud())
                { //cloud
                    if (position.type == "l")
                    {
                        activeClouds.Add(position.objectIndex, position.point);
                    }
                    else if (position.type == "h")
                    {
                        activeClouds.Remove(position.objectIndex);
                    }
                }
                else
                { //town
                    if (activeClouds.Count == 0)
                    {
                        sunnyPeople += cloudsAndTowns[position.objectIndex].getPopulation();
                    }
                    else if (activeClouds.Count == 1)
                    {
                        int cloudRef = activeClouds.First().Key;
                        cloudsAndTowns[cloudRef].setPeopleCovered(cloudsAndTowns[cloudRef].getPeopleCovered() + cloudsAndTowns[position.objectIndex].getPopulation());
                    }
                }
            }

            foreach (long cloudIndex in cloudIndexes)
            {
                if (cloudsAndTowns[(int)cloudIndex].getPeopleCovered() > maxPeople)
                {
                    maxPeople = cloudsAndTowns[(int)cloudIndex].getPeopleCovered();
                }
            }

            maxPeople = maxPeople + sunnyPeople;
            return maxPeople;

        }
    }
}
