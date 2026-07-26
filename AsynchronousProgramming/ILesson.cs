using System;
using System.Collections.Generic;
using System.Text;

namespace AsynchronousProgramming
{
    public interface ILesson
    {
        public int Number { get;  }
        public string Title { get;}

        void StartLessonExamples();
    }
}
