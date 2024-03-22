using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Generate : MonoBehaviour
{
    private int _rows = 100;
    private int _columns = 100;
    [SerializeField] private Mesh mesh;
    [SerializeField] private Material mat;
    [SerializeField,Range(1,20)] float speed;
    private Matrix4x4[] _matrix4X4;
    private int[] _randomMove;
    void Start()
    {
        _matrix4X4 = new Matrix4x4[_rows * _columns];
        _randomMove = new int[_rows * _columns];
        for (int i = 0; i < _columns * _rows; i++)
        {
            int rand = 0;
            while (rand==0)
            {
                rand = Random.Range(-1, 2);
            }
            _randomMove[i] = rand;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                var index = i * _columns+j;
                var size = mesh.bounds.size;
                _matrix4X4[index] = Matrix4x4.TRS(new Vector3(size.x * j,(size.y*2)*(_randomMove[index]*Mathf.Sin(Time.time*speed)) , size.z * i ), quaternion.identity, Vector3.one);
            }
        }
        RenderParams rp = new RenderParams(mat);
        Graphics.RenderMeshInstanced(rp, mesh, 0, _matrix4X4);
    }
}
