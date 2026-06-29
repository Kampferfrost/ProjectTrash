using System;
using System.Collections.Generic;
using System.Text;

namespace ParallelProgrammin.Interfaces
{
    internal interface ILesson
    {
        int Number {  get; }
        string Title { get;  }
        void StartLessonExamples();
    }
}
