using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;

//������ ���� Ǯ�� ������
class Pool
{
    GameObject _prefab;
    IObjectPool<GameObject> _pool;

    Transform _root;
    Transform Root
    {
        get
        {
            if (_root == null)
            {
                GameObject go = new GameObject() { name = $"{_prefab.name}Root" };
                _root = go.transform;
            }
            return _root;
        }

    }
    public Pool(GameObject prefab)
    {
        _prefab = prefab;
        _pool = new ObjectPool<GameObject>(OnCreate, OnGet, OnRelease, OnDestroy);
    }

    public GameObject Pop()
    {
        return _pool.Get();

    }

    public void Push(GameObject go)
    {
        _pool.Release(go);
    }

    #region Funcs

    GameObject OnCreate()
    {
        GameObject go = GameObject.Instantiate(_prefab); go.transform.parent = Root;
        go.name = _prefab.name;
        return go;
    }

    void OnGet(GameObject go)
    {
        go.SetActive(true);
    }
    void OnRelease(GameObject go)
    {
        go.SetActive(false);
    }
    void OnDestroy(GameObject go)
    {

        GameObject.Destroy(go);
    }



    #endregion
}
public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }

    Dictionary<string, Pool> _pools = new Dictionary<string, Pool>();



    private void Awake()
    {
        // �̱��� �ʱ�ȭ
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //���� ���� �ַ� ��
    //������ ���� Ȥ�� ��Ȱ��
    public GameObject Pop(GameObject prefab)
    {
        if (_pools.ContainsKey(prefab.name) == false)
        {
            CreatePool(prefab);
        }

        return _pools[prefab.name].Pop();
    }

    //������ �ݳ�
    public bool Push(GameObject go)
    {
        if (_pools.ContainsKey(go.name) == false)
        {
            return false;
        }

        _pools[go.name].Push(go);
        return true;

    }
    //��Ȱ�� �� �������� ���� ���
    void CreatePool(GameObject prefab)
    {
        Pool pool = new Pool(prefab);
        _pools.Add(prefab.name, pool);
    }
}