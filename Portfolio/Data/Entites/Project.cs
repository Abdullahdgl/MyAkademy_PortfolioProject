using System.ComponentModel.DataAnnotations;

namespace Portfolio.Data.Entites
{
	public class Project
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="Görsel URL Boş Bırakılamaz.")]
		public string ImageUrl { get; set; }
		[Required(ErrorMessage = "Proje adı Boş Bırakılamaz.")]
		[MinLength(3,ErrorMessage ="Proje Adı En az 3 karakter olmalıdır.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Proje adı Boş Bırakılamaz.")]
		[MaxLength(100, ErrorMessage ="Proje Açıklaması En fazla 100 karakter olmalıdır. ")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Github url Boş Bırakılamaz.")]
		public string GithubUrl { get; set; }

		public List<ProjectTechStack>? ProjectTechStacks { get; set; }


	}
}
