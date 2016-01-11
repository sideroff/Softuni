namespace CohesionAndCoupling.Interfaces
{
    public interface IMathUtility
    {
        double Width { get; set; }

        double Height { get; set; }

        double Depth { get; set; }

        double CalcDistance2D(double x1, double y1, double x2, double y2);

        double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2);

        double CalcVolume();

        double CalcDiagonalXYZ();

        double CalcDiagonalXY();

        double CalcDiagonalXZ();

        double CalcDiagonalYZ();
    }
}