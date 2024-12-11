using MauiBindingIssue.Models;
using MauiBindingIssue.ViewModels;
using System.Diagnostics;

namespace MauiBindingIssue.Views;

public partial class QuestionPage : ContentPage
{

	private QuestionnaireViewModel _viewModel;
	private int _currentIndex = 0;

	public QuestionPage(QuestionnaireViewModel viewModel) 
	{


		if (viewModel == null)
			throw new ArgumentNullException(nameof(viewModel));

		_viewModel = viewModel;

		InitializeComponent();

		BindingContext = _viewModel.Questions[_currentIndex];
	}

	private async void Next_Clicked(object sender, EventArgs e)
	{

		if (_currentIndex < _viewModel.Questions.Count - 1)
		{

			QuestionViewModel question = _viewModel.Questions[_currentIndex];
			AnswerLookupModel answerToQuestion = question.SelectedAnswer;

			_currentIndex++;
			Debug.WriteLine("Next - Setting index to: " + _currentIndex.ToString());
			BindingContext = _viewModel.Questions[_currentIndex];

			if (question.SelectedAnswer != answerToQuestion)
			{

				string newAnswer;
				if (question.SelectedAnswer != null)
					newAnswer = "'" + question.SelectedAnswer.ToString() + "'";
				else
					newAnswer = "NULL";

				await DisplayAlert("Oops!", "The selected anwser to question '" 
					+ question.Description 
					+ "' was '" 
					+ answerToQuestion.Description 
					+ "' but the answer got changed to "
					+ newAnswer
					+ " when changing the BindingContext!", "OK");
			}

		}
		else
			await DisplayAlert("Alert", "No further pages available!", "OK");
	}

	private async void Back_Clicked(object sender, EventArgs e)
	{
		if (_currentIndex > 0)
		{
			_currentIndex--;
			Debug.WriteLine("Back - Setting index to: " + _currentIndex.ToString());
			BindingContext = _viewModel.Questions[_currentIndex];
		}
		else
			await DisplayAlert("Alert", "You're at the beginning already!", "OK");
	}
}