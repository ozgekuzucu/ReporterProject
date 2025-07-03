namespace ReporterProject.PresentationLayer.Models
{
	public class CommentWithToxicityViewModel
	{
		public ReporterProject.EntityLayer.Entities.Comment Comment { get; set; }
		public bool IsToxic { get; set; }
		public double ToxicityScore { get; set; }
	}
}
