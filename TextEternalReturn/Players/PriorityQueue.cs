using TextEternalReturn.Items.Foods;

namespace TextEternalReturn.Players
{
    public class PriorityMinQueue
    {
        public struct MinQueue
        {
            public Food food;
            public string name;
            public int priority;
        }
        public MinQueue[] queue { get; private set; }
        public int Count;
        public int Capacity;
        public PriorityMinQueue()
        {
            Count = 0;
            Capacity = 1;
            queue = new MinQueue[10];
        }
        public PriorityMinQueue(int capacity)
        {
            Count = 0;
            Capacity = capacity;
            queue = new MinQueue[capacity];
        }

        public void Enqueue(Food food, int priority)
        {
            if (Count >= Capacity)
                Extend();
            //삽입하고 부모 노드와 비교해서 더 작으면 교환
            queue[Count] = new MinQueue() { food = food, name = food.name, priority = priority };
            Count++;

            int now = Count - 1; // 교체 진행 할 원소 저장
            int parent = (now - 1) / 2;
            while (queue[now].priority < queue[parent].priority)
            {
                if (queue[now].priority < queue[parent].priority)
                {
                    // 조건에 맞으면 교환
                    MinQueue temp = queue[now];
                    queue[now] = queue[parent];
                    queue[parent] = temp;
                    now = parent; // 인덱스 교체
                    parent = (now - 1) / 2;
                }
            }
        }
        public Food Dequeue()
        {
            if (Count <= 0)
                return null;
            MinQueue result = queue[0];
            queue[0] = queue[Count - 1]; // 마지막과 교체
            queue[Count - 1] = default;
            Count--;
            int now = 0; // 현재 인덱스
            while (now <= Count) //더 이상 내려갈 수 없을 때
            {
                int next = now; // next: 교체 할 자식노드 인덱스
                int left = next * 2 + 1;
                int right = next * 2 + 2;
                if (left <= Count - 1 && queue[now].priority >= queue[left].priority ||
                    right <= Count - 1 && queue[now].priority >= queue[right].priority) // 좌우측 둘중하나보다 클 때
                {
                    next = queue[left].priority < queue[right].priority ? left : right;
                }
                else
                    break;
                MinQueue temp = queue[now];
                queue[now] = queue[next];
                queue[next] = temp;
                //현재 위치 갱신
                now = next;
            }
            return result.food;
        }
        public void Remove(Food food)
        {
            if (Count <= 0)
                throw new IndexOutOfRangeException();
            MinQueue findfood = new MinQueue() { food = food, name = food.name, priority = food.priority };
            int index = queue.Select((b, i) => new { b, i })
                 .FirstOrDefault(x => x.b.name   == findfood.name)?.i ?? -1;
            queue[index] = queue[Count - 1]; // 해당 부분과 교체
            queue[Count - 1] = default;
            Count--;
            int now = 0; // 현재 인덱스
            while (now <= Count) //더 이상 내려갈 수 없을 때
            {
                int next = now; // next: 교체 할 자식노드 인덱스
                int left = next * 2 + 1;
                int right = next * 2 + 2;
                if (left <= Count - 1 && queue[now].priority >= queue[left].priority ||
                    right <= Count - 1 && queue[now].priority >= queue[right].priority) // 좌우측 둘중하나보다 클 때
                {
                    next = queue[left].priority < queue[right].priority ? left : right;
                }
                else
                    break;
                MinQueue temp = queue[now];
                queue[now] = queue[next];
                queue[next] = temp;
                //현재 위치 갱신
                now = next;
            }
        }
        public Food Peek()
        {
            return queue[0].food;
        }

        private void Extend()
        {
            MinQueue[] newQueue = new MinQueue[Capacity * 2];
            for (int i = 0; i < Count; i++)
            {
                newQueue[i] = queue[i];
            }
            queue = newQueue;
            Capacity *= 2;
        }
    }
}
