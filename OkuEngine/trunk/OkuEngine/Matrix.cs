using System;
using System.Collections.Generic;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// GertMatrix is a simple 3 by 3 matrix that can be used to do transformations.
  /// Use the static methods to create matrices for several transformations.
  /// Always keep in mind that a new transformation is calculated
  /// <code>transform = new * old</code>. It won't work the other way around!
  /// +++ APPROVED FOR OKU GEN-2 +++
  /// </summary>
  public class Matrix
  {
    private float[,] _values = new float[3, 3];
    private const int _rowCount = 3;
    private const int _columnCount = 3;

    /// <summary>
    /// Creates a new 3 by 3 matrix. All elements are set to 0.
    /// </summary>
    public Matrix()
    {
    }
    
    /// <summary>
    /// Gets or sets the value of one element of the matrix.
    /// </summary>
    /// <param name="row">The row of the value.</param>
    /// <param name="column">The column of the value.</param>
    /// <returns></returns>
    public float this[int row, int column]
    {
      get { return _values[row, column]; }
      set { _values[row, column] = value; }
    }
    
    /// <summary>
    /// Gets the number of rows this matrix has.
    /// </summary>
    public int RowCount
    {
      get { return _rowCount; }
    }
    
    /// <summary>
    /// Gets the number of columns of this matrix.
    /// </summary>
    public int ColumnCount
    {
      get { return _columnCount; }
    }

    /// <summary>
    /// Multiplies this matrix by the given one. This is <code>this * other</code>.
    /// </summary>
    /// <param name="other">The matrix to multiply by.</param>
    /// <returns>The result of the multiplication in a new matrix.</returns>
    public Matrix Multiply(Matrix other)
    {
      Matrix result = new Matrix();

      for (int i = 0; i < _rowCount; i++)
      {
        for (int j = 0; j < other.ColumnCount; j++)
        {
          for (int k = 0; k < _columnCount; k++)
          {
            result[i, j] += this[i, k] * other[k, j];
          }
        }
      }
      
      return result;
    }

    /// <summary>
    /// Multiplies the given vector by this matrix. The vector is treated like a 1x3 matrix
    /// with the elements set to [x, y, 1].
    /// </summary>
    /// <param name="vector">The vector to be multiplied.</param>
    /// <returns>The result of the calculation in a new vector.</returns>
    public Vector Multiply(Vector vector)
    {
      /*Vector result = new Vector();
      result.X = vector.X * this[0, 0] + vector.Y * this[1, 0] + this[2, 0];
      result.Y = vector.X * this[0, 1] + vector.Y * this[1, 1] + this[2, 1];
      return result;*/

      return new Vector(vector.X * this[0, 0] + vector.Y * this[1, 0] + this[2, 0], vector.X * this[0, 1] + vector.Y * this[1, 1] + this[2, 1]);
    }
    
    /// <summary>
    /// Loads this matrix with the identity values. That is [[1,0,0][0,1,0][0,0,1]].
    /// Any multiplication with an identity matrix returns the original matrix.
    /// </summary>
    public void LoadIdentity()
    {
      for (int i = 0; i < _columnCount; i++)
      {
        for (int j = 0; j < _rowCount; j++)
        {
          _values[j, i] = i == j ? 1.0f : 0.0f;
        }
      }
    }

    public Matrix ExtractRotation()
    {
      Matrix result = new Matrix();
      result.LoadIdentity();
      result[0, 0] = this[0, 0];
      result[0, 1] = this[0, 1];
      result[1, 0] = this[1, 0];
      result[1, 1] = this[1, 1];
      return result;
    }

    public Matrix ExtractTranslation()
    {
      Matrix result = new Matrix();
      result.LoadIdentity();
      result[2, 0] = this[2, 0];
      result[2, 1] = this[2, 1];
      return result;
    }

    /// <summary>
    /// Creates a matrix that rotates clockwise by the given degrees.
    /// Negative values are allowed to create counter clockwise rotations.
    /// </summary>
    /// <param name="angle">The angle to be rotated in degrees.</param>
    /// <returns>A matrix that rotates.</returns>
    public static Matrix Rotation(float angle)
    {
      float radians = (angle / 180.0f) * (float)Math.PI;
      Matrix result = new Matrix();
      result.LoadIdentity();
      float cos = (float)Math.Cos(radians);
      float sin = (float)Math.Sin(radians);
      result[0, 0] = cos;
      result[0, 1] = sin;
      result[1, 0] = -sin;
      result[1, 1] = cos;
      return result;
    }

    /// <summary>
    /// Creates a matrix that scales by the given factors.
    /// </summary>
    /// <param name="sx">The scaling factor on the x axis.</param>
    /// <param name="sy">The scaling factor on the y axis.</param>
    /// <returns>A matrix that scales.</returns>
    public static Matrix Scale(float sx, float sy)
    {
      Matrix result = new Matrix();
      result.LoadIdentity();
      result[0, 0] = sx;
      result[1, 1] = sy;
      return result;
    }

    /// <summary>
    /// Creates a matrix that skews by the given values.
    /// </summary>
    /// <param name="sx">The skewing on the x axis.</param>
    /// <param name="sy">The skewing on the y axis.</param>
    /// <returns>A matrix that skews.</returns>
    public static Matrix Skew(float sx, float sy)
    {
      Matrix result = new Matrix();
      result.LoadIdentity();
      result[0, 1] = sy;
      result[1, 0] = sx;
      return result;
    }

    /// <summary>
    /// Creates a matrix that translates by the given offsets.
    /// </summary>
    /// <param name="tx">The x translation offset.</param>
    /// <param name="ty">The y translation offset.</param>
    /// <returns>A matrix that translates.</returns>
    public static Matrix Translate(float tx, float ty)
    {
      Matrix result = new Matrix();
      result.LoadIdentity();
      result[2, 0] = tx;
      result[2, 1] = ty;
      return result;
    }

    /// <summary>
    /// Creates a new Matrix from the given string. Reads a string in the format 
    /// "float,float,float|float,float,float|float,float,float",
    /// that represents a 3x3 Matrix, into this Matrix, overwrittin the former values. You
    /// can get a string in that format from the <code>ToString</code> method.
    /// Throws a <code>FormatException</code> if the format of the given string is not correct.
    /// </summary>
    /// <param name="str">The string representation of a matrix to be used.</param>
    /// <returns>The resulting Matrix.</returns>
    public static Matrix FromString(string str)
    {
      Matrix result = new Matrix();
      result.Assign(str);
      return result;
    }

    /// <summary>
    /// Gets a new Matrix object initialized to be an identity Matrix.
    /// </summary>
    public static Matrix Identity
    {
      get
      {
        Matrix result = new Matrix();
        result.LoadIdentity();
        return result;
      }
    }

    /// <summary>
    /// Reads a string in the format "float,float,float|float,float,float|float,float,float",
    /// that represents a 3x3 Matrix, into this Matrix, overwrittin the former values. You
    /// can get a string in that format from the <code>ToString</code> method.
    /// Throws a <code>FormatException</code> if the format of the given string is not correct.
    /// </summary>
    /// <param name="str">The string representation of a matrix to be used.</param>
    public void Assign(string str)
    {
      string[] vectors = str.Split('|');
      if (vectors.Length == 3)
      {
        for (int i = 0; i < 3; i++)
			  {
          string[] components = vectors[i].Split(',');
          if (components.Length == 3)
          {
            for (int j = 0; j < 3; j++)
            {
              float value = 0;
              if (Single.TryParse(components[j], out value))
                _values[i, j] = value;
              else
                throw new FormatException("Wrong number format in matrix string: \"" + components[j] + "\" is not a valid float number!");
            }
          }
          else
            throw new FormatException("Wrong matrix string format: \"" + vectors[i] + "\" has to few columns! Three are required.");
  			}        
      }
      else
        throw new FormatException("Wrong matrix string format: \"" + str + "\" has to few rows! Three are required.");
    }
    
    /// <summary>
    /// Converts the matrix to a readable string value.
    /// </summary>
    /// <returns>The matrix as a readable string value</returns>
    public override string ToString()
    {
      StringBuilder result = new StringBuilder();

      for (int i = 0; i < _rowCount; i++)
      {
        if (i > 0)
          result.Append("|");
        for (int j = 0; j < _columnCount; j++)
        {
          if (j > 0)
            result.Append(",");
          result.Append(_values[i, j].ToString());
        }
      }

      return result.ToString();
    }

  }
}
