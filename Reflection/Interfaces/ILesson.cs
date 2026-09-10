namespace Reflection.Interfaces
{
    public interface ILesson
    {
        public int Number { get; }
        public string Title { get; }

        Task StartLessonExamplesAsync();
    }
}
