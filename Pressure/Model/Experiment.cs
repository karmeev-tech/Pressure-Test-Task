﻿using Pressure.JSON;
using Pressure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressure.Model
{
    public class Experiment
    {
        public int StartExperiment(int value, int type, int limitation)
        {
            switch (type)
            {
                case 0:
                    break;
                case 1:
                    return value - 10;
                case 2:
                    return value + 10;
                case 3:
                    Random rnd = new Random();
                    int randomValue = rnd.Next(-500, 500);
                    if(value + randomValue > limitation)
                    {
                        return 200;
                    }
                    else
                    {
                        return value + randomValue;
                    }
            }
            return 0;
        }
    }
}
