using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonballLibrary
{
    /// <summary>
    /// A class for representing the values of a cannonball pyramid
    /// </summary>
    public class CannonballPyramidModel
    {
        public int layers;
        public int totalCannonballs;
        public long usedCannonballs;
        public long remainingCannonballs;

        /// <summary>
        /// Overriden ToString method for displaying a cannonball pyramid
        /// </summary>
        /// <returns>String - The string value of the Pyramid calss</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"");
            sb.AppendLine($"Layers:         {layers}");
            sb.AppendLine($"Total CBs:      {totalCannonballs}");
            sb.AppendLine($"Used CBs:       {usedCannonballs}");
            sb.AppendLine($"Remaining CBs:  {remainingCannonballs}");

            return sb.ToString();
        }
    }
}
