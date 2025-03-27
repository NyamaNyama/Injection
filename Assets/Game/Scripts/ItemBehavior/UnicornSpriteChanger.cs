using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


    public class UnicornSpriteChanger : MonoBehaviour
    {
        [SerializeField] private Sprite[] spritesList;
        [SerializeField] private float changeCooldown;
        [SerializeField] private float changeRange;
        [SerializeField] private LayerMask itemLayer;
        private float _time;
        private Coroutine _changer;
        private void Start()
        {
            _time = changeCooldown;
        }

        private void Update()
        {
            if (_time >= changeCooldown)
            {
                Collider2D[] items = Physics2D.OverlapCircleAll(transform.position, changeRange, itemLayer);
                StartCoroutine(ChangeSprite(items));
                _time -=_time;
            }
            else
            {
                _time += Time.deltaTime;
            }
            
        }

        private IEnumerator ChangeSprite(Collider2D[] items)
        {
            foreach (var item in items)
            {
                if (item.gameObject != gameObject)
                {
                    int random = Random.Range(0,spritesList.Length);
                    item.GetComponent<SpriteRenderer>().sprite =
                        spritesList[random];
                    yield return null;
                }
            }
        }
    }
