using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionLessons.Interfaces
{
    public interface ILesson
    {
        public int Number { get; }
        public string Title { get; }

        Task StartLessonExamplesAsync();
    }
}
