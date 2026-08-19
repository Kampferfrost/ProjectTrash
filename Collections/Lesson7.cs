using CollectionLessons.Interfaces;
using System.Collections;
namespace CollectionLessons
{
    internal class Lesson7 : ILesson
    {
        public int Number => 7;

        public string Title => "Интерфейсы IEnumerable и IEnumerator";

        public async Task StartLessonExamplesAsync()
        {
            await StartExampleIterateArrayWithIEnumerator();
            await StartImplementationOfIEnumerableAndIEnumerator();
        }

        // без использования цикла foreach перебирем массив с помощью интерфейса IEnumerator:
        private async Task StartExampleIterateArrayWithIEnumerator()
        {
            Console.WriteLine("\nБез использования цикла foreach перебирем массив с помощью интерфейса IEnumerator:");
            Console.WriteLine(nameof(StartExampleIterateArrayWithIEnumerator));

            string[] zadrots = { "Sector", "Slam", "Footman" };
            IEnumerator zadrotsEnumerator = zadrots.GetEnumerator(); // получаем IEnumerator
            while (zadrotsEnumerator.MoveNext())
            {
                string item = (string)zadrotsEnumerator.Current; // получаем элемент на текущей позиции
                Console.WriteLine(item);
            }
            zadrotsEnumerator.Reset(); // сбрасываем указатель в начало массива
        }
        private async Task StartImplementationOfIEnumerableAndIEnumerator()
        {
            Console.WriteLine();
            Console.WriteLine("Обобщенная версия IEnumerator");
            Console.WriteLine(nameof(StartImplementationOfIEnumerableAndIEnumerator));
            Week week = new Week();
            foreach (var day in week)
            {
                Console.WriteLine(day);
            }
        }
        private class Week
        {
            string[] _days = { "Monday", "Tuesday", "Wednesday", "Thursday",
                         "Friday", "Saturday", "Sunday" };
            public IEnumerator<string> GetEnumerator() => new WeekEnumerator(_days);
        }
        internal class WeekEnumerator : IEnumerator<string>
        {
            string[] _days;
            int _position = -1;
            public WeekEnumerator(string[] days) => _days = days;
            public string Current
            {
                get
                {
                    if (_position == -1 || _position >= _days.Length)
                        throw new ArgumentException();
                    return _days[_position];
                }
            }
            object IEnumerator.Current => Current;
            public bool MoveNext()
            {
                if (_position < _days.Length - 1)
                {
                    _position++;
                    return true;
                }
                else
                    return false;
            }
            public void Reset() => _position = -1;
            public void Dispose() { }

        }

    }


}

