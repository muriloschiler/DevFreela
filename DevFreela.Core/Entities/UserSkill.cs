namespace DevFreela.Core.Entities
{
    public class UserSkill
    {


        public UserSkill(int idUser, int idSkill)
        {
            this.IdUser = idUser;
            this.IdSkill = idSkill;

        }
        public int IdUser { get; private set; }
        public int IdSkill { get; private set; }

    }
}