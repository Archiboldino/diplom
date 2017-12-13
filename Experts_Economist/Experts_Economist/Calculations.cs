using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Calculations
    {
    public Calculations()
    {

    }

    public double Q_t(double U_t, double C_t, double Z_t)
    {
        double value = U_t + C_t + Z_t;
        return value;
    }

}

