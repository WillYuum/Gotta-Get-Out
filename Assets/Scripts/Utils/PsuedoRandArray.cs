namespace Utils
{
    [System.Serializable]
    public class PsuedoRandArray<T>
    {
        public PsuedoRandArray(params T[] _items)
        {
            if (_items == null)
            {
                _items = new T[] { };
            }
            else
            {
                items = _items;
            }
        }

        public T[] items;
        private int currentIndex = 0;

        private bool canShuffle = true;


        public void ToggleShuffle(bool _canShuffle)
        {
            canShuffle = _canShuffle;
        }

        public T PickNext()
        {
            T selectedItem = items[currentIndex];

            currentIndex += 1;
            if (currentIndex >= items.Length)
            {
                ShuffleArray();
                currentIndex = 0;
            }

            return selectedItem;
        }

        public void ShuffleArray()
        {
            if (canShuffle == false) return;
            UtilityHelper.ShuffleArray(items);
        }
    }
}