using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Matrix<T> : IEnumerable<T>
{
	private int _width;
    private int _height;
    private int _capacity;
    private T[] _data;
    
    public int Width => _width;
    public int Height => _height;
    public int Capacity => _capacity;

    public Matrix(int width, int height)
    {
	    _width = width;
        _height = height;
        _capacity = width * height;

        _data = new T[_capacity];
    }

	public Matrix(T[,] copyFrom)
    {
	    _capacity = copyFrom.Length;
        _width = copyFrom.GetLength(0);
        _height = copyFrom.GetLength(1);
        
        _data = new T[_capacity];

        for (int i = 0; i < _width; i++)
        {
	        for (int j = 0; j < _height; j++)
	        {
		        this[i, j] = copyFrom[i, j];
	        }    
        }
    }

	public Matrix<T> Clone() 
	{
		// REVISAR FUNCIONAMIENTO
        Matrix<T> aux = new Matrix<T>(Width, Height);
        
        for (int i = 0; i < _width; i++)
        {
	        for (int j = 0; j < _height; j++)
	        {
		        aux[i, j] = this[i, j];
	        }    
        }
        
        return aux;
    }

	public void SetRangeTo(int x0, int y0, int x1, int y1, T item) 
	{
        //IMPLEMENTAR: iguala todo el rango pasado por parámetro a item
    }

    //Todos los parametros son INCLUYENTES
    public List<T> GetRange(int x0, int y0, int x1, int y1) 
    {
        List<T> l = new List<T>();
        //IMPLEMENTAR
        return l;
	}
    
    public T this[int x, int y] 
    {
	    get => _data[x + _height * y];
	    set => _data[x + _height * y] = value;
    }

    public IEnumerator<T> GetEnumerator()
    {
	    foreach (var data	 in _data)
        {
	        yield return data;
        }
    }

	IEnumerator IEnumerable.GetEnumerator() 
	{
		return GetEnumerator();
	}
}
