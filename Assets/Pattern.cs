using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathNet.Numerics.LinearAlgebra;

public class Pattern: MonoBehaviour
{

    private Matrix<double> pixels;
    public Pattern(Matrix<double> pixels)
    {
        this.pixels = pixels;
    }

    public Matrix<double> getPattern() {
        return pixels;
    }
    public int length()
    {
        return 1;
    }
}