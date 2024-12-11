namespace MauiBindingIssue.Models
{
	public class AnswerLookupModel
	{
		public int ID { get; set; }

		public string Description { get; set; }

		public override string ToString()
		{
			return Description;
		}
	}
}
