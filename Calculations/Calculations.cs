public class Calculations
{
    public Calculations()
    {
    }

    public double Mr(double[] Mr, int N)
    {
        double sum = 0;
        for (int i = 0; i < N; i++)
        {
            sum += Mr[i];
        }
        return sum;
    }

    public double Kp(double Zv, double GKR, double VMP, double RKP)
    {
        return System.Math.Round(((Zv + GKR - VMP) / RKP), 2);
    }

    public double Pvc(int it, double[] Mi, double[] Npi)
    {
        double sum = 0;
        for (int i = 0; i < it; i++)
        {
            sum += Mi[i] * Npi[i];
        }
        return sum;
    }

    public double Vtg(int it, double[] Mdp, double[] Nz)
    {
        double sum = 0;
        for (int i = 0; i < it; i++)
        {
            sum += 12 * Mdp[i] * (18 - Nz[i]);
        }
        return sum;
    }

    public double Pc(int it, double[] Mi, double[] Npi)
    {
        double sum = 0;
        for (int i = 0; i < it; i++)
        {
            sum += Mi[i] * Npi[i] * 1.5;
        }
        return sum;
    }

    public double Prv(int it, double[] Mi, double[] Npi)
    {
        double sum = 0;
        for (int i = 0; i < it; i++)
        {
            sum += Mi[i] * Npi[i] * 3 * 3;
        }
        return sum;
    }

    public double Fg(int it, double[] Pi, double[] Ki, double Lv)
    {
        double sum = 0;
        for (int i = 0; i < it; i++)
        {
            sum += Pi[i] * Ki[i];
        }
        return sum - Lv;
    }

    public double Vtrr(int it, double[] Ml, double[] Nl, double[] Mt, double[] Nt, double[] Mi, double[] Ni, double[] Mz, double[] Nz)
    {
        double sum = 0;
        for (int i = 0; i < it; i++)
        {
            sum += Ml[i] * Nl[i] + Mt[i] * Nt[i] + Mi[i] * Ni[i] + Mz[i] * Nz[i];
        }
        return sum;
    }

    public double Prc(int it, double[] Si, double[] Ki, double[] Ui, double[] Tci, double[] Zi_dod)
    {
        double sum = 0;
        for (int i = 0; i < it; i++)
        {
            sum += Si[i] * Ki[i] * Ui[i] * Tci[i] - Zi_dod[i];
        }
        return sum;
    }

    public double Rsg1(double N, double P)
    {
        return N * P;
    }

    public double Rsg2(double k, double N, double P)
    {
        return (1 - k) * N * P;
    }

    public double E(double vvp, double B0, int Tt, int Tr, double Ef)
    {
        return System.Math.Round(((vvp / Ef) * (System.Math.Exp(-1 * Ef * Tt) - System.Math.Exp(-1 * Ef * Tr)) + ((B0 * vvp) / (Ef * Ef)) * ((1 + Ef * Tt) * System.Math.Exp(-1 * Ef * Tt) - (1 + Ef * Tr) * System.Math.Exp(-1 * Ef * Tr))), 2);
    }

    public double Mdg_o(int it, double[] Pi, double[] Ki, double[] ki, double[] qi)
    {
        double sum = 0;
        for (int i = 0; i < it; i++)
        {
            sum += Pi[i] * Ki[i] * ki[i] * qi[i];
        }
        return sum;
    }

    public double Rlg1(double N, double K, double P)
    {
        return N * K * P;
    }

    public double Rlg2(double k, double N, double P)
    {
        return (1 - k) * N * P;
    }

    public double Rlg3(double N1, double N2, double K, double P)
    {
        return (N2 - N1) * K * P;
    }

    public double N(double[] Mr)
    {
        return Mr[0] * Mr[1] * Mr[2] + Mr[3] * Mr[2] * Mr[1] * Mr[4] / 100 + Mr[5] * Mr[2] * Mr[1] * Mr[6] / 100;
    }

    public double N1(double[] Mr)
    {
        return Mr[0] * Mr[1] / 100 * Mr[2] * Mr[3] * Mr[4] / 100 * Mr[5];
    }

    public double N2(double[] Mr)
    {
        return Mr[0] * Mr[1] * Mr[2] * Mr[3] * Mr[4] * 0.000001 / (100 * Mr[5]);
    }

    public double N3(double[] Mr)
    {
        return Mr[0] * Mr[1] * Mr[2] * Mr[3] * 0.000001 / (100 * Mr[4]);
    }

    public double N5(double[] Mr)
    {
        return Mr[0] * Mr[1] * Mr[2] / 100 * Mr[3] * Mr[4] * Mr[5] / 100 * Mr[6];
    }

    public double Pz(int it, double[] Qi, double[] Qi_p)
    {
        double sum = 0;
        for (int i = 0; i < it; i++)
        {
            sum += Qi_p[i] - Qi[i];
        }
        return sum;
    }
}