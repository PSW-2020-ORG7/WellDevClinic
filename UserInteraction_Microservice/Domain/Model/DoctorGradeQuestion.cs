namespace UserInteraction_Microservice.Domain.Model
{
    public class DoctorGradeQuestion
    {
        public long Id { get; set; }
        public double Grade { get; set; }
        public string Question { get; set; }
        public DoctorGradeQuestion() {}
        public DoctorGradeQuestion(double grade, string question)
        {
            Grade = grade;
            Question = question;
        }

    }
}