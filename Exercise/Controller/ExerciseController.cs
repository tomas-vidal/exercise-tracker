using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ExerciseController
    {
        private readonly ExerciseService _exerciseService;

        public ExerciseController(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public void AddExercise()
        {
            _exerciseService.AddExerciseEntry();
        }

        internal void DeleteExercise()
        {
            _exerciseService.DeleteExerciseEntry();
        }

        internal void UpdateExercise()
        {
            _exerciseService.UpdateExerciseEntry();
        }

        internal void ViewExercises()
        {
            _exerciseService.ViewAllExercisesEntries();
        }
    }
}
