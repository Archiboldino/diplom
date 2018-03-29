using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicForm
{
    class MedicalCalculator
    {

        public double getOSTG(double volumeOfDischarge, double airEmissions)
        {
            return 67.9 - 0.014 * volumeOfDischarge + 0.135 * airEmissions;
        }

        public double getOSTG_2(double volumeOfDicharge, double chemicalAirEmissions1, double chemicalAirEmissions2)
        {
            return 68.8 - 0.0656 * volumeOfDicharge + 0.021 * chemicalAirEmissions1 - 0.014 * chemicalAirEmissions2;
        }

        public double getPM_GIM(double volumeOfWasteWaterDischarges, double airEmissionByMovableInstallation,
            double chemicalAirEmissions1, double chemicalAirEmissions2)
        {
            return 137.6 + 0.74 * volumeOfWasteWaterDischarges + 0.68 * airEmissionByMovableInstallation
                - 1.36 * chemicalAirEmissions1 + 1.04 * chemicalAirEmissions2;
        }

        public double getPM_MI(double volumeOfWasteWaterDischarges, double chemicalAirEmissions)
        {
            return 592 + 1.38 * volumeOfWasteWaterDischarges - 0.79 * chemicalAirEmissions;
        }

        public double getPM_HCVP(double volumeOfWasteWaterDischarges, double chemicalAirEmissions)
        {
            return 708 + 1.8 * chemicalAirEmissions - 0.79 * volumeOfWasteWaterDischarges;
        }

        public double getBVForMen(double ADS, double ZDV, double SOZ, double SB)
        {
            return 27 + 0.22 * ADS - 0.15 * ZDV + 0.72 * SOZ - 0.15 * SB;
        } 

        public double getBVForWomen(double ADP, double MT, double SOZ, double SB)
        {
            return 1.46 + 0.42 * ADP + 0.25 * MT + 0.70 * SOZ - 0.14 * SB;
        }

        public double getNBVForMen(double age)
        {
            return 0.629 * age + 18.6;
        }

        public double getNBVForWomen(double age)
        {
            return 0.581 * age + 17.3;
        }

        public double getFV_SSSForMen(double X1, double X2, double X3, double X4)
        {
            return 124 - 0.5 * X1 - 0.31 * X2 - 0.12 * X3 + 0.59 * X4;
        }

        public double getFV_SSSForWomen(double X1, double X2)
        {
            return 147 - 1.56 * X1 - 0.38 * X2;
        }

        public double getFV(double T1, double T2, double T3, double TV6, double TV1, double MOK, double C3, double PSS)
        {
            return 28.8 - 0.157 * (T1 + T2 + T3) - 0.001 * (TV6 / TV1) + 0.034 * MOK + 0.21 * C3 + 0.006 * PSS; 
        }

        public double getFVDSForMen(double RD, double Rvid, double Rvd, double SVP)
        {
            return 96.3 - 0.3 * RD - 11.3 * Rvid - 3 * Rvd - 2.5 * SVP;
        }

        public double getFVDSForWomen(double RD, double Rvid, double Rvd, double SVP)
        {
            return 91 - 0.123 * RD - 26.4 * Rvid - 4.5 * Rvd - 4 * SVP;
        }

        public double getIPVR(double MV1, double MV2, double DV)
        {
            return 138 - 0.57 * MV2 - 0.73 * MV1 - 0.65 * DV;
        }

        public double getFV_SVR(double SHVR)
        {
            return (1.71*SHVR - 130);
        }

        public double getFV_TransForMen(double X1, double X2, double X3, double X4, double X5)
        {
            return 9.9 - 0.05 * X1 - 3.7 * X2 + 2.29 * X3 + 0.02 * X4 + 0.35 * X5;
        }

        public double getFV_TransForWomen(double X1, double X2, double X3, double X4, double X5)
        {
            return 56 - 0.3 * X1 - 3.4 * X2 - 0.46 * X3 + 0.02 * X4 + 0.49 * X5;
        }

        public double FV_CNCForMen(double SOZ, double Do, double D, double H, double Si, double TV, double OP, double ZD, double DZD)
        {
            return 13.37 + 0.55 * SOZ + 2.19 * Do - 0.64 * D + 0.181 - 0.15 * H + 1.53 * Si + 0.21 * TV + OP - 0.31 * ZD + 0.19 * DZD;
        }

        public double FV_CNCForWomen(double SOZ, double Do, double D, double I, double H, double Si, double TV, double OP, double ZD, double DZD)
        {
            return 9.52 + 1 * SOZ + 1.81 * Do + 1.56 * D - 0.65 * I - 1.02 * H + 0.09 * Si + 0.37 * TV + 0.09 * OP - 0.03 * ZD - 0.1 * DZD;
        }

    }
}
