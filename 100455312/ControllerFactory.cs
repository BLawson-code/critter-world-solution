using CritterController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b100455312
{
    class ControllerFactory : ICritterControllerFactory
    {
        public string Author => "100455312";

        public ICritterController[] GetCritterControllers()
        {
            List<ICritterController> controllers = new List<ICritterController>();
            for (int i = 0; i < 3 ; i++)
            {
               controllers.Add(new Bladee("Bladee" + (i + 1)));
                controllers.Add(new Sparky("Sparky" + (i + 1)));
                controllers.Add(new Sprint("Sprint" + (i + 1)));
            }
            return controllers.ToArray();
        }
    }
}
