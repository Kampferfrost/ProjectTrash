using CollectionLessons.Interfaces;

namespace CollectionLessons
{
    internal class Lesson3 : ILesson
    {
        public int Number => 3;

        public string Title => "Очередь Queue";

        public async Task StartLessonExamplesAsync()
        {
            await CreateQueue();
            await ShowPatients();
        }

        private async Task CreateQueue()
        {
            Console.WriteLine("\nСоздание очереди");
            var employess = new List<string> { "Reimu", "Konata", "Kiana" };
            Queue<string> people = new Queue<string>(employess);
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
            people.Enqueue("Hikita");
            var firstPersonCheck = people.Peek();
            var PersonDequeue = people.Dequeue();
            Console.WriteLine($"Извлекаем первого из очереди: {PersonDequeue}");
            people.TryDequeue(out PersonDequeue);
            Console.WriteLine($"Извлекаем первого из очереди: {PersonDequeue}");
            

        }

        private async Task ShowPatients()
        {
            Console.WriteLine("\nОсмотр пациентов");
            Console.WriteLine(nameof(ShowPatients));
            var patients = new Queue<Person>();
            patients.Enqueue(new Person("Slam"));
            patients.Enqueue(new Person("Bulbash"));
            patients.Enqueue(new Person("Shark"));
            var practitioner = new Doctor(patients);
            practitioner.TakePatients(patients);
        }

        private record Person(string Name);
        private class Doctor
        {
            private Queue<Person> _patients;
            public Doctor(Queue<Person> patients)
            {
                _patients = patients;
            }
            public void TakePatients(Queue<Person> _patients)
            {
                while (_patients.Count > 0)
                {
                    var patient = _patients.Dequeue();
                    Console.WriteLine($"Осмотр пациеннта {patient.Name}");
                }
                Console.WriteLine("Доктор закончил осматривать пациентов");
                
            }
        }
    }


}
