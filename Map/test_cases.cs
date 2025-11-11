using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    public class test_cases
    {

        string[] output_arr;
        int index = 0;
        public test_cases(string output)
        {
            output_arr = File.ReadAllLines(output);

        }

        public bool testcasesfun(List<int> path, double minTime, double vehicleDist, double walkingDist)
        {
            string[] parts = output_arr[index++].Split(' ');
            int[] points = Array.ConvertAll(parts, int.Parse);
            double op_time = double.Parse(output_arr[index++].Split()[0]);
            double op_total = double.Parse(output_arr[index++].Split()[0]);
            double op_walk = double.Parse(output_arr[index++].Split()[0]);
            double op_vec = double.Parse(output_arr[index++].Split()[0]);
            double total_distance = vehicleDist + walkingDist;
            index++;

            if (path.Count != points.Length)
            {
                return false;
            }

            for (int i = 0; i < points.Length; i++)
            {
                if (path[i] != points[i])
                {
                    return false;
                }
            }

            // We rounds the inputs because small fraction error
            if (Math.Round(op_time, 2) != Math.Round(minTime, 2))
            {
                return false;
            }

            if (Math.Round(op_total, 2) != Math.Round(total_distance, 2))
            {
                return false;
            }

            if (Math.Round(op_walk, 2) != Math.Round(walkingDist, 2))
            {
                return false;
            }

            if (Math.Round(op_vec, 2) != Math.Round(vehicleDist, 2))
            {
                return false;
            }

            return true;
        }
    }
}
