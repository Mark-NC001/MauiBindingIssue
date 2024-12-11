using MauiBindingIssue.Models;
using System.Collections.ObjectModel;

namespace MauiBindingIssue.ViewModels
{
	public class QuestionnaireViewModel
	{
		private List<QuestionViewModel> _questions;

		public QuestionnaireViewModel()
		{
			_questions = new List<QuestionViewModel>();


			QuestionModel questionModel = new QuestionModel();
			questionModel.Description = "This item has some possible answers - pick one from the combo.";
			List<AnswerLookupModel> answerModels = new List<AnswerLookupModel>()
			{
				new AnswerLookupModel() { Description = "Answer 1", ID = 1},
				new AnswerLookupModel() { Description = "Answer 2", ID = 2}

			};
			QuestionViewModel question = new QuestionViewModel(this, questionModel, answerModels);
			_questions.Add(question);


			questionModel = new QuestionModel();
			questionModel.Description = "This item does not have any possible answers";
			answerModels = new List<AnswerLookupModel>()
			{
			};
			question = new QuestionViewModel(this, questionModel, answerModels);
			_questions.Add(question);

		}

		public List<QuestionViewModel> Questions
		{
			get { return _questions; }
		}

	}
}
