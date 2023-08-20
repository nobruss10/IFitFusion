﻿using IFitFusion.Infrastructure.CrossCutting.DomainHelper;

namespace IFitFusion.Domain.Entities
{
    public class TrainingPlan : Entity
    {
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<PlannedExercise> PlannedExercises { get; set; } = new();
    }
}
