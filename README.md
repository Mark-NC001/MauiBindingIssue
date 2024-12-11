# MauiBindingIssue

This app highlights an issue where changing the BindingContext for a page can cause a Picker to update it the previously bound item's bound SelectedItem  property to null.

Run the app - this will display QuestionPage.

QuestionPage has it's BindingContext set to the first item a collection of QuestionViewModel objects. A picker on QuestionPage gets its ItemSource items from the Answers collection hanging off the QuestionViewModel. The SelectedItem property of the Picker is bound to the SelectedAnswer property of the QuestionViewModel.

The Description of the QuestionVewModel will be displayed in a label - for the first QuestionViewModel, the Description is "This item has some possible answers - pick one from the combo." - the combo wil have two items available, "Answer 1" and "Answer 2". Pick "Answer One" - and, correctly, the SelectedAnswer property of the current QuestionViewModel will be set accordingly.

Click the Next button. This will update the page's BindingContext to point to a different QuestionViewModel, which does not have any items in it's Answers collection - but in the process of setting the BindingContext, it ends up setting the SelectedAnswer property of the previously bound QuestionViewModel to null! 

I have added some code in the Next button handler to display a message box showing the before and after SelectedAnswer for the question.
