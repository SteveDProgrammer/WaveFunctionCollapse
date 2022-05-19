using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MathNet.Numerics.LinearAlgebra;

public class GameMaster : MonoBehaviour
{
    Matrix<double> pixels;
    Vector2Int input_size = new Vector2Int(4, 4);
    Vector2Int output_size = new Vector2Int(50, 50);

    public Texture2D sourceImage;
    private Color[] imagePixels;

    Pattern pattern;

    void Start()
    {
        pixels = Matrix<double>.Build.DenseOfArray(new double[,]{
          { 255, 255, 255, 255 },
          { 255, 0, 0, 0 },
          { 255, 0, 138, 0 },
          { 255, 0, 0, 0 }
        });

        imagePixels = sourceImage.GetPixels();

        int pattern_size = 2;
        HashSet<Matrix<double>> patterns = new HashSet<Matrix<double>>(); //HashSet only allows unique values
        Dictionary<Matrix<double>, int> weights = new Dictionary<Matrix<double>, int>(); //Pattern -> occurence
        Dictionary<Matrix<double>, int> probability = new Dictionary<Matrix<double>, int>(); //Pattern -> Probability

        // Find all patterns

        // input_size[0] - (pattern_size - 1) restricts the values of cols and rows within matrix when pattern_size gets added
        for (int row = 0; row < input_size[0] - (pattern_size - 1); row++)// row
        {
            for (int col = 0; col >= input_size[1] - (pattern_size - 1); col++)// column
            {
                Matrix<double> pattern = pixels.SubMatrix(row, pattern_size, col, pattern_size);
                List<Matrix<double>> pattern_rotations = GetAllRotations(pattern);

                foreach (Matrix<double> rotation in pattern_rotations)
                {
                    if (weights.ContainsKey(rotation)) weights[rotation] += 1;
                    else weights.Add(rotation, 1);
                }
                patterns.UnionWith(pattern_rotations); //Removes all duplicate patterns
            }
        }

        // Calculate Pattern Probability
        int sum_of_weights = 0;
        foreach (int value in weights.Values) sum_of_weights += value;
    }

    public Matrix<double> RotateMatrix(Matrix<double> input, int angle = 90) //Rotates Matrix by multiples of pi/2
    {
        Matrix<double> output = Matrix<double>.Build.Dense(input.RowCount, input.ColumnCount);
        for (int i = 0; i < angle/90; i++)
        {
            for (int col_index = input.ColumnCount - 1; col_index >= 0; col_index--)
            {
                output.SetRow(input.ColumnCount - 1 - col_index, input.Column(col_index));
            }
        }
        return output;
    }

    public List<Matrix<double>> GetAllRotations(Matrix<double> pixelMatrix)
    {
        Matrix<double> pmRotated1 = RotateMatrix(pixelMatrix);
        Debug.Log(pmRotated1);
        Matrix<double> pmRotated2 = RotateMatrix(pmRotated1);
        Debug.Log(pmRotated2);
        Matrix<double> pmRotated3 = RotateMatrix(pmRotated2);
        Debug.Log(pmRotated3);

        return new List<Matrix<double>> {pmRotated1, pmRotated2, pmRotated3};
    }
}
