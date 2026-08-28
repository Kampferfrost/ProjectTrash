using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.Interfaces
{
    public interface ILesson
    {
        public int Number { get; }
        public string Title { get; }

        Task StartLessonExamplesAsync();
    }
}
