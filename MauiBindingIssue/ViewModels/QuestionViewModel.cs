using MauiBindingIssue.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MauiBindingIssue.ViewModels
{
	public class QuestionViewModel
	{

		private QuestionnaireViewModel _questionnaireViewModel;
		private List<AnswerLookupModel> _answerModels;
		private QuestionModel _model;

		public QuestionViewModel(QuestionnaireViewModel questionnaireViewModel, QuestionModel model, List<AnswerLookupModel> answerModels)
		{
			_model = model;
			_answerModels = answerModels;
			_questionnaireViewModel = questionnaireViewModel;
		}


		public string Description
		{
			get { return _model.Description; }
		}

		public List<AnswerLookupModel> Answers
		{
			get { return _answerModels; }
		}

		public AnswerLookupModel SelectedAnswer
		{
			get
			{
				if (_model.AnswerLookupID.HasValue)
				{
					AnswerLookupModel answerModel = _answerModels.Find(o => o.ID == _model.AnswerLookupID.Value);
					return answerModel;
				}
				else
					return null;
			}
			set
			{
				int? newID;
				if (value != null)
					newID = value.ID;
				else
					newID = null;

				if (_model.AnswerLookupID != newID)
				{
					Debug.WriteLine("Answer for '" + _model.Description + "' changed to " + newID?.ToString());

					_model.AnswerLookupID = newID;
					OnPropertyChanged();
				}
			}
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;

			if (handler != null)
			{
				// Raise the PropertyChanged event, passing the name of the property whose value has changed.
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged = delegate { };

	}
}
