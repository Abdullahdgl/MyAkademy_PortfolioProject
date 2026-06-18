namespace Portfolio.Data.Entites
{
	public class TechStack
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<ProjectTechStack> ProjectTechStacks { get; set; }

	}
}
