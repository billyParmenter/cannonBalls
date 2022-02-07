using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonballLibrary
{
    /// <summary>
    ///  A class for doing pyramid related calculations
    /// </summary>
    public class CannonballPyramidCalculations
    {


        /// <summary>
        /// Converts a number of layers to number of cannonballs used
        /// </summary>
        /// <param name="layers">The number of layers to be converted, it is a double to help with the calculation</param>
        /// <returns>long - the number of cannonballs used in the given layers</returns>
        public static long LayersToCannonballsUsed(double layers)
        {
            double cannonballsUsed = ((Math.Pow(layers, 3f) / 3f) + (Math.Pow(layers, 2f) / 2f) + (layers / 6f)); // f(x) = (x^3/3) + (x^2/2) + (x/6)
            if (cannonballsUsed - Math.Floor(cannonballsUsed) >= 0.999)
            {
                return (long)Math.Ceiling(cannonballsUsed);
            }
            return (long)cannonballsUsed;
        }





        /// <summary>
        /// Converts a number of cannonballs to number of layers. The result is an estimate (+/- 1 layer)
        /// </summary>
        /// <param name="cannonballs">The number of cannonballs to be converted, it is a double to help with the calculation</param>
        /// <returns>int - The close approximation of number of layers based on the given number of cannonballs</returns>
        public static int CannonballsToLayers(double cannonballs)
        {
            double a = Math.Pow(3, (1f / 3f)); // a = ∛3 
            double d = ((-108 * cannonballs) + (Math.Sqrt(3) * Math.Sqrt(3888 * Math.Pow(cannonballs, 2) - 1)));
            double b = -Math.Pow(-d, (1f / 3f)); // b = ∛(-108x + √(3) * √[3888(x^2) - 1]) Not sure why i have to add the two negatives but it returns Nan without them
            double c = Math.Pow(3, (2f / 3f)); // c = 3^(2/3)

            double layers = -((a * b) / 6) - 1f / 2f - (c / (6 * b));

            if (layers - Math.Floor(layers) >= 0.999)
            {
                return (int)Math.Ceiling(layers);
            }
            return (int)Math.Floor(layers);
        }





        /// <summary>
        /// An equation aproach to building pyramids
        /// </summary>
        /// <param name="cannonballs">The number of cannonballs to be used in the pyramid</param>
        /// <returns>CannonballPyramidModel - The constructed pyramid</returns>
        public static CannonballPyramidModel BuildCannonballPyramid(int cannonballs)
        {
            int layers = CannonballsToLayers(cannonballs);
            bool correctLayers = false;
            CannonballPyramidModel calculatedPyramid = new CannonballPyramidModel
            {
                totalCannonballs = cannonballs,
            };

            if (cannonballs <= 0)
            {
                calculatedPyramid.layers = 0;
                return calculatedPyramid;
            }

            while (correctLayers == false)
            {
                calculatedPyramid.usedCannonballs = LayersToCannonballsUsed(layers);

                if (calculatedPyramid.usedCannonballs > cannonballs)
                {
                    layers--;
                }
                else if (LayersToCannonballsUsed(layers + 1) <= cannonballs)
                {
                    layers++;
                }
                else
                {
                    correctLayers = true;
                }
            }

            calculatedPyramid.remainingCannonballs = cannonballs - calculatedPyramid.usedCannonballs;

            calculatedPyramid.layers = layers;

            return calculatedPyramid;
        }
    }
}
