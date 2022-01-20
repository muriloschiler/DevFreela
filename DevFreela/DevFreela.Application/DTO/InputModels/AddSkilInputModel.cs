namespace DevFreela.Application.DTO.InputModels{
    public class AddSkilInputModel{
        public AddSkilInputModel(int idSkill)
        {
            this.idSkill = idSkill;
        }

        public int idSkill { get; private set; }
        public int idFreelancer { get{return this.idFreelancer;} set{ this.idFreelancer = value;} }

    }

}
