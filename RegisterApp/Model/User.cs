using System.ComponentModel.DataAnnotations;

namespace RegisterApp.Model
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		
		[Required]
		public string Login { get; set; }
		
		[Required]
		public byte[] Password { get; set; }
		
		[Required]
		public byte[] Salt { get; set; }
	}
}